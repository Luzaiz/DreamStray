using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;

public class zzPlayerMove : MonoBehaviour
{
    private NavMeshAgent playerAgent;
    
    // Start is called before the first frame update
    void Start()
    {
        playerAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        //EventSystem.current获取到canvas的EventSystem上的EventSystem组件，判断是否点在UI Object上
        if (Input.GetMouseButtonDown(0) && EventSystem.current.IsPointerOverGameObject()==false)
        {
            //向屏幕鼠标位置发射射线
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;//射线检测信息
            bool isCollide = Physics.Raycast(ray, out hit);
            if (isCollide)
            {
                if (hit.collider.tag == "Ground")
                {
                    playerAgent.stoppingDistance = 0;
                    playerAgent.SetDestination(hit.point);
                }else if (hit.collider.tag == "Interactable")
                {
                    hit.collider.GetComponent<InteractableObject>().OnClick(playerAgent);
                }
                
            }
        }
    }
}