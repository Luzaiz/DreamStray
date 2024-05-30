using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSix : PlayerMgr
{
    public bool isSaipao = false;
    public bool isTimer = false; // 是否正在倒计时  
    public Transform startRunTrans;

    //按f相关
    public float baseSpeed = 1f; // 基础速度  
    public float maxSpeedBoost = 2f; // 最大速度提升  
    public float decayRate = 5f; // 速度衰减率  
    public float decayTimeThreshold = 0.2f; // 停止按键后多久开始衰减  
    private float currentSpeed = 0f;  
    private float lastPressTime = -Mathf.Infinity; 
    
    void Start()
    {
        runSpeed = 5f;
    }

    void Update()  
    {
        if (inputAllowed && !isSaipao)  //允许move且不在赛跑
        {
            mymove(false,false,false);
        }
        else if(isSaipao)  //在赛跑
        {
            myGravity();
            if (Input.GetKeyDown(KeyCode.F)) // 当F键被按下时  
            {  
                float currentTime = Time.time;  
                float timeDiff = currentTime - lastPressTime;  
  
                // 如果时间间隔小于阈值，则增加速度  
                if (timeDiff < decayTimeThreshold)  
                {  
                    // 使用反比例函数或线性函数来增加速度，这里使用反比例函数作为示例  
                    float speedBoost = 1f / timeDiff * (maxSpeedBoost - baseSpeed);  
                    currentSpeed = Mathf.Min(baseSpeed + speedBoost, maxSpeedBoost);  
                }  
                else  
                {  
                    // 如果时间间隔较大，则重置到基础速度（或者稍微低于基础速度以开始衰减）  
                    currentSpeed = baseSpeed;  
                }  
  
                // 更新上一次按下F键的时间  
                lastPressTime = currentTime;  
            }  
            else if (currentSpeed > 0f && Time.time - lastPressTime > decayTimeThreshold)  
            {  
                // 如果长时间没有按键，则开始衰减速度  
                currentSpeed -= Time.deltaTime * decayRate;  
                currentSpeed = Mathf.Max(currentSpeed, 0f); // 确保速度不会低于0  
            }
            // 应用当前速度到角色移动  
            Vector3 move = Vector3.back * currentSpeed * Time.deltaTime;  
            controller.Move(move);
            if (currentSpeed >= 1f)
            {
                animator.SetBool("SaiPao",true);
            }
            else
            {
                animator.SetBool("SaiPao",false);
            }
        }
        else //不允许move(被抓住时)//
        {
            animator.SetBool("Walk", false);
        }
    }

    /*被抓住后调用*/
    public void StopMoving()  
    {  
            currentSpeed = 0f;  
            animator.SetBool("SaiPao", false);
            isSaipao = false; // 设置为非跑动状态 
            isTimer = true;
    }  
    
    public void SetPos()
    {
        transform.position = startRunTrans.position;
        transform.rotation = startRunTrans.rotation;
    }
}
