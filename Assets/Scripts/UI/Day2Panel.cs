using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Day2Panel : BasePanel
{
    public TextMeshProUGUI countLabel;
    [HideInInspector]public int nowCount = 0;
    public GameObject player;
    public float winCount;
    public GameObject dia2Trigger;
    public Farmer farmer;
    private bool hasExecuted = false;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("DreamCat").gameObject;
        countLabel.gameObject.SetActive(false);
        countLabel.text = nowCount.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (!hasExecuted && nowCount >= winCount)
        {
            hasExecuted = true;
            farmer.isStartGame = false;
            UIManager.Instance.OpenPanel(UIConst.CatchEndPanel);
            countLabel.gameObject.SetActive(false);
            dia2Trigger.SetActive(true);
        }
    }

    public void addCatchCount()
    {
        nowCount++;
        countLabel.text = nowCount.ToString();
    }
    
    public void onPauseBtnClick()  
    {  
        Time.timeScale = 0f;
        UIManager.Instance.OpenPanel(UIConst.PausePanel);
    }  
}
