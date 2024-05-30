using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using Cinemachine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class NarrationMgr : MonoBehaviour
{
    public TextMeshProUGUI storyText; // 剧情文本  
    public List<string> storyList = new List<string>(); // 剧情文本列表  
    private int currentLineIndex = 0; // 当前显示的文本索引  
    public float waitTime = 3f;
    
    //可选属性
    [SerializeField]private GameObject player;
    public GameObject npc;
    private NpcPoint npcTip;
    public PlayableDirector playableDirector;
    public CinemachineVirtualCameraBase freeCamera;
    public bool isend = false;

    void Start()  
    {
        if (player)
        {
            player = GameObject.Find("DreamCat");
            player.GetComponent<PlayerMgr>().inputAllowed = false;
        }
        if (npc)
        {
            npcTip = npc.GetComponentInChildren<NpcPoint>();
            npcTip.Hide();
        }
        if(freeCamera) freeCamera.Priority = 5;
        UpdateStoryText();
        if (playableDirector) playableDirector.Play();
        StartCoroutine(PlayStoryAutomatically());  // 自动播放剧情 
    }  
    IEnumerator PlayStoryAutomatically() 
    { 
        while (currentLineIndex < storyList.Count) 
        { 
            UpdateStoryText(); 
            yield return new WaitForSeconds(waitTime); 
            ShowNextStoryLine();
        }  
        CloseInterface();  
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
            if (isend)
            {
                SceneManager.LoadScene("Start");
            }
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
        if(npc) npcTip.Show();
        if(player) player.GetComponent<PlayerMgr>().inputAllowed = true;
        if(freeCamera) freeCamera.Priority = 20;
        //Invoke("dosomething",2f);
    }
    /*void dosomething()
    {
        npcTip.Show();
        player.GetComponent<PlayerMgr>().inputAllowed = true;
        freeCamera.Priority = 20;
    }*/
    
    
}
