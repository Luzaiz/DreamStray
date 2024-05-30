using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GamePanel : BasePanel
{
    public void onPauseBtnClick()  
    {  
        Time.timeScale = 0f;
        UIManager.Instance.OpenPanel(UIConst.PausePanel);
    }  
}
