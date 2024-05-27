using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.UIElements;
using TMPro; // 引入TextMesh Pro的命名空间 

public class SaipaoTrigger : NpcMgr
{
    [SerializeField]private Transform NpcTrans;
    [SerializeField]private bool isNearNPC = false;
    [SerializeField]private bool isRotateEnd = false;
    [SerializeField]private bool isStartDialog = false;
    private float angleSpeed = 0.01f;
    private Vector3 vec;
    private Quaternion rotate;

    public GameObject maskUI;
    public CinemachineVirtualCameraBase switchToCam2;
    public TMP_Text countdownText;
    private bool isSaiPao = false;
    private void Start()
    {
        NpcTrans = transform.parent;
        countdownText.gameObject.SetActive(false);
        //isSaiPao = player.GetComponent<PlayerSix>().isSaipao;
    }

    private void Update()
    {
        if (isNearNPC)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                switchToCam.Priority = 50; // 相机权重
                player.GetComponent<PlayerSix>().inputAllowed = false;
                player.GetComponent<PlayerSix>().animator.SetBool("Walk", false);
                tipsCanvas.SetActive(false);
                DialogMgr.isEndDialog = false;
                DialogMgr.Instance.Show(npcImg,npcName, contentList);
            }
        }

        if (DialogMgr.isEndDialog)
        {
            DialogMgr.isEndDialog = false;
            Init();
            maskUI.SetActive(true);
            maskUI.GetComponent<FadeInOut>().StartFadeOut();
            StartCoroutine(WaitAndDoSomething());
            //StartCoroutine(Countdown());
        }
        
    }
    
    IEnumerator WaitAndDoSomething()  
    {
        yield return new WaitForSeconds(2f); // 等待两秒
        // 两秒后执行的代码  
        BeginRun();
        maskUI.GetComponent<FadeInOut>().StartFadeIn();
        yield return new WaitForSeconds(2f);
        countdownText.gameObject.SetActive(true);
        StartCoroutine(Countdown());
    }  
    
    IEnumerator Countdown()  
    {
        for (int i = 3; i >= 0; i--)  
        {  
            countdownText.text = i.ToString(); // 更新Text组件的文本  
            yield return new WaitForSeconds(1f); // 等待1秒  
        }  
        countdownText.gameObject.SetActive(false);
        // 倒计时结束后可以执行的操作   
        Debug.Log("倒计时结束");  
        player.GetComponent<PlayerSix>().isSaipao = true;
        isSaiPao = true;
    }  

    private void BeginRun()
    {
        PlayerSix playerScript = player.GetComponent<PlayerSix>();
        BadMan badmanScript = NpcTrans.GetComponent<BadMan>();
        player.transform.position = playerScript.startRunTrans.position;
        player.transform.rotation = playerScript.startRunTrans.rotation;
        Physics.autoSyncTransforms = true;
        NpcTrans.position = badmanScript.startTrans.position;
        NpcTrans.rotation = badmanScript.startTrans.rotation;
        //NpcTrans.GetComponent<Animator>().
        switchToCam2.Priority = 60;
    }

    private void Init()
    {
        switchToCam.Priority = 0;
        player.GetComponent<PlayerSix>().inputAllowed = true;
        isRotateEnd = false;
        isStartDialog = false;
        NpcTrans = transform.parent;
        vec = Vector3.zero;
        rotate = Quaternion.identity;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!isSaiPao && other.tag=="Player")
        {
            player = other.gameObject.GetComponent<PlayerMgr>();
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
