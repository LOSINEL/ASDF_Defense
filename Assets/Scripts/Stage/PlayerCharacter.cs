using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : MonoBehaviour
{
    [SerializeField] CharacterData characterData;
    [SerializeField] float moveSpeed;
    [SerializeField] float attackSpeed;
    [SerializeField] float damage;
    [SerializeField] float nowHp;
    [SerializeField] float maxHp;
    [SerializeField] protected bool isEnemyChecked;
    [SerializeField] bool isSuper;
    Transform tr;

    private void Awake()
    {
        tr = GetComponent<Transform>();
    }

    private void Start()
    {
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

    public void CheckSuper(bool _isSuper)
    {
        isSuper = _isSuper;
    }
}