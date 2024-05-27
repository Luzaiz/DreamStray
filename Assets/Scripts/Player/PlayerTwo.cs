using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTwo : PlayerMgr
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
            mymove(true,false,false);
        }
        else
        {
            animator.SetBool("Walk", false);
            animator.SetBool("Run", false);
        }
    }
}
