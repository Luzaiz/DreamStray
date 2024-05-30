using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisappearGround : MonoBehaviour
{
    [SerializeField]private Transform disappearGround;
    public GameObject groundPrefab;
    public float toHideTime;
    public float toShowTime;
    private void Start()
    {
        disappearGround = this.transform.GetChild(0);
        //InstantiateFloat();
    }

    /*给PlayerMgr子类调用*/
    public void StartHideTimer()
    {
        StartCoroutine(HideGround());
        Debug.Log("222");
    }

    IEnumerator HideGround()
    {
        yield return new WaitForSecondsRealtime(toHideTime);
        transform.GetComponent<BoxCollider>().enabled = false;
        if (disappearGround != null)  
        {  
            Destroy(disappearGround.gameObject);
            disappearGround = null;
        } 
        Invoke("InstantiateFloat",2);
        Debug.Log("1111");
    }

    void InstantiateFloat()
    {
        Vector3 currentEulerAngles = Vector3.zero;
        currentEulerAngles.y = 90;
        Quaternion newRotation = Quaternion.Euler(currentEulerAngles); 

        GameObject obj = Instantiate(groundPrefab, transform.position, Quaternion.identity);
        obj.transform.SetParent(transform);
        disappearGround = obj.transform;
        
        transform.GetComponent<BoxCollider>().enabled = true;
    }
}
