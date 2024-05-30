using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.UIElements;
using TMPro; // 引入TextMesh Pro的命名空间 

public class SaipaoTrigger : NpcDialogue
{
    public BasePanel maskPanel;
    public CinemachineVirtualCameraBase startGameCam;
    public TMP_Text countdownText;
    //private bool isSaiPao = false;
    private void Start()
    {
        player = null;
        NpcTrans = transform.parent;
        //isSaiPao = player.GetComponent<PlayerSix>().isSaipao;
    }

    public override void AfterEndDialog() 
    {
        base.AfterEndDialog();
        if (NextLevelTrigger)
        {
            NextLevelTrigger.SetActive(true);
            player.canNext = true;
        }
        GetComponent<CapsuleCollider>().enabled = false;
        maskPanel = UIManager.Instance.OpenPanel(UIConst.FadePanel);
        maskPanel.gameObject.GetComponentInChildren<FadeInOut>().StartFadeOut();
        StartCoroutine(WaitAndDoSomething());
    }
    IEnumerator WaitAndDoSomething()  
    {
        yield return new WaitForSeconds(2f); // 等待两秒
        player.inputAllowed = false;
        // 两秒后执行的代码  
        BeginRun();
        maskPanel.gameObject.GetComponentInChildren<FadeInOut>().StartFadeIn();
        yield return new WaitForSeconds(2f);
        UIManager.Instance.ClosePanel(UIConst.FadePanel);
        countdownText.gameObject.SetActive(true);
    }

    private void BeginRun()
    {
        PlayerSix playerScript = player.GetComponent<PlayerSix>();
        BadMan badmanScript = NpcTrans.GetComponent<BadMan>();
        playerScript.isTimer = true;
        playerScript.inputAllowed = false;
        playerScript.SetPos();
        Physics.autoSyncTransforms = true;
        badmanScript.SetPos();
        startGameCam.Priority = 60;
    }
    
    /*private void OnTriggerEnter(Collider other)
    {
        if (!isSaiPao && other.tag=="Player")
        {
            player = other.gameObject.GetComponent<PlayerMgr>();
            tipsCanvas.SetActive(true);
            isNearNPC = true;
        }
    }*/
}
