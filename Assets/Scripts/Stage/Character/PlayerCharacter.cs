using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class PlayerCharacter : Hp, IFixedUpdate
{
    const float checkTime = 0.1f;

    [SerializeField] CharacterData characterData;
    [SerializeField] List<GameObject> enemies = new();
    [SerializeField] float moveSpeed;
    [SerializeField] float attackSpeed;
    [SerializeField] float damage;
    [SerializeField] protected float attackCooltime;
    [SerializeField] bool isSuper = false;
    [SerializeField] protected bool isEnemyChecked;
    protected Animator animator;
    protected Transform tr;
    protected Rigidbody2D rigid;
    protected float attackCooltimeRandomMin = 0.8f;
    protected float attackCooltimeRandomMax = 1.25f;
    protected float _attackCooltime;
    protected SortingGroup sortingGroup;
    float fixedDeltaTime;
    IFixedUpdate iFixedUpdate;

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
        sortingGroup = GetComponent<SortingGroup>();
    }

    private void Start()
    {
        _attackCooltime = Random.Range(attackCooltime * attackCooltimeRandomMin, attackCooltime * attackCooltimeRandomMax);
        InitStat();
    }

    private void OnEnable()
    {
        FixedUpdateManager.instance.FixedUpdateList.Add(iFixedUpdate);
        tr.position = SummonManager.instance.GetRandomPosition();
        sortingGroup.sortingOrder = SummonManager.instance.SortNum;
        InitStat();
        StartCoroutine(CheckEnemyList());
    }

    private void OnDisable()
    {
        FixedUpdateManager.instance.FixedUpdateList.Remove(iFixedUpdate);
        enemies.Clear();
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
        WaitForSeconds _checkTime = new (checkTime);
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

    void CheckEnemy()
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

    void Move()
    {
        rigid.MovePosition(rigid.position + new Vector2(moveSpeed * TimeManager.instance.TimeScale, 0f));
    }

    void InitStat()
    {
        moveSpeed = characterData.MoveSpeed * fixedDeltaTime;
        attackSpeed = characterData.AttackSpeed;
        if (attackSpeed > 0f)
        {
            attackCooltime = 1f / attackSpeed;
        }
        else
        {
            attackCooltime = -1f;
        }
        damage = characterData.Damage;
        maxHp = nowHp = characterData.MaxHp;
        isEnemyChecked = false;
    }

    public void CheckSuper()
    {
        isSuper = true;
        GetComponent<SpriteRenderer>().color = new Color(1f, 0.5f, 0.5f);
        if (isSuper && damage > 0)
        {
            moveSpeed *= 1.25f;
            attackSpeed *= 1.25f;
            attackCooltime = 1f / attackSpeed;
            damage *= 1.5f;
            nowHp = maxHp *= 1.5f;
        }
        else if (isSuper)
        {
            moveSpeed *= 1.4f;
            nowHp = maxHp *= 2.5f;
        }
    }
}