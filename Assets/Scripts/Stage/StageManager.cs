using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : MonoBehaviour
{
    public static StageManager instance;

    [SerializeField] GameObject clearWindow;
    [SerializeField] GameObject defeatWindow;
    [SerializeField] Home allyHome;
    [SerializeField] Home enemyHome;
    [SerializeField] float gameTime = 0f;
    bool gameEnd = false;

    public float GameTime { get { return gameTime; } }

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        GameManager.instance.InitStageGold();
        StartCoroutine(GameContinuing());
    }

    IEnumerator GameContinuing()
    {
        while (true)
        {
            if (gameEnd) yield break;
            gameTime += Time.deltaTime;
            if (allyHome.GetNowHp() <= 0f)
            {
                StageDefeat();
            }
            else if (enemyHome.GetNowHp() <= 0f)
            {
                if (BossStage())
                {
                    if (EnemySummonManager.instance.BossSummoned)
                    {
                        if (!EnemySummonManager.instance.BossAlive)
                        {
                            StageClear();
                        }
                    }
                    else
                    {
                        EnemySummonManager.instance.SummonBoss();
                    }
                }
                else
                {
                    StageClear();
                }
            }
            yield return null;
        }
    }

    public void StageClear()
    {
        GameEnd();
        GameManager.instance.GameClear();
        ActivateClearWindow();
    }

    public void StageDefeat()
    {
        GameEnd();
        GameManager.instance.GameDefeat();
        ActivateDefeatWindow();
    }

    bool BossStage()
    {
        if (GameManager.instance.NowStage % 3 == 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    void GameEnd()
    {
        gameEnd = true;
        allyHome.gameObject.SetActive(false);
        enemyHome.gameObject.SetActive(false);
        EnemySummonManager.instance.StopSummon();
    }

    void ActivateClearWindow()
    {
        clearWindow.SetActive(true);
    }

    void ActivateDefeatWindow()
    {
        defeatWindow.SetActive(true);
    }
}