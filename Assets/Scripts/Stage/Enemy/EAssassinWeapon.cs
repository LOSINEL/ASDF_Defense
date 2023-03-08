using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EAssassinWeapon : SingleAttack
{
    private void Start()
    {
        damage = GetComponentInParent<EAssassin>().Damage;
    }

    private void Update()
    {
        if (Enemies.Count > 0)
        {
            Enemies[0].GetComponent<Hp>().SubHp(damage);
            weaponCollider.enabled = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Character"))
        {
            Enemies.Add(collision.gameObject);
        }
    }
}