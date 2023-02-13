using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [SerializeField] int gold;
    [SerializeField] int level;
    [SerializeField] int maxExp;
    [SerializeField] int nowExp;
    [SerializeField] int maxStage;
    [SerializeField] int nowStage;

    public int Gold { get { return gold; } }
    public int Level { get { return level; } }
    public int MaxExp { get { return maxExp; } }
    public int NowExp { get { return nowExp; } }
    public int MaxStage { get { return maxStage; } }
    public int NowStage { get { return nowStage; } }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }

    private void Start()
    {
        nowStage = 1;
        maxStage = 1;
    }

    public void SetNowStage(int _num)
    {
        nowStage = _num;
    }

    public void GameClear()
    {
        if (nowStage > maxStage) maxStage = nowStage;
    }

    public void AddExp(int _exp)
    {
        nowExp += _exp;
        CheckLevelUp();
    }

    void CheckLevelUp()
    {
        while (nowExp >= maxExp)
        {
            level++;
            nowExp -= maxExp;
            maxExp = level * level + 10;
        }
    }

    public void AddGold(int _gold)
    {
        gold += _gold;
    }

    public void SubGold(int _gold)
    {
        gold -= _gold;
    }
}