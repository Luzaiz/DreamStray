using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTwo : PlayerMgr
{
    // Start is called before the first frame update
    void Start()
    {
        animator = transform.GetComponent<Animator>();
        controller = transform.GetComponent<CharacterController>();
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
