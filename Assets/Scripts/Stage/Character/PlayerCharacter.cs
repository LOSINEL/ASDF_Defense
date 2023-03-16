using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : Hp
{
    const float superNum = 1.5f;
    const float moveTime = 0.033f;
    const float checkTime = 0.066f;

    [SerializeField] CharacterData characterData;
    [SerializeField] float moveSpeed;
    [SerializeField] float attackSpeed;
    [SerializeField] protected float attackCooltime;
    [SerializeField] float damage;
    [SerializeField] protected bool isEnemyChecked;
    [SerializeField] bool isSuper = false;
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
        StartCoroutine(CharacterMove());
        StartCoroutine(CheckEnemyList());
    }

    private void OnEnable()
    {
        tr.position = SummonManager.instance.GetRandomPosition();
        InitStat();
    }

    private void OnDisable()
    {
        enemies.Clear();
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

    void Move()
    {
        tr.Translate(moveSpeed * moveTime, 0f, 0f);
    }

    void InitStat()
    {
        moveSpeed = characterData.MoveSpeed;
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
            moveSpeed *= superNum;
            attackSpeed *= superNum;
            attackCooltime = 1f / attackSpeed;
            damage *= superNum;
            nowHp = maxHp *= superNum;
        }
        else if (isSuper)
        {
            moveSpeed *= 1.7f;
            nowHp = maxHp *= 3f;
        }
    }
}