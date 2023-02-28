using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCharacter : Hp
{
    [SerializeField] EnemyData enemyData;
    [SerializeField] float moveSpeed;
    [SerializeField] float attackSpeed;
    [SerializeField] float damage;
    [SerializeField] float recoverManaNum;
    [SerializeField] bool isEnemyChecked;
    Transform tr;
    Animator animator;

    private void Start()
    {
        tr = transform;
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
        tr.Translate(moveSpeed * Time.deltaTime, 0f, 0f);
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