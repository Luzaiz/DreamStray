using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaiPaoEndTrigger : MonoBehaviour
{
    public GameObject who;
    private PlayerSix player;
    // Start is called before the first frame update
    void Start()
    {
        player = transform.parent.GetComponent<PlayerSix>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (player.isSaipao && other.tag == "BadMan")
        {
            who = other.gameObject;
            who.GetComponent<BadMan>().controller.enabled = false;
            player.isSaipao = false;
            player.StopMoving();
            //who.GetComponent<BadMan>().runSpeed = 0;
            who.GetComponent<BadMan>().playIdle();
        }
        
        /*if (other.tag == "BadMan")
        {
            who = other.gameObject;
        }*/
        
        //
    }
}
