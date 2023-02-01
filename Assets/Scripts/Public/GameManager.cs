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

    public int Gold { get { return gold; } }
    public int Level { get { return level; } }
    public int MaxExp { get { return maxExp; } }
    public int NowExp { get { return nowExp; } }

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
        InitInfo();
    }

    void InitInfo()
    {
        gold = 0;
        level = 1;
        maxExp = level * level + 10;
        nowExp = 0;
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

    public bool SubGold(int _gold)
    {
        if (gold >= _gold)
        {
            gold -= _gold;
            return true;
        }
        else
        {
            return false;
        }
    }
}