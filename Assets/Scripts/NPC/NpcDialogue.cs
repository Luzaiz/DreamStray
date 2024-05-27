using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class NpcDialogue : NpcMgr
{
    public NpcPoint pointUI;
    public Transform lookatTarget;
    public GameObject NextTrigger;
    
    [SerializeField]private Transform NpcTrans;
    [SerializeField]private bool isNearNPC = false;
    [SerializeField]private bool isRotateEnd = false;
    [SerializeField]private bool isStartDialog = false;
    public float angleSpeed = 0.02f;
    private Vector3 vec;
    private Quaternion rotate;

    private void Start()
    {
        player = null;
        NpcTrans = transform.parent;
    }

    private void Update()
    {
        if (isNearNPC && !isStartDialog)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if(pointUI) pointUI.Hide();
                switchToCam.Priority = 50;
                player.inputAllowed = false;
                isStartDialog = true;
                tipsCanvas.SetActive(false);
                //DialogMgr.isEndDialog = false;
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

        if (player)
        {
            if (DialogMgr.isEndDialog)
            {
                AfterEndDialog();
            }
        }
    }

    public virtual void AfterEndDialog()
    {
        switchToCam.Priority = 5;
        player.inputAllowed = true;
        isRotateEnd = false;
        isStartDialog = false;
        NpcTrans = transform.parent; //更新此时的trans，用于重复对话时候的转向
        vec = Vector3.zero;
        rotate = Quaternion.identity;
        DialogMgr.isEndDialog = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag=="Player")
        {
            player = other.gameObject.GetComponent<PlayerMgr>();
            tipsCanvas.SetActive(true);
            isNearNPC = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        player = null;
        tipsCanvas.SetActive(false);
        isNearNPC = false;
        isRotateEnd = false;
        isStartDialog = false;
    }
}
