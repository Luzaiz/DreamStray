using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSix : PlayerMgr
{
    public bool isSaipao = false;
    public Transform startRunTrans;
    
    private bool isRunning = false; // 是否正在跑动  
    private float stopDeceleration = 0.1f;
    [SerializeField]private float velocity = 0f; // 当前速度 
    // Start is called before the first frame update
    void Start()
    {
        animator = transform.GetComponent<Animator>();
        controller = transform.GetComponent<CharacterController>();
        runSpeed = 5f;
        stopDeceleration = 0.1f;
    }

    // Update is called once per frame
    void Update()  
    {
        if (inputAllowed && !isSaipao)
        {
            mymove();
        }
        else if(isSaipao)
        {
            myGravity();
            // 检查F键是否被按下  
            if (Input.GetKey(KeyCode.F))  
            {  
                // 如果F键被按下，则使角色向前移动  
                MoveForward();  
            }  
            else
            {  
                // 如果F键没有被按下，则停止角色的移动  
                StopMoving();  
            }  
            controller.Move(-Vector3.forward * velocity * Time.deltaTime);
        }
        
    }
    
    public void MoveForward()  
    {  
        isRunning = true; 
        // 使用Transform的Translate方法来移动角色  
        // 注意：Transform.Translate方法默认是在世界空间坐标系下移动的  
        // 如果你想要基于角色的局部坐标系移动，可以传入Space.Self作为第二个参数  
        animator.SetBool("Run", true);
        velocity = runSpeed;
        //controller.Move(-velocity * Time.deltaTime);
        //controller.Move(-Vector3.forward * runSpeed * Time.deltaTime);
        //transform.Translate(Vector3.forward * this.Speed * Time.deltaTime);  
    }  
  
    public void StopMoving()  
    {  
        if (isRunning && velocity > 0f)  
        {  
            velocity -=  stopDeceleration;  
            if (velocity < 0.1f) // 接近停止时设置为完全停止  
            {  
                velocity = 0f;  
                isRunning = false; // 设置为非跑动状态  
            }  
        } 
        //controller.Move(velocity * Time.deltaTime);
        // 在这个简单的例子中，我们实际上不需要做任何特殊的操作来停止移动  
        // 因为如果没有额外的力或代码使角色移动，它自然会停止  
        // 但如果你有其他移动代码（如物理模拟），你可能需要在这里重置速度或力  
        animator.SetBool("Run", false);
    }  
}
