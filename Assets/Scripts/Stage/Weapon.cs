using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] protected float damage;

    public void SetDamage(float _damage)
    {
        damage = _damage;
    }
}