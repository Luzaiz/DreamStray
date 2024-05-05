using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadMan : MonoBehaviour
{
    public float runSpeed;
    private float translation;
    private Animator animator;
    
    public Transform startTrans;
    public CharacterController controller;
    public PlayerSix player;
    // Start is called before the first frame update
    void Start()
    {
        controller = transform.GetComponent<CharacterController>();
        // controller.enabled = false;
        animator = transform.GetComponent<Animator>();
        playIdle();
    }

    // Update is called once per frame
    void Update()
    {
        if (player.isSaipao)
        {
            //GameObject trigger = GameObject.Find("SaiPaoTrigger");
            //trigger.GetComponent<BoxCollider>().enabled = false;
            playRun();
            //translation = runSpeed * Time.deltaTime;
            //transform.Translate(0, 0, translation); // 在Z方向上平移
            controller.Move(-Vector3.forward * runSpeed * Time.deltaTime);
        }
    }

    public void playIdle()
    {
        animator.SetBool("isRun", false);
    }
    
    public void playRun()
    {
        animator.SetBool("isRun", true);
    }
}
