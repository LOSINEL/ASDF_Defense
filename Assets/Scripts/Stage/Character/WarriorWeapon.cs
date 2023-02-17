using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarriorWeapon : MonoBehaviour
{
    BoxCollider2D weaponCollider;
    float damage;
    private void Start()
    {
        weaponCollider = GetComponent<BoxCollider2D>();
        damage = transform.parent.GetComponent<PlayerCharacter>().Damage;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            collision.GetComponent<EnemyCharacter>().GetDamage(damage);
            weaponCollider.enabled = false;
        }
    }
}