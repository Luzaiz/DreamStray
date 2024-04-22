using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class MiaoTrigger : MonoBehaviour
{
    public GameObject miaoCanvas;
    public GameObject animobj;
    public GameObject playerObj;

    private PlayerMove playerCtr;
    
    //public GameObject cartToMove;//PathObject，这是一个Dolly Track
    public CinemachineVirtualCameraBase switchToCam; //Camera
    //public CinemachinePathBase.PositionUnits positionUnits = CinemachinePathBase.PositionUnits.Distance;
    //public float speed = 5f;
 
    //private CinemachineDollyCart dCartComp;
    void Start()
    {
        playerCtr = playerObj.GetComponent<PlayerMove>();
    }
 
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && switchToCam )
        {
            if (Camera.main.GetComponent<CinemachineBrain>().ActiveVirtualCamera.Name != switchToCam.Name)
            {
                //dCartComp.m_PositionUnits = positionUnits;
                //dCartComp.m_Speed = speed;
 
                switchToCam.VirtualCameraGameObject.SetActive(false); //先禁用再启用，得到切换效果
                switchToCam.VirtualCameraGameObject.SetActive(true);     
                miaoCanvas.SetActive(true);
                Invoke("dosomething",2f);
                playerCtr.inputAllowed = false;
            }
        }
    }
 
    /*void OnTriggerExit(Collider col)
    {
        if (col.CompareTag("Player") && switchToCam != null && cartToMove)
        {
            dCartComp.m_Speed = 0f;
            switchToCam.VirtualCameraGameObject.SetActive(false);
        }
    }*/
    /*private void OnTriggerEnter(Collider other)
    {
        if (other.tag=="Player")
        {
            miaoCanvas.SetActive(true);
            Invoke("dosomething",2f);
        }
    }*/

    private void dosomething()
    {
        animobj.GetComponent<Animator>().SetBool("isAnim 0",true);
    }
}
