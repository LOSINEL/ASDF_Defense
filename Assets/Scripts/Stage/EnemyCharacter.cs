using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCharacter : MonoBehaviour
{
    [SerializeField] EnemyData enemyData;
    [SerializeField] float moveSpeed;
    [SerializeField] float attackSpeed;
    [SerializeField] float damage;
    [SerializeField] float nowHp;
    [SerializeField] float maxHp;
    [SerializeField] float recoverManaNum;
    [SerializeField] bool isEnemyChecked;

    Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
        InitStat();
    }

    void InitStat()
    {
        moveSpeed = enemyData.MoveSpeed;
        attackSpeed = enemyData.AttackSpeed;
        damage = enemyData.Damage;
        maxHp = nowHp = enemyData.MaxHp;
        recoverManaNum = enemyData.RecoverManaNum;
        isEnemyChecked = false;
    }

    void Move()
    {
    }

    public void GetDamage(float _damage)
    {
        nowHp -= _damage;
        CheckDead();
    }

    void CheckDead()
    {
        if (nowHp <= 0f)
        {
            Die();
        }
    }

    void Die()
    {
    }
}