using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*第六关与坏人交互，赛跑开始位置和动画*/
public class BadMan : MonoBehaviour
{
    public float runSpeed;
    public float currentSpeed;
    private float translation;
    [SerializeField]private Animator animator;
    
    public Transform startTrans;
    public CharacterController controller;
    public PlayerSix player;
    
    void Start()
    {
        currentSpeed = runSpeed;
        controller = transform.GetComponent<CharacterController>();
        // controller.enabled = false;
        animator = transform.Find("Model").GetComponent<Animator>();
        playIdle();
    }

    // Update is called once per frame
    void Update()
    {
        if (player.isSaipao)
        {
            currentSpeed = runSpeed;
            //GameObject trigger = GameObject.Find("SaiPaoTrigger");
            //trigger.GetComponent<BoxCollider>().enabled = false;
            playRun();
            //translation = runSpeed * Time.deltaTime;
            //transform.Translate(0, 0, translation); // 在Z方向上平移
            controller.Move(-Vector3.forward * currentSpeed * Time.deltaTime);
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

    public void SetPos()
    {
        transform.position = startTrans.position;
        transform.rotation = startTrans.rotation;
    }
}
