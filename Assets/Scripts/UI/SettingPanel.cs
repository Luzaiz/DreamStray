using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingPanel : BasePanel
{
    public Slider musicSlider;
    public CustomGUIToggle musicToggle;
    public Slider soundSlider;
    public CustomGUIToggle soundToggle;
    // Start is called before the first frame update
    void Start()
    {
        musicSlider.onValueChanged.AddListener(OnMusicSliderValueChanged); //监听滑动条事件
        soundSlider.onValueChanged.AddListener(OnSoundSliderValueChanged);
        musicToggle.changeValue += (value) => GameDataMgr.Instance.OpenOrCloseMusic(value);
        soundToggle.changeValue += (value) => GameDataMgr.Instance.OpenOrCloseSound(value);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void onCloseBtnClick()  
    {  
        Debug.Log("CloseBtn clicked!");
        ClosePanel();
    }
    
    void OnMusicSliderValueChanged(float value)
    {
        GameDataMgr.Instance.ChangeMusicValue(value);
    }
    void OnSoundSliderValueChanged(float value)
    {
        GameDataMgr.Instance.ChangeSoundValue(value);
    }
    public void UpdatePannelInfo()
    {
        MusicData data = GameDataMgr.Instance.musicData;
        musicSlider.value = data.musicValue;
        soundSlider.value = data.soundValue;
        musicToggle.isSel = data.isOpenMusic;
        soundToggle.isSel = data.isOpenSound;
    }
}
