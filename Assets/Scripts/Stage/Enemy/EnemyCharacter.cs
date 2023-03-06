using System.Collections;
using System.Collections.Generic;
using UnityEditor.U2D.Animation;
using UnityEngine;

public class EnemyCharacter : Hp
{
    [SerializeField] EnemyData enemyData;
    [SerializeField] float moveSpeed;
    [SerializeField] float attackSpeed;
    [SerializeField] protected float attackCooltime;
    [SerializeField] float damage;
    [SerializeField] float recoverManaNum;
    [SerializeField] protected bool isEnemyChecked;
    List<GameObject> enemies = new();
    protected Animator animator;
    protected Transform tr;

    public float Damage { get { return damage; } }
    public List<GameObject> Enemies { get { return enemies; } }

    private void Awake()
    {
        tr = transform;
        boxCollider = GetComponent<BoxCollider2D>();
        animator = GetComponent<Animator>();
        InitStat();
        StartCoroutine(CheckEnemy());
    }

    private void FixedUpdate()
    {
        if (!isEnemyChecked)
        {
            Move();
        }
    }

    void InitStat()
    {
        moveSpeed = enemyData.MoveSpeed;
        attackSpeed = enemyData.AttackSpeed;
        if (attackSpeed > 0f)
        {
            attackCooltime = 1f / attackSpeed;
        }
        else
        {
            attackCooltime = -1f;
        }
        damage = enemyData.Damage;
        maxHp = nowHp = enemyData.MaxHp;
        recoverManaNum = enemyData.RecoverManaNum;
        isEnemyChecked = false;
    }

    void Move()
    {
        tr.Translate(moveSpeed * Time.fixedDeltaTime, 0f, 0f);
    }

    IEnumerator CheckEnemy()
    {
        WaitForSeconds _waitTime = new WaitForSeconds(0.1f);
        while (true)
        {
            if (enemies.Count > 0)
            {
                isEnemyChecked = true;
            }
            else
            {
                isEnemyChecked = false;
            }
            yield return _waitTime;
        }
    }

    public void SubHp(float _damage)
    {
        if (nowHp - _damage <= 0f)
        {
            nowHp = 0f;
            Die();
        }
        else
        {
            nowHp -= _damage;
        }
    }

    void Die()
    {
        StageManaManager.instance.AddMana(recoverManaNum);
        Destroy(this.gameObject);
    }
}