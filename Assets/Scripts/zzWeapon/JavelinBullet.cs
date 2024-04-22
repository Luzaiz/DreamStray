using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JavelinBullet : MonoBehaviour
{
    public int atkValue = 30;
    private Rigidbody rgd;
    private Collider col;

    private void Start()
    {
        rgd = GetComponent<Rigidbody>();
        col = GetComponent<Collider>();
    }

    /// <summary>
    /// 当碰撞到物体时
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Player") { return; }

        rgd.velocity = Vector3.zero;
        rgd.isKinematic = true;
        col.enabled = false;

        //transform.parent = collision.gameObject.transform;

        Destroy(this.gameObject, 1f);

        if (collision.gameObject.tag == "Enemy")
        {
            //collision.gameObject.GetComponent<Enemy>().TakeDamage(atkValue); 
        }
    }

}
