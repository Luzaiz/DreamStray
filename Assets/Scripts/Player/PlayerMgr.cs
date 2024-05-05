using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMgr : MonoBehaviour
{
    public float walkSpeed; // 走路速度
    public float runSpeed; // 跑步速度
    [HideInInspector]public CharacterController controller; // 
    [HideInInspector]public Animator animator; // 动画 
    public Transform cam;
    public bool inputAllowed = true;
    
    //重力相关  
    public float Gravity = -9.8f;
    public Vector3 Velocity = Vector3.zero;
    public Transform GroundCheck;
    public float CheckRadious = 0.2f;
    public bool IsGround;
    public LayerMask layerMask;
    
    public float turnSmoothTime = 0.1f;
    public float turnSmoothVelocity;
    
    // [HideInInspector]隐藏public
    // [SerializeField]显示private
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void mymove()
    {
        IsGround = Physics.CheckSphere(GroundCheck.position, CheckRadious, layerMask);
        if (IsGround && Velocity.y < 0)
        {
            Velocity.y = 0;
        }
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;
        
        if (horizontal != 0 || vertical != 0 )
            //if (horizontal >= 0.5f || vertical >= 0.5f)
        {
            if (direction.magnitude>=0.3f)
            {
                float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
                float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, 
                    ref turnSmoothVelocity,turnSmoothTime);//平滑跟随摄像机
                transform.rotation = Quaternion.Euler(0f, angle, 0f);

                Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
                controller.Move(moveDir.normalized * walkSpeed * Time.deltaTime);
                animator.SetBool("Walk", true);
            }
        }
        else
        {
            animator.SetBool("Walk", false);
        }
        Velocity.y += Gravity * Time.deltaTime;
        controller.Move(Velocity * Time.deltaTime);//重力
    }

    public void myGravity()
    {
        IsGround = Physics.CheckSphere(GroundCheck.position, CheckRadious, layerMask);
        if (IsGround && Velocity.y < 0)
        {
            Velocity.y = 0;
        }
        Velocity.y += Gravity * Time.deltaTime;
        controller.Move(Velocity * Time.deltaTime);//重力
    }
}
