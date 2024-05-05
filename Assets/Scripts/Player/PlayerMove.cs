using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMove : PlayerMgr
{
    // Start is called before the first frame update
    void Start()
    {
        controller = transform.GetComponent<CharacterController>();
        animator = transform.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (inputAllowed)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                animator.SetBool("Jump", true);
            }
            mymove();
        }
        else
        {
            animator.SetBool("Jump", false);
            animator.SetBool("Walk", false);
        }
        
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
}
