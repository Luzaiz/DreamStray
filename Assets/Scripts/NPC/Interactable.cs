using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    private UnityEngine.AI.NavMeshAgent playerAgent;
    private bool haveInteracted = false;//是否交互过

    public void OnClick(UnityEngine.AI.NavMeshAgent playerAgent)
    {
        this.playerAgent = playerAgent;
        playerAgent.stoppingDistance = 2;//移动停止时的距离（会受加速度从v减速到0的影响）
        playerAgent.SetDestination(transform.position);
        haveInteracted = false;
        //Interact();
    }

    private void Update()
    {
        //pathPending：计算可行路径
        if( playerAgent != null && haveInteracted == false && playerAgent.pathPending == false)
        {
            //距离目标剩余位置
            if (playerAgent.remainingDistance <= 2 )
            {
                Interact();
                haveInteracted = true;
            }
        }
    }

    //调试
    protected virtual void Interact()
    {
        print("Interacting with Interactable Object.");
    }
}
