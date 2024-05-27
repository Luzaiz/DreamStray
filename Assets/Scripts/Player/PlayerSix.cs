using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSix : PlayerMgr
{
    public bool isSaipao = false;
    public Transform startRunTrans;
    
    private bool isRunning = false; // 是否正在跑动  
    private float stopDeceleration = 0.1f;
    [SerializeField]private float nowVelocity = 0f; // 当前速度 
    // Start is called before the first frame update
    void Start()
    {
        runSpeed = 5f;
    }

    // Update is called once per frame
    void Update()  
    {
        if (inputAllowed && !isSaipao)
        {
            mymove(false,false,false);
        }
        else if(isSaipao)
        {
            myGravity();
            if (Input.GetKey(KeyCode.F))  
            {   
                MoveForward();  
            }  
            else
            {  
                StopMoving();  
            }  
            controller.Move(-Vector3.forward * nowVelocity * Time.deltaTime);
        }
        
    }
    
    public void MoveForward()  
    {  
        isRunning = true; // 设置为跑动状态 
        animator.SetBool("Run", true);
        nowVelocity = runSpeed;
        //controller.Move(-Vector3.forward * runSpeed * Time.deltaTime); 
    }  
  
    public void StopMoving()  
    {  
        if (isRunning && nowVelocity > 0f)  
        {  
            nowVelocity -=  stopDeceleration;  
            if (nowVelocity < 0.1f)  
            {  
                nowVelocity = 0f;  
                isRunning = false; // 设置为非跑动状态  
            }  
        } 
        //controller.Move(velocity * Time.deltaTime);
        animator.SetBool("Run", false);
    }  
}
