using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*暂时弃用*/
public class StickyPlatform : MonoBehaviour
{
    [SerializeField] private GameObject mycollision=null;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            mycollision = collision.gameObject.transform.parent.gameObject;
            mycollision.GetComponent<CharacterController>().Move((mycollision.transform.position-transform.position)*Time.deltaTime);
            //collision.gameObject.transform.parent.SetParent(transform);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.name == "Capsule")
        {
            //collision.gameObject.transform.parent.SetParent(null);
        }
    }
}
