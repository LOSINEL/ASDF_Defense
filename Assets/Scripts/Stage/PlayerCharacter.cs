using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : MonoBehaviour
{
    [SerializeField] CharacterData characterData;
    [SerializeField] float moveSpeed;
    [SerializeField] float attackSpeed;
    [SerializeField] float attackCooltime;
    [SerializeField] float damage;
    [SerializeField] float nowHp;
    [SerializeField] float maxHp;
    [SerializeField] bool isEnemyChecked;
    [SerializeField] bool isSuper = false;
    protected Animator animator;
    BoxCollider2D characterCollider;
    Transform tr;

    public float AttackCooltime { get { return attackCooltime; } }
    public bool IsEnemyChecked { get { return isEnemyChecked; } }
    public float Damage { get { return damage; } }

    private void Awake()
    {
        tr = GetComponent<Transform>();
    }

    private void Start()
    {
        animator = GetComponent<Animator>();
        InitStat();
    }

    protected void Move()
    {
        tr.Translate(moveSpeed * Time.deltaTime, 0f, 0f);
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
            damage = 1.4f;
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("EnemyAttack"))
        {
        }
    }
}