using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
 
/*对话界面｛单例模式｝*/
public class DialogMgr : MonoBehaviour
{
    //单例模式
    public static DialogMgr Instance { get; private set; }
    public static bool isEndDialog = false;

    public Image npcImg;
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI contentText;
    public Button continueBtn;

    public List<string> contentList;
    private int contentIndex = 0;

    private GameObject uiGameObject;
    private Action OnDialogueEnd;

    private void Awake()
    {
        //保护单例模式
        if(Instance!=null && Instance!=this)
        {
            Destroy(this.gameObject);
            isEndDialog = false;
            return;
        }

        Instance = this;//单例模式
    }

    private void Start()
    {
        npcImg = GameObject.Find("NPCImage").GetComponent<Image>();
        nameText = GameObject.Find("NameText").GetComponent<TextMeshProUGUI>();
        contentText = GameObject.Find("DialogueText").GetComponent<TextMeshProUGUI>();
        continueBtn = transform.GetComponent<Button>();
        continueBtn.onClick.AddListener(this.OnContinueButtonClick);
        //uiGameObject = transform.Find("UI").gameObject;
        Hide();
    }

    public void Show()
    {
        gameObject.SetActive(true);
    }

    public void Show(Sprite img,string name,string[] content,Action OnDiagoueEnd=null)
    {
        npcImg.sprite = img;
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


    public void OnContinueButtonClick()
    {
        contentIndex++;
        //对话结束隐藏对话框
        if (contentIndex >= contentList.Count)
        {
            //OnDialogueEnd?.Invoke();
            isEndDialog = true;
            Hide();return;
        }
        contentText.text = contentList[contentIndex];
        
    }
}
