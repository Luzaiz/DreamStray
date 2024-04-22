using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JavelinWeapon : Weapon
{
    public float bulletSpeed;
    public GameObject bulletPrefab;
    private GameObject bulletGo;

    private void Start()
    {
        SpawnBullet();
    }


    public override void Attack()
    {
        if (bulletGo != null)
        {
            bulletGo.transform.parent = null;//发射时放在主场景下
            bulletGo.GetComponent<Rigidbody>().velocity = transform.forward * bulletSpeed;
            //bulletGo.GetComponent<Collider>().enabled = true;
            Destroy(bulletGo, 10);
            bulletGo = null;
            Invoke("SpawnBullet", 0.5f);//过一段时间再生成
        }
        else
        {
            return;
        }
    }

    /// <summary>
    /// 生成标枪方法
    /// </summary>
    private void SpawnBullet()
    {
        bulletGo = Instantiate(bulletPrefab, transform.position, transform.rotation);
        bulletGo.transform.parent = transform;//生成位置在角色上
        //bulletGo.GetComponent<Collider>().enabled = false;
        /*if (tag == Tag.INTERACTABLE)
        {
            Destroy(bulletGo.GetComponent<JavelinBullet>());

            bulletGo.tag = Tag.INTERACTABLE;
            PickableObject po= bulletGo.AddComponent<PickableObject>();
            po.itemSO = GetComponent<PickableObject>().itemSO;
            Rigidbody rgd = bulletGo.GetComponent<Rigidbody>();

            rgd.constraints = ~RigidbodyConstraints.FreezeAll;
            bulletGo.GetComponent<Collider>().enabled = true;
            bulletGo.transform.parent = null;
            Destroy(this.gameObject);
        }*/
    }
}