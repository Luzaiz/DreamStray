using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartPanel : BasePanel
{
    public void onStartBtnClick()
    {
        SceneManager.LoadScene("Home");
    }
    public void onContinueBtnClick()
    {
        SceneManager.LoadScene("Day3");
    }
    public void onSettingBtnClick()
    {
        SettingPanel panel = UIManager.Instance.OpenPanel(UIConst.SettingPanel) as SettingPanel;
        panel.UpdatePannelInfo();
    }
}
