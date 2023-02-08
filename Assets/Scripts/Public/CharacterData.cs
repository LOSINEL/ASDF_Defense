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
    [SerializeField] float summonCoolTime;
    [SerializeField] float superSummonCost;

    [SerializeField] Enums.CHAR_TYPE charType;

    public Sprite[] Portraits { get { return portraits; } }
    public float MoveSpeed { get { return moveSpeed; } }
    public float AttackSpeed { get { return attackSpeed; } }
    public float Damage { get { return damage; } }
    public float MaxHp { get { return maxHp; } }
    public float SummonCost { get { return summonCost; } }
    public float SummonCoolTime { get { return summonCoolTime; } }
    public float SuperSummonCost { get { return superSummonCost; } }

    public Enums.CHAR_TYPE CharType { get { return charType; } }
}