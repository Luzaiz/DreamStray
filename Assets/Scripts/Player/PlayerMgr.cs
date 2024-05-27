using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMgr : MonoBehaviour
{
    public float walkSpeed; // 走路速度
    public float runSpeed; // 跑步速度
    public float nowSpeed;
    public float jumpHeight; // 跳跃高度
    [HideInInspector]public CharacterController controller; 
    [HideInInspector]public Animator animator; 
    [SerializeField]private Transform cam;
    public bool inputAllowed = true;
    public bool canNext = false;
    
    //重力相关  
    public float gravity = -40f;
    private Vector3 velocity = Vector3.zero;
    [SerializeField]private Transform groundCheck;
    private float checkRadious = 0.2f;
    [SerializeField]private bool isGround;
    public LayerMask layerMask;
    
    private float turnSmoothTime = 0.1f;
    private float turnSmoothVelocity;
    
    // [HideInInspector]隐藏public
    // [SerializeField]显示private
    void Awake()
    {
        controller = transform.GetComponent<CharacterController>();
        animator = transform.GetComponent<Animator>();
        cam = GameObject.Find("Main Camera").transform;
        groundCheck = gameObject.transform.Find("GroundCheck").transform;
        nowSpeed = walkSpeed;
    }
    
    public void mymove(bool runBool,bool jumpBool,bool jumphighBool)
    {
        isGround = Physics.CheckSphere(groundCheck.position, checkRadious, layerMask);
        if (isGround && velocity.y < 0)
        {
            velocity.y = 0;
        }
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;
        //if (horizontal >= 0.5f || vertical >= 0.5f)
        if (horizontal != 0 || vertical != 0 )
        {
            if (direction.magnitude>=0.3f)
            {
                if (jumphighBool && Input.GetKeyDown(KeyCode.Space) && isGround)
                {
                    animator.SetTrigger("JumpFront");
                    velocity.y += Mathf.Sqrt(jumpHeight * -2f * gravity);
                }
                if (runBool && Input.GetKey(KeyCode.LeftShift))
                {
                    nowSpeed = runSpeed;
                    animator.SetBool("Run", true);
                }
                else
                {
                    nowSpeed = walkSpeed;
                    animator.SetBool("Run", false);
                }
                float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
                float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, 
                    ref turnSmoothVelocity,turnSmoothTime);//平滑跟随摄像机
                transform.rotation = Quaternion.Euler(0f, angle, 0f);

                Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
                controller.Move(moveDir.normalized * nowSpeed * Time.deltaTime);
                animator.SetBool("Walk", true);
            }
        }
        else
        {
            animator.SetBool("Walk", false);
        }
        if (jumpBool && horizontal == 0 && vertical == 0 && Input.GetKeyDown(KeyCode.Space) && isGround)
        {
            animator.SetTrigger("Jump");
            //velocity.y += Mathf.Sqrt(jumpHeight * -1f * gravity);
        }
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);//重力
    }

    public void myGravity()
    {
        isGround = Physics.CheckSphere(groundCheck.position, checkRadious, layerMask);
        if (isGround && velocity.y < 0)
        {
            velocity.y = 0;
        }
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);//重力
    }
}
