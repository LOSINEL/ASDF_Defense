using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StageManager : MonoBehaviour
{
    public static StageManager instance;

    [SerializeField] Transform characterSummonTransform;
    [SerializeField] Transform enemySpawnTransform;
    [SerializeField] float enemySpawnTimeMin;
    [SerializeField] float enemySpawnTimeMax;
    [SerializeField] int stageLevel;
    [SerializeField] float[] stageBalanceNum = new float[5];
    [SerializeField] SpawnGroup[] spawnGroups = new SpawnGroup[5];
    [SerializeField] Sprite[] stageBackgroundImages;
    [SerializeField] GameObject summonButtonGroup;

    public Transform CharacterSummonTransform { get { return CharacterSummonTransform; } }

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        for (int i = 0; i < summonButtonGroup.transform.childCount; i++)
        {
            summonButtonGroup.transform.GetChild(i).GetComponent<Image>().sprite = TeamManager.instance.TeamCharacters[i].Portraits[(int)Enums.PORTRAIT_TYPE.BUTTON];
            summonButtonGroup.transform.GetChild(i).GetComponent<TextMeshPro>().text = $"{TeamManager.instance.TeamCharacters[i].SummonCost}";
        }
    }

    public void SetStageLevel(int _stageLevel)
    {
        stageLevel = _stageLevel;
        SpawnEnemy();
    }

    void SpawnEnemy()
    {
        for (int i = 0; i <= (stageLevel + 1) / 2; i++)
        {
            StartCoroutine(SpawnEnemy(i));
        }
    }

    /* SpawnEnemy
     * 1 - stageLevel 1,2
     * 2 - stageLevel 3,4
     * 3 - stageLevel 5,6
     * 4 - stageLevel 7,8
     * 5 - stageLevel 9
     */

    IEnumerator SpawnEnemy(int _num)
    {
        float spawnTimeMin = enemySpawnTimeMin / (1f + stageLevel * 0.1f) * stageBalanceNum[_num];
        float spawnTimeMax = enemySpawnTimeMax / (1f + stageLevel * 0.1f) * stageBalanceNum[_num];
        int enemyCount = spawnGroups[_num].Enemies.Length;
        yield return new WaitForSeconds(Random.Range(spawnTimeMin, spawnTimeMax));
        while (true)
        {
            Instantiate(spawnGroups[_num].Enemies[Random.Range(0, enemyCount)], enemySpawnTransform.transform.position, Quaternion.identity);
            yield return new WaitForSeconds(Random.Range(spawnTimeMin, spawnTimeMax));
        }
    }

    [System.Serializable]
    class SpawnGroup
    {
        [SerializeField] GameObject[] enemies;
        public GameObject[] Enemies { get { return enemies; } }
    }
}