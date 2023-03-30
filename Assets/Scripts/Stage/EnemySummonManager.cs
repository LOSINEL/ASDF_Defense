using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    [SerializeField] GameObject[] bossArr;
    [SerializeField] GameObject boss;
    [SerializeField] int summonLimitNum;
    [SerializeField] int summonedNum;
    GameObject stageBoss;
    bool isBossSummoned = false;
    Transform tr;
    int bossNum;
    int summonLevel;
    int groupNum;
    int summonNum;
    Coroutine summonEnemy;
    int[] randomYposArr = { -40, 0, 40 };

    public bool BossAlive { get { if (boss.GetComponent<Hp>().GetNowHp() > 0) return true; else return false; } }
    public bool BossSummoned { get { return isBossSummoned; } }

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        bossNum = bossArr.Length;
        if (GameManager.instance.NowStage % 3 == 0)
        {
            stageBoss = bossArr[GameManager.instance.NowStage / bossNum - 1];
        }
        groupNum = enemyGroups.Length;
        summonNum = summonNums.Length;
        tr = transform;
        stageLevel = GameManager.instance.NowStage;
        summonLevel = stageLevel - 1;
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
        float _summonTime = Random.Range(summonTime * 0.8f, summonTime * 1.25f);
        float _time = 0f;
        while (true)
        {
            yield return null;
            if (_time >= _summonTime)
            {
                summonRand = Random.Range(minSummonNum, minSummonNum + 2 + (int)StageManager.instance.GameTime / summonAddTime);
                if (summonRand > maxSummonNum) summonRand = maxSummonNum;
                for (int i = 0; i < summonRand; i++)
                {
                    SummonEnemy();
                }
                _time = 0f;
                _summonTime = Random.Range(summonTime * 0.8f, summonTime * 1.25f);
            }
            _time += TimeManager.instance.TimeScale * Time.deltaTime;
        }
    }

    public void SummonBoss()
    {
        if (stageBoss != null)
        {
            BossAlert.instance.PlayBossAlert();
            boss = Instantiate(stageBoss, GetRandomPosition(), Quaternion.identity);
            isBossSummoned = true;
        }
    }

    void SummonEnemy()
    {
        if (summonedNum >= summonLimitNum) return;
        summonedNum++;
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

    public void SubLimit()
    {
        summonedNum--;
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
        int rand = randomYposArr[Random.Range(0, randomYposArr.Length)];
        Vector3 tmpPos = new(0f, rand, 0f);
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