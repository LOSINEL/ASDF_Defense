using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCharacter : Hp, IFixedUpdate
{
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
    protected Rigidbody2D rigid;
    protected float attackCooltimeRandomMin = 0.8f;
    protected float attackCooltimeRandomMax = 1.25f;
    protected float _attackCooltime;
    IFixedUpdate iFixedUpdate;
    float fixedDeltaTime;

    public float Damage { get { return damage; } }
    public List<GameObject> Enemies { get { return enemies; } }

    private void Awake()
    {
        fixedDeltaTime = Time.fixedDeltaTime;
        iFixedUpdate = GetComponent<IFixedUpdate>();
        tr = transform;
        rigid = GetComponent<Rigidbody2D>();
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
        FixedUpdateManager.instance.FixedUpdateList.Add(iFixedUpdate);
        tr.position = EnemySummonManager.instance.GetRandomPosition();
        InitStat();
        StartCoroutine(CheckEnemyList());
    }

    private void OnDisable()
    {
        FixedUpdateManager.instance.FixedUpdateList.Remove(iFixedUpdate);
        enemies.Clear();
        int gold = Random.Range(0, enemyData.Gold + 1);
        GameManager.instance.AddStageGold(gold);
        StageManaManager.instance.AddMana(recoverManaNum);
        EnemySummonManager.instance.SubLimit();
        StopAllCoroutines();
    }

    public void ManagedFixedUpdate()
    {
        CheckEnemy();
        if (!isEnemyChecked)
        {
            Move();
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
        moveSpeed = enemyData.MoveSpeed * fixedDeltaTime;
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
        rigid.MovePosition(rigid.position + new Vector2(moveSpeed * TimeManager.instance.TimeScale, 0f));
    }
}