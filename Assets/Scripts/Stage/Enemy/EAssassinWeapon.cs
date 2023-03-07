using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EAssassinWeapon : SingleAttack
{
    BoxCollider2D weaponCollider;

    private void Start()
    {
        weaponCollider = GetComponent<BoxCollider2D>();
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

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Character"))
        {
            Enemies.Remove(collision.gameObject);
        }
    }
}