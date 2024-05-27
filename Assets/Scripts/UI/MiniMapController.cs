using System.Collections;  
using System.Collections.Generic;  
using UnityEngine;  
using UnityEngine.UI;

/*第四关迷你地图（暂时废弃）*/
public class MiniMapController : MonoBehaviour  
{  
    public Image playerMarker; // 玩家标记的Image组件  
    public Camera mainCamera; // 主摄像机  
    private RectTransform miniMapCanvasRectTransform; // 小地图Canvas的RectTransform组件  
    public Transform player;
  
    void Start()  
    {  
        miniMapCanvasRectTransform = GetComponentInParent<Canvas>().transform.Find("MiniMap").transform as RectTransform; // 假设脚本挂载在Canvas的子物体上  
    }  
  
    void Update()  
    {  
        // 假设你有一个表示玩家的Transform（例如PlayerController的transform）  
        Transform playerTransform = player;// 获取玩家的Transform，可能是某个游戏对象的属性或单例等  
        // 将玩家位置从世界空间转换为屏幕空间  
        Vector3 screenPosition = mainCamera.WorldToScreenPoint(playerTransform.position);  
  
        // 检查屏幕位置是否在摄像机视野内  
        if (screenPosition.z > 0 && screenPosition.x > 0 && screenPosition.x < Screen.width && screenPosition.y > 0 && screenPosition.y < Screen.height)  
        {  
            // 将屏幕位置转换为Canvas的局部空间  
            Vector2 localPosition;  
            if (RectTransformUtility.ScreenPointToLocalPointInRectangle(  
                    miniMapCanvasRectTransform,  
                    screenPosition,  
                    null,  
                    out localPosition))  
            {  
                // 根据小地图的大小和位置调整localPosition，确保红点在小地图内  
                localPosition.x = (localPosition.x / miniMapCanvasRectTransform.sizeDelta.x) * playerMarker.rectTransform.sizeDelta.x - playerMarker.rectTransform.sizeDelta.x / 2f;  
                localPosition.y = (localPosition.y / miniMapCanvasRectTransform.sizeDelta.y) * playerMarker.rectTransform.sizeDelta.y - playerMarker.rectTransform.sizeDelta.y / 2f;  
  
                // 设置玩家标记的位置  
                playerMarker.rectTransform.anchoredPosition = localPosition;  
            }  
        }  
    } 
}
