using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour  
{  
    public Transform target; // 你要跟随的目标（通常是角色）  
    public Vector3 offset; // 摄像机相对于目标的偏移量  
  
    private void LateUpdate()  
    {  
        // 确保目标已经设置  
        if (target == null)  
        {  
            Debug.LogError("请设置一个目标给摄像机跟随");  
            return;  
        }  
  
        // 设置摄像机的位置为目标的位置加上偏移量  
        transform.position = target.position + offset;  
  
        // 注意：这里我们没有改变摄像机的旋转，所以它将保持自己的角度  
    }  
}
