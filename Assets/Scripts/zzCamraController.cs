using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zzCamraController : MonoBehaviour
{
    public float zoomSpeed = 10;//滚轮缩放速度
    private Vector3 offset;
    private Transform playerTransform;
    
    // Start is called before the first frame update
    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        offset = transform.position - playerTransform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = playerTransform.position + offset;

        float scroll = Input.GetAxis("Mouse ScrollWheel");

        Camera.main.fieldOfView += scroll*zoomSpeed;//鼠标滚轮（Camera.main只适用于只有一个摄像机）

        Camera.main.fieldOfView = Mathf.Clamp(Camera.main.fieldOfView, 37, 70);
    }
}
