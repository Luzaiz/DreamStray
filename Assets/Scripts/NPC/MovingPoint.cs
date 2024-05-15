using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPoint : MonoBehaviour
{
    [SerializeField]private GameObject[] waypoints;
    private int currentWaypointIndex = 0;
    [SerializeField] private float movingSpeed = 1f;
    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, waypoints[currentWaypointIndex].transform.position) < 0.1f)
        {
            currentWaypointIndex++;
            if (currentWaypointIndex>=waypoints.Length)
            {
                currentWaypointIndex = 0;
            }
        }
        transform.position = Vector3.MoveTowards(transform.position, 
            waypoints[currentWaypointIndex].transform.position, movingSpeed*Time.deltaTime);
    }
    
    public void UpdatePlayerPosition(CharacterController playerController, Transform playerTransform)  
    {
        // 计算玩家应该位于的新位置
        Vector3 newPosition = new Vector3(waypoints[currentWaypointIndex].transform.position.x,0,0);
        // 更新玩家的位置  
        playerController.Move(newPosition*Time.deltaTime*0.2f); //不确定为啥是0.2f 
    }
}
