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
    [SerializeField] bool isEnemyChecked;


    private void Start()
    {
        InitStat();
    }

    void InitStat()
    {
        moveSpeed = characterData.MoveSpeed;
        attackSpeed = characterData.AttackSpeed;
        damage = characterData.Damage;
        maxHp = nowHp = characterData.MaxHp;
        isEnemyChecked = false;
    }
}