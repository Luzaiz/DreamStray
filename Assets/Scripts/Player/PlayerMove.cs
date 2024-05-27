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
        
    }

    // Update is called once per frame
    void Update()
    {
        if (inputAllowed)
        {
            mymove(true,true,true);
        }
        else
        {
            animator.SetBool("Walk", false);
        }
    }
}
