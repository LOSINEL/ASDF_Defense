using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySummonManager : MonoBehaviour
{
    [SerializeField] Transform enemySummonTransform;
    [SerializeField] int stageLevel;
    [SerializeField] SummonGroup[] summonGroups = new SummonGroup[9];
    [SerializeField] GameObject[] enemies;
    int summonLevel;

    public GameObject[] Enemies { get { return enemies; } }
    public Transform EnemySummonTransform { get { return enemySummonTransform; } }

    private void Start()
    {
        stageLevel = GameManager.instance.NowStage;
        summonLevel = stageLevel - 1;
        if (summonLevel < 0) summonLevel = 0;
        StartCoroutine(SummonEnemy());
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            Instantiate(enemies[0], SummonManager.instance.GetRandomPositionRange(enemySummonTransform.position), Quaternion.identity);
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            Instantiate(enemies[1], SummonManager.instance.GetRandomPositionRange(enemySummonTransform.position), Quaternion.identity);
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            Instantiate(enemies[2], SummonManager.instance.GetRandomPositionRange(enemySummonTransform.position), Quaternion.identity);
        }
        if (Input.GetKeyDown(KeyCode.V))
        {
            Instantiate(enemies[3], SummonManager.instance.GetRandomPositionRange(enemySummonTransform.position), Quaternion.identity);
        }
        if (Input.GetKeyDown(KeyCode.B))
        {
            Instantiate(enemies[4], SummonManager.instance.GetRandomPositionRange(enemySummonTransform.position), Quaternion.identity);
        }
    }

    IEnumerator SummonEnemy()
    {
        WaitForSeconds waitTime = new WaitForSeconds(2f);
        yield return waitTime;
        while (true)
        {
            Instantiate(summonGroups[summonLevel].GetEnemy(Random.Range(0, 5)), SummonManager.instance.GetRandomPositionRange(enemySummonTransform.position), Quaternion.identity);
            yield return waitTime;
        }
    }

    [System.Serializable]
    class SummonGroup
    {
        [SerializeField] SummonElement[] summonElements = new SummonElement[5];
        public GameObject GetEnemy(int _num)
        {
            return summonElements[_num].GetEnemy();
        }
    }

    [System.Serializable]
    class SummonElement
    {
        [SerializeField] GameObject[] enemies = new GameObject[3];
        public GameObject GetEnemy()
        {
            int rand = Random.Range(0, 100);
            if (rand < 75) return enemies[0];
            else if (rand < 95) return enemies[1];
            else return enemies[2];
        }
    }
}