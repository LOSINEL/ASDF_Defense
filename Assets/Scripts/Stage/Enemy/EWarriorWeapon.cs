using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EWarriorWeapon : Weapon
{
    BoxCollider2D weaponCollider;

    private void Start()
    {
        weaponCollider = GetComponent<BoxCollider2D>();
        damage = GetComponentInParent<EWarrior>().Damage;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Character"))
        {
            collision.GetComponent<Hp>().SubHp(damage);
            weaponCollider.enabled = false;
        }
    }
}