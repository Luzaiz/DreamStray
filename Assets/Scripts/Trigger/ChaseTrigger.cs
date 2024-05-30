using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; // 引入TextMesh Pro的命名空间 

public class ChaseTrigger : MonoBehaviour
{
    public BadMan badMan;
    private PlayerSix player;
    public TMP_Text countdownText;
    
    void Start()
    {
        player = transform.parent.GetComponent<PlayerSix>();
        if (!badMan)
        {
            Debug.LogError("ChaseTrigger没有配置坏人");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (player.isSaipao && other.tag == "BadMan")
        {
            //npc.GetComponent<BadMan>().controller.enabled = false;
            badMan.currentSpeed = 0;
            badMan.playIdle();
            player.isSaipao = false;
            player.StopMoving();
            UIManager.Instance.OpenPanel(UIConst.CatchFalledPanel);
            StartCoroutine(ReStartGame());
        }
    }

    IEnumerator ReStartGame()
    {
        yield return new WaitForSeconds(1);
        BasePanel fade = UIManager.Instance.OpenPanel(UIConst.FadePanel);
        fade.gameObject.GetComponentInChildren<FadeInOut>().StartFadeOut();
        yield return new WaitForSeconds(1);
        player.SetPos();
        Physics.autoSyncTransforms = true;
        badMan.SetPos();
        yield return new WaitForSeconds(0.6f);
        fade.GetComponentInChildren<FadeInOut>().StartFadeIn();
        yield return new WaitForSeconds(1f);
        UIManager.Instance.ClosePanel(UIConst.FadePanel);
        countdownText.gameObject.SetActive(true);
        //player.
    }
}
