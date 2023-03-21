using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [SerializeField] int gold;
    [SerializeField] int maxStage;
    [SerializeField] int nowStage;
    [SerializeField] int stageGold = 0;

    public int Gold { get { return gold; } }
    public int MaxStage { get { return maxStage; } }
    public int NowStage { get { return nowStage; } }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            if (instance != this)
            {
                Destroy(this.gameObject);
            }
        }
    }

    private void Start()
    {
        int num = TeamManager.instance.CharacterDatas.Count;
        for (int i = 0; i < num; i++)
        {
            TeamManager.instance.CharacterDatas.GetValue((Enums.CHAR_TYPE)i).InitStat();
        }
    }

    public void SetNowStage(int _num)
    {
        nowStage = _num;
    }

    public void GameClear()
    {
        if (nowStage >= maxStage) maxStage = nowStage + 1;
        AddGold(GetClearGold() + stageGold);
        InitStageGold();
    }

    public void AddStageGold(int _gold)
    {
        stageGold += _gold;
    }

    public void AddGold(int _gold)
    {
        gold += _gold;
    }

    public void SubGold(int _gold)
    {
        gold -= _gold;
    }

    public int GetClearGold()
    {
        return (nowStage * nowStage + 10) * 200;
    }

    public int GetDefeatGold()
    {
        return (nowStage * nowStage + 10) * 40;
    }

    public void GameDefeat()
    {
        AddGold(GetDefeatGold()+stageGold);
        InitStageGold();
    }

    public void InitStageGold()
    {
        stageGold = 0;
    }
}