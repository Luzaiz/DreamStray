 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 using UnityEngine.SceneManagement;
 using UnityEngine.UI;

 public class PausePanel : BasePanel
 {
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void onBackBtnClick()  
    {  
        Debug.Log("backBtn clicked!");  
        ClosePanel();
        Time.timeScale = 1f;
    }  
    public void onNewGameBtnClick()  
    {  
        Debug.Log("newGameBtn clicked!");  
        SceneManager.LoadScene("Start");
    }  
    public void onSettingBtnClick()  
    {  
        Debug.Log("settingBtn clicked!");
        UIManager.Instance.OpenPanel(UIConst.SettingPanel);
    }  
}
