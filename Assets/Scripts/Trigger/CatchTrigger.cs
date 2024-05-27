using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatchTrigger : MonoBehaviour
{
    public Transform day2Panel;
    public GameObject mouseMgr;
    // Start is called before the first frame update
    void Start()
    {
        GameObject canvas = GameObject.Find("Canvas");
        if (canvas != null)
        {
            day2Panel = canvas.transform.Find("Day2Panel");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!mouseMgr)
        {
            Debug.LogError("没有引用MouseMgr");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag=="Mouse")
        {
            Debug.Log("抓住啦！");
            day2Panel.GetComponent<Day2Panel>().addCatchCount();
            mouseMgr.GetComponent<SpawnMouse>().DeleteGameObject(other.gameObject);
        }
    }
}
