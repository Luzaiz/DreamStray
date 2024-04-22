using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    public GameObject tipsCanvas;

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
                doorAnim.enabled = true;
                isOpenDoor = true;
                tipsCanvas.SetActive(false);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag=="Player" && !isOpenDoor)
        {
            tipsCanvas.SetActive(true);
            isNearDoor = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        tipsCanvas.SetActive(false);
        isNearDoor = false;
    }
}
