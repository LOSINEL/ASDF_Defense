using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "Enemy", menuName = "Enemy")]
public class EnemyData : ScriptableObject
{
    [SerializeField] GameObject enemy;

    [SerializeField] float damage;
    [SerializeField] float maxHp;
    [SerializeField] float moveSpeed;
    [SerializeField] float attackSpeed;
    [SerializeField] float recoverManaNum;


    public GameObject Enemy { get { return enemy; } }
    public float MoveSpeed { get { return -moveSpeed; } }
    public float AttackSpeed { get { return attackSpeed; } }
    public float Damage { get { return damage; } }
    public float MaxHp { get { return maxHp; } }
    public float RecoverManaNum { get { return recoverManaNum; } }
}