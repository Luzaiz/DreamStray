using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 游戏数据管理类 单例模式对象(声音信息，关卡)
/// </summary>
public class GameDataMgr
{
    private static GameDataMgr instance = new GameDataMgr();
    
    public static GameDataMgr Instance
    {
        get => instance; 
    }

    public MusicData musicData;
    
    private GameDataMgr()
    {
        //初始化游戏数据
        musicData = PlayerPrefsDataMgr.Instance.LoadData(typeof(MusicData), "Music") as MusicData;
        //如果是第一次进入游戏没有音效数据，初始化音量数据
        if ( !musicData.notFirst )
        {
            musicData.notFirst = true;
            musicData.isOpenMusic = true;
            musicData.isOpenSound = true;
            musicData.musicValue = 1;
            musicData.soundValue = 1;
            PlayerPrefsDataMgr.Instance.SaveData(musicData, "Music");
        }
    }

    public void OpenOrCloseMusic(bool isOpen)
    {
        musicData.isOpenMusic = isOpen;
        BKMusic.Instance.changeOpen(isOpen);
        PlayerPrefsDataMgr.Instance.SaveData(musicData, "Music");
    }
    
    public void OpenOrCloseSound(bool isOpen)
    {
        musicData.isOpenSound = isOpen;
        PlayerPrefsDataMgr.Instance.SaveData(musicData, "Music");
    }
    
    public void ChangeMusicValue(float value)
    {
        musicData.musicValue = value;
        BKMusic.Instance.changeValue(value);
        PlayerPrefsDataMgr.Instance.SaveData(musicData, "Music");
    }
    
    public void ChangeSoundValue(float value)
    {
        musicData.soundValue = value;
        PlayerPrefsDataMgr.Instance.SaveData(musicData, "Music");
    }
}
