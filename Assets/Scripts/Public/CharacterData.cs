using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName ="Character",menuName ="Character")]
public class CharacterData : ScriptableObject
{
    [SerializeField] Sprite[] portraits;
    [SerializeField] float moveSpeed;
    [SerializeField] float attackSpeed;
    [SerializeField] float damage;
    [SerializeField] float maxHp;
    [SerializeField] float summonCost;

    public Sprite[] Portraits { get { return portraits; } }
    public float MoveSpeed { get { return moveSpeed; } }
    public float AttackSpeed { get { return attackSpeed; } }
    public float Damage { get { return damage; } }
    public float MaxHp { get { return maxHp; } }
    public float SummonCost { get { return summonCost; } }
}