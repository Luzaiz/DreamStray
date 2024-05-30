using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;

public class EndTalkUI : MonoBehaviour
{
    public TextMeshProUGUI storyText; // 剧情文本  
    public List<string> storyList = new List<string>(); // 剧情文本列表  
    private int currentLineIndex = 0; // 当前显示的文本索引  
    [SerializeField]private GameObject player;
    public bool isPlayEndTalk = false;
    public GameObject NextTrigger;
    // Start is called before the first frame update
    void Start()  
    {  
        player = GameObject.Find("DreamCat");
        //player.GetComponent<PlayerMgr>().inputAllowed = false;
        //gameObject.SetActive(false);
    }

    private void Update()
    {
        if (!NextTrigger)
        {
            Debug.LogError("没有配置下一关触发器");
        }

        if (isPlayEndTalk)
        {
            isPlayEndTalk = false;
            UpdateStoryText(); 
            StartCoroutine(PlayStoryAutomatically());  // 自动播放剧情 
        }
    }

    // 显示下一句剧情文本  
    public void ShowNextStoryLine()  
    {  
        currentLineIndex++;  
        if (currentLineIndex < storyList.Count)  
        {  
            UpdateStoryText();  
        }  
        else  
        {  
            CloseInterface();  
        }  
    }  
      
    private void UpdateStoryText()  
    {
        if (storyList.Count == 0)
        {
            Debug.LogError("读白文字列表没有配置");
        }
        else
        {
            //storyText.text = storyList[currentLineIndex];
            DOTween.To(() => 0, AddChar, storyList[currentLineIndex].Length,
                storyList[currentLineIndex].Length * 0.1f).SetEase(Ease.Linear);
        }
    }

    void AddChar(int index)
    {
        storyText.text = storyList[currentLineIndex].Substring(0, index);
    }  
    
    private void CloseInterface()  
    {
        gameObject.SetActive(false);
        player.GetComponent<PlayerMgr>().inputAllowed = true;
    }
    
    IEnumerator PlayStoryAutomatically()  
    {  
        while (currentLineIndex < storyList.Count)  
        {  
            UpdateStoryText();  
            yield return new WaitForSeconds(3f); 
            ShowNextStoryLine();  
        }  
        yield return new WaitForSeconds(1f);
        NextTrigger.SetActive(true);
        CloseInterface();  
    }
}
