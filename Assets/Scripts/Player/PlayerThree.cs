using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq; // 对于 ToArray() 扩展方法 

public class PlayerThree : PlayerMgr
{
    [SerializeField]private MoveGround movingGround;
    [SerializeField]private DisappearGround disappearGround;
    private bool hasExecuted = false;
    private HashSet<Collider> collidedColliders = new HashSet<Collider>();
    
    private List<Collider> lastOverlappingColliders = new List<Collider>();  
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (inputAllowed)
        {
            mymove(true,true,true);
        }
        if (movingGround != null)  
        {  
            movingGround.UpdatePlayerPosition(controller, transform);  
        }
        if (disappearGround != null && !hasExecuted)
        {
            hasExecuted = true;
            disappearGround.StartHideTimer();  
        }
        else if(disappearGround == null)
        {
            hasExecuted = false;
        }
        
        // 假设你有一个Transform变量叫做"boxTransform"，表示包围盒的位置和旋转  
        // 并且你有一个Vector3变量叫做"boxSize"，表示包围盒的大小  
        Vector3 boxSize = new Vector3(1f, 1f, 1f); // 示例大小  
        Transform boxTransform = this.transform; // 假设包围盒的Transform就是此脚本所在的GameObject的Transform  
  
        // 使用OverlapBox获取当前重叠的碰撞器  
        Collider[] overlappingColliders = Physics.OverlapBox(boxTransform.position, boxSize / 2f, 
            boxTransform.rotation, LayerMask.GetMask("Ground"));

        if (lastOverlappingColliders.Count != 0)
        {
            // 检测哪些碰撞器已经离开了包围盒  
            for (int i = lastOverlappingColliders.Count - 1; i >= 0; i--)  
            {  
                if (!ContainsCollider(overlappingColliders, lastOverlappingColliders[i]))  
                {  
                    // lastOverlappingColliders[i] 已经离开了包围盒，你可以在这里处理它  
                    if (lastOverlappingColliders[i] != null)
                    {
                        if (lastOverlappingColliders[i].CompareTag("MoveGround"))
                        {
                            lastOverlappingColliders.RemoveAt(i); // 从列表中移除它 
                            movingGround = null;
                        }
                        else if (lastOverlappingColliders[i].CompareTag("DisappearGround"))
                        {
                            lastOverlappingColliders.RemoveAt(i); // 从列表中移除它  
                            disappearGround = null;
                        }
                    }
                }  
            }
        
        }
        // 更新上一帧的碰撞器列表  
        lastOverlappingColliders.Clear();  
        lastOverlappingColliders.AddRange(overlappingColliders);  
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.collider.CompareTag("MoveGround"))
        {
            lastOverlappingColliders.Add(hit.collider);  
            movingGround = hit.transform.GetComponent<MoveGround>();
        }
        else if (hit.collider.CompareTag("DisappearGround"))
        {
            lastOverlappingColliders.Add(hit.collider); 
            disappearGround = hit.transform.GetComponent<DisappearGround>();
        }
    }
    
    // 检查一个Collider数组是否包含特定的Collider 
    private bool ContainsCollider(Collider[] colliders, Collider target)  
    {  
        foreach (Collider collider in colliders)  
        {  
            if (collider == target)  
            {  
                return true;  
            }  
        }  
        return false;  
    }  
    /*void FixedUpdate()  
    {  
        /*创建一个列表来存储上一帧检测到的碰撞器：你可以使用Collider[]数组或HashSet<Collider>来存储这些碰撞器。
        在每一帧中，使用Physics.OverlapBox获取当前重叠的碰撞器。
        比较当前帧和上一帧的碰撞器列表：找出哪些碰撞器在新列表中不存在（即它们已经离开了包围盒）。
        更新上一帧的碰撞器列表：用当前帧的碰撞器列表替换它，以便在下一帧中进行比较。#1#
        
        Vector3 size = controller.bounds.size; // 获取CharacterController的边界大小  
        Vector3 center = controller.transform.position; // 获取CharacterController的中心位置  
        // 使用Physics.OverlapBox来检测重叠的碰撞器  
        Collider[] colliders = Physics.OverlapBox(center, size / 2, controller.transform.rotation, 
            LayerMask.GetMask("Ground")); // 替换"YourLayer"为你的层名  
        foreach (var collider in collidedColliders.ToArray())  
        {  
            if (collider.CompareTag("MoveGround")) // 替换"YourLayer"为你的层名  
            {  
                // 如果碰撞器不再在重叠盒中，则视为“离开碰撞”  
                collidedColliders.Remove(collider);  
                Debug.Log("Collision Exited with: " + collider.name);
                movingGround = null;
                disappearGround = null;
            }  
        }
    } */
}
