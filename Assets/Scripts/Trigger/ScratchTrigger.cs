using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScratchTrigger : MonoBehaviour
{
    public BasePanel tipsPanel;
    private bool isNear = false;
    [SerializeField]private Animator scratchAnim;
    // Start is called before the first frame update
    void Start()
    {
        scratchAnim = GameObject.Find("DreamCat").GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isNear)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                isNear = false;
                UIManager.Instance.ClosePanel(UIConst.ScratchTipsPanel);
                scratchAnim.SetTrigger("Scratch");
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag=="Player")
        {
            isNear = true;
            if (!tipsPanel)
            {
                tipsPanel = UIManager.Instance.OpenPanel(UIConst.ScratchTipsPanel) as BasePanel;
                
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
            isNear = false;
        }
    }
}