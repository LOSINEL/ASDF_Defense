using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarriorWeapon : MonoBehaviour
{
    BoxCollider2D weaponCollider;
    Warrior warrior;

    private void Start()
    {
        weaponCollider = GetComponent<BoxCollider2D>();
        warrior = GetComponentInParent<Warrior>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            collision.GetComponent<EnemyCharacter>().GetDamage(warrior.Damage);
            weaponCollider.enabled = false;
        }
        if (collision.CompareTag("EnemyHome"))
        {
            collision.GetComponent<Home>().GetDamage(warrior.Damage);
            weaponCollider.enabled = false;
        }
    }
}