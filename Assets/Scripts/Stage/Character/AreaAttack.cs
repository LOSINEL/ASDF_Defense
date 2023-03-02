using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaAttack : MonoBehaviour
{
    float damage;
    private void Start()
    {
        damage = GetComponentInParent<PlayerCharacter>().Damage;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            collision.GetComponent<Hp>().SubHp(damage);
        }
    }
}