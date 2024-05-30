using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; // 引入TextMesh Pro的命名空间 

public class CountDown : MonoBehaviour
{
    private TMP_Text countdownText;
    public PlayerSix player;
    private bool hasExecuted = false;
    // Start is called before the first frame update
    void Start()
    {
        if (!player)
        {
            player = GameObject.Find("DreamCat").GetComponent<PlayerSix>();
        }
        countdownText = GetComponent<TMP_Text>();
        //StartCoroutine(Countdown());
    }

    private void Update()
    {
        if (!hasExecuted && player.isTimer)
        {
            hasExecuted = true;
            StartCoroutine(Countdown());
        }
    }

    IEnumerator Countdown()  
    {
        for (int i = 3; i >= 0; i--)  
        {  
            countdownText.text = i.ToString(); // 更新Text组件的文本  
            yield return new WaitForSeconds(1f); // 等待1秒  
        }  
        player.GetComponent<PlayerSix>().isSaipao = true;
        countdownText.gameObject.SetActive(false);
        hasExecuted = false;
        // 倒计时结束后可以执行的操作   
        Debug.Log("倒计时结束");  
    }  
}
