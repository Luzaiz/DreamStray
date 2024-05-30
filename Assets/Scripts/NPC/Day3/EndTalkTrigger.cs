using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndTalkTrigger : MonoBehaviour
{
    public EndTalkUI endTalkUI;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!endTalkUI)
        {
            Debug.LogError("没有配置结束对话UI");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            endTalkUI.isPlayEndTalk = true;
            PlayerMgr script = other.gameObject.GetComponent<PlayerMgr>();
            script.inputAllowed = false;
            script.animator.SetBool("Walk",false);
            script.animator.SetBool("Run",false);
            script.canNext = true;
            endTalkUI.gameObject.SetActive(true);
            gameObject.SetActive(false);
        }
    }
}
