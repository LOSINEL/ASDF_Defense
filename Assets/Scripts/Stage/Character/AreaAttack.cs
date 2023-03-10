using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaAttack : Weapon
{
    protected BoxCollider2D weaponCollider;

    private void Awake()
    {
        weaponCollider = GetComponent<BoxCollider2D>();
    }
}