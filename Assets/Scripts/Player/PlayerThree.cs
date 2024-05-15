using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerThree : PlayerMgr
{
    [SerializeField]private MovingPoint movingGround;
    // Start is called before the first frame update
    void Start()
    {
        animator = transform.GetComponent<Animator>();
        controller = transform.GetComponent<CharacterController>();
        groundCheck = transform.Find("GroundCheck").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (inputAllowed)
        {
            mymove();
        }
        if (movingGround != null)  
        {  
            movingGround.UpdatePlayerPosition(controller, transform);  
        }
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        movingGround = hit.transform.GetComponent<MovingPoint>();
    }
}
