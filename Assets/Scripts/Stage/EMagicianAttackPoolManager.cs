using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EMagicianAttackPoolManager : MonoBehaviour
{
    public static EMagicianAttackPoolManager instance;

    [SerializeField] int attackNum;
    [SerializeField] GameObject eMagicianAttack;
    [SerializeField] Transform eMagicianAttackGroup;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        for (int i = 0; i < attackNum; i++)
        {
            Instantiate(eMagicianAttack, eMagicianAttackGroup);
        }
    }

    public GameObject GetAttack()
    {
        return eMagicianAttackGroup.GetChild(attackNum - 1).gameObject;
    }
}