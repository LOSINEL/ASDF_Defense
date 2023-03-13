using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicianAttackPoolManager : MonoBehaviour
{
    public static MagicianAttackPoolManager instance;

    [SerializeField] int attackNum;
    [SerializeField] GameObject[] magicianAttacks = new GameObject[3];
    [SerializeField] Transform[] magicianAttackGroups = new Transform[3];

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        for (int i = 0; i < 8; i++)
        {
            int charType = (int)TeamManager.instance.TeamCharacters[i].CharType;
            if (charType == (int)Enums.CHAR_TYPE.MAGICIAN1 || charType == (int)Enums.CHAR_TYPE.MAGICIAN2 || charType == (int)Enums.CHAR_TYPE.MAGICIAN3)
            {
                int idx = charType - (int)Enums.CHAR_TYPE.MAGICIAN1;
                Transform magicianAttackGroupTr = magicianAttackGroups[charType - (int)Enums.CHAR_TYPE.MAGICIAN1].transform;
                for (int j = 0; j < attackNum; j++)
                {
                    Instantiate(magicianAttacks[idx], magicianAttackGroupTr);
                }
            }
        }
    }

    public GameObject GetAttack(int _magicianNum)
    {
        return magicianAttackGroups[_magicianNum].GetChild(magicianAttackGroups[_magicianNum].childCount - 1).gameObject;
    }
}