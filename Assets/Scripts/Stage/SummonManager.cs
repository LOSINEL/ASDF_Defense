using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SummonManager : MonoBehaviour
{
    public static SummonManager instance;

    [SerializeField] int summonNum;
    [SerializeField] GameObject[] characters;
    [SerializeField] Transform[] characterGroups = new Transform[8];
    Transform tr;
    int groupNum;
    int[] randomYposArr = { -40, 0, 40 };

    public GameObject[] Characters { get { return characters; } }

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        groupNum = characterGroups.Length;
        tr = transform;
        SetCharacter();
    }

    void SetCharacter()
    {
        for (int i = 0; i < groupNum; i++)
        {
            GameObject tmpObj = characters[(int)TeamManager.instance.TeamCharacters[i].CharType];
            for (int j = 0; j < summonNum; j++)
            {
                Instantiate(tmpObj, characterGroups[i]);
            }
        }
    }

    public Vector3 GetRandomPosition()
    {
        int rand = randomYposArr[Random.Range(0, randomYposArr.Length)];
        Vector3 tmpPos = new(0f, rand, 0f);
        return tr.position + tmpPos;
    }

    public GameObject GetCharacter(int _num)
    {
        return characterGroups[_num].GetChild(summonNum - 1).gameObject;
    }
}