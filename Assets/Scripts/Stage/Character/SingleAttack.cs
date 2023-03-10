using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleAttack : Weapon
{
    List<GameObject> enemies = new();
    protected BoxCollider2D weaponCollider;

    protected List<GameObject> Enemies { get { return enemies; } }

    private void Awake()
    {
        weaponCollider = GetComponent<BoxCollider2D>();
    }

    private void OnDisable()
    {
        enemies.Clear();
    }
}