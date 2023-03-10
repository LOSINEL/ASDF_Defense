using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySummonManager : MonoBehaviour
{
    public static EnemySummonManager instance;

    [SerializeField] int stageLevel;
    [SerializeField] float summonTime;
    [SerializeField] int minSummonNum;
    [SerializeField] int maxSummonNum;
    [SerializeField] int summonAddTime;
    [SerializeField] SummonGroup[] summonGroups = new SummonGroup[9];
    [SerializeField] int[] summonNums = new int[3];
    [SerializeField] int[] summonSettingNums = new int[3];
    [SerializeField] int summonNumTot = 0;
    [SerializeField] Transform[] enemyGroups = new Transform[5];
    Transform tr;
    int summonLevel;
    int groupNum;
    int summonNum;
    Coroutine summonEnemy;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        groupNum = enemyGroups.Length;
        summonNum = summonNums.Length;
        tr = transform;
        stageLevel = GameManager.instance.NowStage;
        summonLevel = stageLevel - 1;
        if (summonLevel < 0) summonLevel = 0;
        SetEnemy();
        summonEnemy = StartCoroutine(PlaySummonEnemy());
    }

    private void OnDisable()
    {
        StopSummon();
    }

    IEnumerator PlaySummonEnemy()
    {
        int summonRand;
        WaitForSeconds waitTime = new WaitForSeconds(summonTime);
        yield return waitTime;
        while (true)
        {
            summonRand = Random.Range(minSummonNum, maxSummonNum + 1 + (int)StageManager.instance.GameTime / summonAddTime);
            for (int i = 0; i < summonRand; i++)
            {
                SummonEnemy();
            }
            yield return waitTime;
        }
    }

    void SummonEnemy()
    {
        GameObject tmpObj;
        int groupRand = Random.Range(0, groupNum);
        int summonRand = 0;
        int elementRand = Random.Range(1, summonNumTot + 1);
        for (int i = summonNum - 1; i >= 0; i--)
        {
            if (elementRand <= summonNums[i])
            {
                summonRand = i;
            }
        }
        tmpObj = enemyGroups[groupRand].GetChild(summonRand).GetChild(summonSettingNums[summonRand] - 1).gameObject;
        tmpObj.SetActive(true);
        tmpObj.transform.SetAsFirstSibling();
    }

    public void StopSummon()
    {
        StopCoroutine(summonEnemy);
    }

    void SetEnemy()
    {
        for (int i = 0; i < groupNum; i++)
        {
            for (int j = 0; j < summonNum; j++)
            {
                for (int k = 0; k < summonSettingNums[j]; k++)
                {
                    Instantiate(summonGroups[summonLevel].SummonElements[i].Enemies[j], enemyGroups[i].GetChild(j));
                }
            }
        }
    }

    public Vector3 GetRandomPosition()
    {
        Vector3 tmpPos = new Vector3(0f, Random.Range(-40f, 40f), 0f);
        return tr.position + tmpPos;
    }

    [System.Serializable]
    class SummonGroup
    {
        [SerializeField] SummonElement[] summonElements = new SummonElement[5];

        public SummonElement[] SummonElements { get { return summonElements; } }
    }

    [System.Serializable]
    class SummonElement
    {
        [SerializeField] GameObject[] enemies = new GameObject[3];

        public GameObject[] Enemies { get { return enemies; } }
    }
}