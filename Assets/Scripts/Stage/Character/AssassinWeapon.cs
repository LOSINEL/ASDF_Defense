using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssassinWeapon : SingleAttack
{
    private void Start()
    {
        damage = GetComponentInParent<Assassin>().Damage;
    }

    private void Update()
    {
        if (Enemies.Count > 0)
        {
            Enemies[0].GetComponent<Hp>().SubHp(damage);
            weaponCollider.enabled = false;
            Enemies.Clear();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            Enemies.Add(collision.gameObject);
        }
    }
}