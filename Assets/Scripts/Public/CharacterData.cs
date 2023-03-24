using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName ="Character",menuName ="Character")]
public class CharacterData : ScriptableObject
{
    [SerializeField] Sprite[] portraits;
    float damage;
    float maxHp;
    float moveSpeed;
    float attackSpeed;
    [SerializeField] float summonCost;
    [SerializeField] float summonCoolTime;
    [SerializeField] float superSummonCost;

    [SerializeField] int upgradeCost;
    [SerializeField] float upgradePower;

    [SerializeField] Enums.CHAR_TYPE charType;

    [SerializeField] float baseDamage;
    [SerializeField] float baseMaxHp;
    [SerializeField] float baseMoveSpeed;
    [SerializeField] float baseAttackSpeed;

    [SerializeField] int level = 0;

    public Sprite[] Portraits { get { return portraits; } }
    public float MoveSpeed { get { return moveSpeed; } }
    public float AttackSpeed { get { return attackSpeed; } }
    public float Damage { get { return damage; } }
    public float MaxHp { get { return maxHp; } }
    public float SummonCost { get { return summonCost; } }
    public float SummonCoolTime { get { return summonCoolTime; } }
    public float SuperSummonCost { get { return superSummonCost; } }
    public int UpgradeCost { get { return upgradeCost; } }
    public float UpgradePower { get { return upgradePower; } }

    public Enums.CHAR_TYPE CharType { get { return charType; } }

    public float BaseDamage { get { return baseDamage; } }
    public float BaseMaxHp { get { return baseMaxHp; } }
    public float BaseMoveSpeed { get { return baseMoveSpeed; } }
    public float BaseAttackSpeed { get { return baseAttackSpeed; } }

    public int Level { get { return level; } }

    public void InitStat(int _level)
    {
        level = _level;
        SetStat();
    }

    public void Upgrade()
    {
        level++;
        damage = baseDamage * (upgradePower * level + 1);
        maxHp = baseMaxHp * (upgradePower * level + 1);
        moveSpeed = baseMoveSpeed * (upgradePower * level + 1);
        attackSpeed = baseAttackSpeed * (upgradePower * level + 1);
    }

    void SetStat()
    {
        damage = baseDamage * (1 + level * upgradePower);
        maxHp = baseMaxHp * (1 + level * upgradePower);
        moveSpeed = baseMoveSpeed * (1 + level * upgradePower);
        attackSpeed = baseAttackSpeed * (1 + level * upgradePower);
    }
}