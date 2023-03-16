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
        StartCoroutine(GameContinuing());
    }

    IEnumerator GameContinuing()
    {
        while (true)
        {
            if (gameEnd) yield break;
            gameTime += Time.deltaTime;
            if (allyHome.GetHp() <= 0f)
            {
                GameEnd();
                GameManager.instance.GameDefeat();
                ActivateDefeatWindow();
            }
            else if (enemyHome.GetHp() <= 0f)
            {
                GameEnd();
                GameManager.instance.GameClear();
                ActivateClearWindow();
            }
            yield return null;
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