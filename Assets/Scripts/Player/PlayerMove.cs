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
        groundCheck = transform.Find("GroundCheck").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (inputAllowed)
        {
            mymove();
        }
    }
}
