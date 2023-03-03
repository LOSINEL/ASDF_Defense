using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    public static PoolManager instance;

    [SerializeField] int arrowNum;
    [SerializeField] GameObject[] arrows;
    [SerializeField] GameObject[] arrowGroups;

    public GameObject[] ArrowGroups { get { return arrowGroups; } }

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        GameObject arrow;
        for (int i = 0; i < 8; i++)
        {
            int charType = (int)TeamManager.instance.TeamCharacters[i].CharType;
            if (charType == (int)Enums.CHAR_TYPE.ARCHER1 || charType == (int)Enums.CHAR_TYPE.ARCHER2 || charType == (int)Enums.CHAR_TYPE.ARCHER3)
            {
                int idx = charType - (int)Enums.CHAR_TYPE.ARCHER1;
                Transform arrowGroupTr = arrowGroups[charType - (int)Enums.CHAR_TYPE.ARCHER1].transform;
                for (int j = 0; j < arrowNum; j++)
                {
                    arrow = Instantiate(arrows[idx], arrowGroupTr);
                    arrow.SetActive(false);
                }
            }
        }
    }

    public GameObject GetArrow(int _arrowNum)
    {
        return arrowGroups[_arrowNum].transform.GetChild(arrowNum - 1).gameObject;
    }
}