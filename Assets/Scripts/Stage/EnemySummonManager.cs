using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySummonManager : MonoBehaviour
{
    public static EnemySummonManager instance;

    [SerializeField] int stageLevel;
    [SerializeField] float summonTime;
    [SerializeField] SummonGroup[] summonGroups = new SummonGroup[9];
    [SerializeField] int[] summonNums = new int[3];
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
        summonEnemy = StartCoroutine(SummonEnemy());
    }

    IEnumerator SummonEnemy()
    {
        int groupRand;
        int elementRand;
        GameObject tmpObj;

        WaitForSeconds waitTime = new WaitForSeconds(summonTime);
        yield return waitTime;
        while (true)
        {
            groupRand = Random.Range(0, groupNum);
            elementRand = Random.Range(0, summonNum);
            tmpObj = enemyGroups[groupRand].GetChild(elementRand).GetChild(summonNums[elementRand] - 1).gameObject;
            tmpObj.SetActive(true);
            tmpObj.transform.SetAsFirstSibling();
            yield return waitTime;
        }
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
                for (int k = 0; k < summonNums[j]; k++)
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