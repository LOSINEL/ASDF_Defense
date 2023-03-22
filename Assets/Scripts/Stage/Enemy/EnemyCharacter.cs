using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCharacter : Hp
{
    const float moveTime = 0.05f;
    const float checkTime = 0.1f;

    [SerializeField] EnemyData enemyData;
    [SerializeField] float moveSpeed;
    [SerializeField] float attackSpeed;
    [SerializeField] protected float attackCooltime;
    [SerializeField] float damage;
    [SerializeField] float recoverManaNum;
    [SerializeField] protected bool isEnemyChecked;
    [SerializeField] List<GameObject> enemies = new();
    protected Animator animator;
    protected Transform tr;
    protected float attackCooltimeRandomMin = 0.8f;
    protected float attackCooltimeRandomMax = 1.25f;
    protected float _attackCooltime;

    public float Damage { get { return damage; } }
    public List<GameObject> Enemies { get { return enemies; } }

    private void Awake()
    {
        tr = transform;
        boxCollider = GetComponent<BoxCollider2D>();
        animator = GetComponent<Animator>();
    }

    private void Start()
    {
        _attackCooltime = Random.Range(attackCooltime * attackCooltimeRandomMin, attackCooltime * attackCooltimeRandomMax);
        tr.position = EnemySummonManager.instance.GetRandomPosition();
        InitStat();
    }

    private void OnEnable()
    {
        try
        {
            tr.position = EnemySummonManager.instance.GetRandomPosition();
        }
        catch { }
        InitStat();
        StartCoroutine(CharacterMove());
        StartCoroutine(CheckEnemyList());
    }

    private void OnDisable()
    {
        enemies.Clear();
        int gold = Random.Range(0, enemyData.Gold + 1);
        GameManager.instance.AddStageGold(gold);
        StageManaManager.instance.AddMana(recoverManaNum);
        EnemySummonManager.instance.SubLimit();
        StopAllCoroutines();
    }

    private void FixedUpdate()
    {
        CheckEnemy();
        if (!isEnemyChecked)
        {
            Move();
        }
    }

    IEnumerator CharacterMove()
    {
        WaitForSeconds _moveTime = new WaitForSeconds(moveTime);
        while (true)
        {
            CheckEnemy();
            if (!isEnemyChecked)
            {
                Move();
            }
            yield return _moveTime;
        }
    }

    IEnumerator CheckEnemyList()
    {
        WaitForSeconds _checkTime = new WaitForSeconds(checkTime);
        while (true)
        {
            for (int i = enemies.Count - 1; i >= 0; i--)
            {
                if (enemies[i].activeSelf == false)
                {
                    enemies.Remove(enemies[i]);
                }
            }
            yield return _checkTime;
        }
    }

    public void CheckEnemy()
    {
        if (enemies.Count > 0)
        {
            isEnemyChecked = true;
        }
        else
        {
            isEnemyChecked = false;
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
        tr.Translate(moveSpeed * moveTime, 0f, 0f);
    }
}