using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class NpcTrigger : NpcMgr
{
    public Transform lookatTarget;
    
    [SerializeField]private Transform NpcTrans;
    [SerializeField]private bool isNearNPC = false;
    [SerializeField]private bool isRotateEnd = false;
    [SerializeField]private bool isStartDialog = false;
    private float angleSpeed = 0.01f;
    private Vector3 vec;
    private Quaternion rotate;

    private void Start()
    {
        NpcTrans = transform.parent;
    }

    private void Update()
    {
        if (isNearNPC && !isStartDialog)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                switchToCam.Priority = 50;
                player.GetComponent<PlayerMove>().inputAllowed = false;
                isStartDialog = true;
                tipsCanvas.SetActive(false);
                DialogMgr.isEndDialog = false;
                DialogMgr.Instance.Show(npcImg,npcName, contentList);
            }
        }
        
        if (isStartDialog)
        {
            vec = (lookatTarget.position - NpcTrans.position); 
            rotate = Quaternion.LookRotation(vec);
            if (Vector3.Angle(vec, NpcTrans.forward) < 0.1f)
            {
                isRotateEnd = true;
            }
            if (!isRotateEnd)
            {
                NpcTrans.localRotation = Quaternion.Slerp(NpcTrans.localRotation, rotate, angleSpeed);
            }
        }

        if (DialogMgr.isEndDialog)
        {
            Init();
        }
        
    }

    private void Init()
    {
        switchToCam.Priority = 0;
        player.GetComponent<PlayerMove>().inputAllowed = true;
        isRotateEnd = false;
        isStartDialog = false;
        NpcTrans = transform.parent;
        vec = Vector3.zero;
        rotate = Quaternion.identity;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag=="Player")
        {
            player = other.gameObject;
            tipsCanvas.SetActive(true);
            isNearNPC = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        tipsCanvas.SetActive(false);
        isNearNPC = false;
        isRotateEnd = false;
        isStartDialog = false;
    }
}
