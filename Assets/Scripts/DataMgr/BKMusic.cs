using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BKMusic : MonoBehaviour
{
    private static BKMusic instance;
    public static BKMusic Instance => instance;

    private AudioSource audioSource;
    
    // Start is called before the first frame update
    void Awake()
    {
        instance = this;
        audioSource = this.GetComponent<AudioSource>();
        changeValue(GameDataMgr.Instance.musicData.musicValue);
        changeOpen(GameDataMgr.Instance.musicData.isOpenMusic);
    }

    public void changeValue(float value)
    {
        audioSource.volume = value;
    }

    public void changeOpen(bool isOpen)
    {
        //mute静音
        audioSource.mute = !isOpen;
    }
}