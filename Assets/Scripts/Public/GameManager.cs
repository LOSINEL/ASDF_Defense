using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [SerializeField] int gold;
    [SerializeField] int maxStage;
    [SerializeField] int nowStage;

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
        nowStage = 1;
        maxStage = 1;
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
        AddGold(GetClearGold());
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
        return nowStage * nowStage * 100;
    }

    public int GetDefeatGold()
    {
        return nowStage * nowStage * 20;
    }

    public void GameDefeat()
    {
        AddGold(GetDefeatGold());
    }
}