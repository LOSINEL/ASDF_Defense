using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicianWeapon : MonoBehaviour
{
    BoxCollider2D weaponCollider;
    float damage;
    private void Start()
    {
        weaponCollider = GetComponent<BoxCollider2D>();
        damage = GetComponentInParent<PlayerCharacter>().Damage;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            collision.GetComponent<EnemyCharacter>().GetDamage(damage);
            weaponCollider.enabled = false;
        }
        if (collision.CompareTag("EnemyHome"))
        {
            collision.GetComponent<Home>().GetDamage(damage);
            weaponCollider.enabled = false;
        }
    }
}