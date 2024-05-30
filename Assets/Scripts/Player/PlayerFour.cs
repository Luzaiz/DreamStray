using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFour : PlayerMgr
{
    // Start is called before the first frame update
    void Start()
    {
        canNext = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (inputAllowed)
        {
            mymove(true,false,false);
        }
    }
}
