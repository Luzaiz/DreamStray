using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScytheWeapon : Weapon
{
    public const string ANIM_PARM_ISATTACK = "isAttack";

    private Animator anim;

    public int atkValue = 50;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            this.Attack();
        }
    }
    public override void Attack()
    {
        anim.SetTrigger(ANIM_PARM_ISATTACK);
    }

    private void OnTriggerEnter(Collider other)
    {
        //Tag.ENEMY
        if (other.tag == "Enemy")
        {
            //other.GetComponent<Enemy>().TakeDamage(atkValue);
            print("trigger with " + other.name);
        }
    }
}
