/*
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueUI : MonoBehaviour
{
    //单例模式
    public static DialogueUI Instance { get; private set; }

    private TextMeshProUGUI nameText;
    private TextMeshProUGUI contentText;
    private Button continueBtn;

    private List<string> contentList;
    private int contentIndex = 0;

    private GameObject uiGameObject;

    private Action OnDialogueEnd;

    private void Awake()
    {
        //保护单例模式
        if(Instance!=null && Instance!=this)
        {
            Destroy(this.gameObject);return;
        }

        Instance = this;//单例模式
    }

    private void Start()
    {
        nameText = transform.Find("NameTextBG/NameText").GetComponent<TextMeshProUGUI>();
        contentText = transform.Find("ContentText").GetComponent<TextMeshProUGUI>();
        continueBtn = transform.Find("ContinueBtn").GetComponent<Button>();
        continueBtn.onClick.AddListener(this.OnContinueButtonClick);
        //uiGameObject = transform.Find("UI").gameObject;
        Hide();
    }

    public void Show()
    {
        gameObject.SetActive(true);
    }

    public void Show(string name,string[] content,Action OnDiagoueEnd=null)
    {
        nameText.text = name;
        contentList = new List<string>();
        contentList.AddRange(content);//AddRange把数组内容存放
        contentIndex = 0;
        contentText.text = contentList[0];
        gameObject.SetActive(true);
        //this.OnDialogueEnd = OnDiagoueEnd;
    }
     
    public void Hide()
    {
        gameObject.SetActive(false);
    }


    private void OnContinueButtonClick()
    {
        contentIndex++;
        //对话结束隐藏对话框
        if (contentIndex >= contentList.Count)
        {
            //OnDialogueEnd?.Invoke();
            Hide();return;
        }
        contentText.text = contentList[contentIndex];
        
    }
    
}
*/
