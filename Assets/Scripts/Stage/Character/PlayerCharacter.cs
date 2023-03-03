using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : Hp
{
    [SerializeField] CharacterData characterData;
    [SerializeField] float moveSpeed;
    [SerializeField] float attackSpeed;
    [SerializeField] float attackCooltime;
    [SerializeField] float damage;
    [SerializeField] protected bool isEnemyChecked;
    [SerializeField] bool isSuper = false;
    protected List<GameObject> enemies = new();
    protected Animator animator;
    protected Transform tr;

    public float AttackCooltime { get { return attackCooltime; } }
    public bool IsEnemyChecked { get { return isEnemyChecked; } }
    public float Damage { get { return damage; } }
    public List<GameObject> Enemies { get { return enemies; } }

    private void Awake()
    {
        tr = GetComponent<Transform>();
        boxCollider = GetComponent<BoxCollider2D>();
        animator = GetComponent<Animator>();
        InitStat();
        StartCoroutine(CheckEnemy());
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

    private void FixedUpdate()
    {
        if (!IsEnemyChecked)
        {
            Move();
        }
    }

    protected void Move()
    {
        tr.Translate(moveSpeed * Time.fixedDeltaTime, 0f, 0f);
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
        if (isSuper && characterData.Damage > 0)
        {
            moveSpeed *= 1.4f;
            attackSpeed *= 1.4f;
            damage *= 1.4f;
            nowHp = maxHp *= 1.4f;
        }
        else if (isSuper)
        {
            moveSpeed *= 1.6f;
            nowHp = maxHp *= 2.5f;
        }
    }

    public void CheckSuper()
    {
        isSuper = true;
    }
}