using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleAttack : MonoBehaviour
{
    [SerializeField] protected float damage;
    List<GameObject> enemies = new();
    
    protected List<GameObject> Enemies { get { return enemies; } }

    public void SetDamage(float _damage)
    {
        damage = _damage;
    }
}