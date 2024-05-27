using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zzBasePannel<T> : MonoBehaviour where T:class
{
    //继承MonoBehaviour不能直接new()
    private static T instance;
    public static T Instance => instance;

    private void Awake()
    {
        //面板脚本在场景上只会挂载一次，所以在次脚本的生命周期函数的Awake中记录单例
        instance = this as T;
    }

    public virtual void ShowMe()
    {
        this.gameObject.SetActive(true);
    }
    
    public virtual void HideMe()
    {
        this.gameObject.SetActive(false);
    }
}