using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    public BasePanel tipsPanel;

    private bool isNearDoor = false;
    private bool isOpenDoor = false;

    private Animator doorAnim;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.transform.localEulerAngles = new Vector3(0, -90, 0);
        doorAnim = transform.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isNearDoor)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                isNearDoor = false;
                isOpenDoor = true;
                doorAnim.enabled = true;
                UIManager.Instance.ClosePanel(UIConst.DoorTipsPanel);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!isOpenDoor && other.tag=="Player")
        {
            isNearDoor = true;
            if (!tipsPanel)
            {
                tipsPanel = UIManager.Instance.OpenPanel(UIConst.DoorTipsPanel) as BasePanel;
                
            }
            else
            {
                tipsPanel.gameObject.SetActive(true);
            }
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (tipsPanel)
        {
            tipsPanel.gameObject.SetActive(false);
            isNearDoor = false;
        }
    }
}
