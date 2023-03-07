using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EArrowPoolManager : MonoBehaviour
{
    public static EArrowPoolManager instance;

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
        for (int i = 0; i < 5; i++)
        {
            Transform tmpTr = arrowGroups[i].transform;
            for (int j = 0; j < arrowNum; j++)
            {
                arrow = Instantiate(arrows[i], tmpTr);
                arrow.SetActive(false);
            }
        }
    }

    public GameObject GetArrow(int _arrowNum)
    {
        return arrowGroups[_arrowNum].transform.GetChild(arrowNum - 1).gameObject;
    }
}