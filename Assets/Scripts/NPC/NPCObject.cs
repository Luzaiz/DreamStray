using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.UI;

public class NPCObject : MonoBehaviour
{
    public Sprite npcImg;
    public string npcName;
    public string[] contentList;
    public CinemachineVirtualCameraBase switchToCam; 
    [SerializeField]private PlayerMove playerCtr=null;

    [SerializeField]private bool isNearNPC = false;
    public GameObject tipsCanvas;

    public float angleSpeed = 0.01f;
    public Transform lookatTarget;
    [SerializeField]private bool isRotateEnd = false;
    private Vector3 vec;
    private Quaternion rotate;
    [SerializeField]private bool isStartDialog = false;

    private void Start()
    {
        //Init_Rotate();
    }

    private void Update()
    {
        if (isNearNPC && !isStartDialog)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                switchToCam.Priority = 50;
                playerCtr.inputAllowed = false;
                isStartDialog = true;
                tipsCanvas.SetActive(false);
                DialogMgr.Instance.Show(npcImg,npcName, contentList);
            }
        }
        
        if (isStartDialog)
        {
            vec = (lookatTarget.position - transform.position); 
            rotate = Quaternion.LookRotation(vec);
            if (Vector3.Angle(vec, transform.forward) < 0.1f)
            {
                isRotateEnd = true;
            }
            if (!isRotateEnd)
            {
                transform.localRotation = Quaternion.Slerp(transform.localRotation, rotate, angleSpeed);
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
        playerCtr.inputAllowed = true;
        //isNearNPC = false;
        isRotateEnd = false;
        isStartDialog = false;
        //playerCtr = null;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag=="Player")
        {
            playerCtr = other.GetComponent<PlayerMove>();
            tipsCanvas.SetActive(true);
            isNearNPC = true;
            //DialogMgr.Instance.Show(npcName, contentList);
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
