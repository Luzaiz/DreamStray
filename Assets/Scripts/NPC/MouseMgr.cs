using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MouseMgr : MonoBehaviour
{
    private Animation ani; //老鼠动画
    private NavMeshAgent agent; //导航
    public float runAwayDuration = 2f; // 逃跑持续时间
    [SerializeField]private bool isRunningAway   = false; // 是否正在逃跑  
    private float runAwayTimer = 0f; // 逃跑计时器 
    
    public Transform wayPoints; // 巡逻点父物体  
    private int currentPointIndex  = -1;   // 当前巡逻点索引
    
    // 玩家检测  
    //public Transform player; // 或者你可以使用其他方式来追踪玩家，如Tags或Layers   
    private bool isPlayerInTrigger = false;  
    
    public float visionRadius = 6f; // 半径  
    public float visionAngle = 90f; // 扇形角度，注意这个角度是从敌人正前方开始算起的  
  
    public Transform playerTransform; // 假设你有一个指向玩家Transform的引用  
    private Transform enemyTransform; // 敌人的Transform，通常是this.transform
    // Start is called before the first frame update
    void Start()
    {
        ani = GetComponent<Animation>();
        agent = GetComponent<NavMeshAgent>();
        //playerTransform = GameObject.FindWithTag("Player").transform;
        enemyTransform = transform;  
    }

    // Update is called once per frame
    void Update()
    {
        if (playerTransform == null)  
        {  
            Debug.LogError("No playerTransform reference set!");  
            return;  
        }  
        
        if (IsPlayerInVision())  
        {
            if (!isRunningAway)
            { 
                Debug.Log("玩家在老鼠视野内！");
                StartCoroutine(RunAwayFromPlayer());
            }
        }  
        else
        {  
            Debug.Log("老鼠在逃！");
            Wander();
        }
    }  
  
    void Wander()  
    {  
        // 如果玩家不在视野内，并且敌人没有在逃跑，则选择一个新的目标点  
        if (!isRunningAway && agent.remainingDistance <= agent.stoppingDistance)
        {
            int randomIndex = -1;
            //while (currentPointIndex == randomIndex)
            //{
                randomIndex = Random.Range(0, wayPoints.childCount); 
            //}
            agent.SetDestination(wayPoints.GetChild(randomIndex).position);
            //currentPointIndex = randomIndex;
        }  
    }  
  
    void EscapeFromPlayer()  
    {  
        // 计算逃离方向（玩家位置的反方向）  
        Vector3 escapeDirection = (transform.position - playerTransform.position).normalized;  
        // 设置逃离速度（比巡逻时更快）  
        float escapeSpeed = agent.speed * 2f; // 举例：两倍速度逃离  
        agent.speed = escapeSpeed;  
        agent.SetDestination(transform.position + escapeDirection * 10f); // 设置一个逃离目标点，距离可以根据需要调整  
  
        // 如果你想让敌人直接面向玩家并逃离，可以使用RotateTowards或其他方法  
    }  
  
    bool IsPlayerInVision()  
    {  
        // 计算玩家和敌人之间的向量  
        Vector3 directionToPlayer = playerTransform.position - transform.position;  
  
        // 确保方向向量不是零向量  
        if (directionToPlayer == Vector3.zero)  
            return false;  
  
        // 归一化方向向量  
        Vector3 directionUnit = directionToPlayer.normalized;  
  
        // 获取敌人的前方向量（Transform的forward）  
        Vector3 forward = transform.forward;  
  
        // 计算两个向量之间的夹角  
        float angle = Vector3.Angle(forward, directionUnit);  
  
        // 检查夹角是否在扇形内  
        if (angle <= visionAngle / 2) // 总角度除以二
        {  
            // 计算玩家和敌人之间的距离  
            float distance = Vector3.Distance(playerTransform.position, transform.position);  
  
            // 检查距离是否在半径内  
            if (distance <= visionRadius)  
                return true; // 玩家在视野内  
        }  
  
        return false; // 玩家不在视野内  
    }  
    
    IEnumerator RunAwayFromPlayer()  
    {  
        isRunningAway = true;  
        runAwayTimer = 0f;
        agent.speed = 2f;
  
        // 设置逃跑的目标位置为玩家的反方向  
        Vector3 runAwayTarget = transform.position - 
            (playerTransform.position - transform.position).normalized * 10f; // 乘以一个系数来增加距离  
        // 设置逃离速度（比巡逻时更快）  
        float escapeSpeed = agent.speed * 2f;
        agent.speed = escapeSpeed;  
        agent.SetDestination(runAwayTarget);  
  
        // 逃跑持续时间
        while (runAwayTimer < runAwayDuration)  
        {  
            runAwayTimer += Time.deltaTime;  
            yield return null;  
        }  
  
        // 停止逃跑，选择一个新的目标点  
        isRunningAway = false;  
        int randomIndex = Random.Range(0, wayPoints.childCount);  
        agent.SetDestination(wayPoints.GetChild(randomIndex).position);  
    }  
    
    // 开始逃跑  
    void StartFleeing()  
    { 
        isRunningAway = true;  
        runAwayTimer = 0f;  
    }  
  
    // 停止逃跑  
    void StopFleeing()  
    {  
        isRunningAway = false;  
        runAwayTimer = 0f;  
    }  
  
    // 移动到下一个巡逻点  
    void MoveToNextPatrolPoint()  
    {  
        // 切换到下一个巡逻点，如果到达最后一个，则回到第一个  
        currentPointIndex = (currentPointIndex + 1) % wayPoints.childCount;  
        StartCoroutine(MoveToPoint(wayPoints.GetChild(currentPointIndex).position));  
    }  
  
    // 协程来平滑移动到指定点  
    IEnumerator MoveToPoint(Vector3 targetPosition)  
    {  
        float duration = 2f; // 平滑移动持续时间  
        float elapsedTime = 0f;  
  
        Vector3 startPosition = transform.position;  
  
        while (elapsedTime < duration)  
        {  
            float t = elapsedTime / duration;  
            transform.position = Vector3.Lerp(startPosition, targetPosition, t);  
  
            elapsedTime += Time.deltaTime;  
            yield return null;  
        }  
  
        transform.position = targetPosition;  
    }  
}
