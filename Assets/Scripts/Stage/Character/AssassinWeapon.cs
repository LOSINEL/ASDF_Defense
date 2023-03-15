using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssassinWeapon : SingleAttack
{
    [SerializeField] int maxAttack;

    private void Start()
    {
        damage = GetComponentInParent<Assassin>().Damage;
    }

    private void Update()
    {
        if (Enemies.Count > 0)
        {
            for (int i = 0; i < Enemies.Count; i++)
            {
                if (i == maxAttack) break;
                Enemies[i].GetComponent<Hp>().SubHp(damage);
            }
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