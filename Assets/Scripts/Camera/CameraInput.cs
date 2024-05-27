using System;
using UnityEngine;  
using Cinemachine;  
  
public class CameraInput : MonoBehaviour  
{  
    public CinemachineVirtualCamera virtualCamera; // 拖拽分配你的Cinemachine Virtual Camera  
    public bool isPaused = false; // 暂停状态变量  

    void Start()
    {
        
    }

    // 处理暂停按钮点击的方法（需要你自己实现或连接到按钮的点击事件）  
    public void TogglePause()  
    {  
        isPaused = !isPaused;  
    }  
  
    void Update()  
    {  
        if (isPaused)  
        {  
            // 暂停时禁用或修改Cinemachine的输入  
            // 方法1：禁用整个Cinemachine Virtual Camera（这将停止所有动画和输入）  
            virtualCamera.enabled = false;  
              
            // 方法2：只禁用特定的输入（如果你只想禁用鼠标输入而保留其他动画）  
            // 这需要你自己实现逻辑来修改或禁用输入映射  
            // 例如，你可以设置输入轴的值为0或禁用某个输入监听器  
              
            // 注意：方法2可能需要你更深入地了解Cinemachine的API和输入系统  
        }  
        else  
        {  
            // 恢复Cinemachine Virtual Camera的状态  
            virtualCamera.enabled = true;  
            // 如果之前禁用了特定的输入，现在需要恢复它们  
        }  
    }  
}