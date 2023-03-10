using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarriorWeapon : AreaAttack
{
    private void Start()
    {
        damage = GetComponentInParent<Warrior>().Damage;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            collision.GetComponent<Hp>().SubHp(damage);
            weaponCollider.enabled = false;
        }
    }
}