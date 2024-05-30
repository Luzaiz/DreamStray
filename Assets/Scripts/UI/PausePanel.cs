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
        ClosePanel();
        Time.timeScale = 1f;
    }  
    public void onNewGameBtnClick()  
    {
        Time.timeScale = 1f;
        UIManager.Instance.ClosePanel(UIConst.PausePanel);
        SceneManager.LoadScene("Start");
    }  
    public void onSettingBtnClick()  
    {
        SettingPanel panel = UIManager.Instance.OpenPanel(UIConst.SettingPanel) as SettingPanel;
        panel.UpdatePannelInfo();
    }  
}
