using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [SerializeField] int _gold;
    [SerializeField] int _maxStage;
    [SerializeField] int _nowStage;
    [SerializeField] int _stageGold = 0;

    public int Gold { get { return _gold; } }
    public int MaxStage { get { return _maxStage; } }
    public int NowStage { get { return _nowStage; } }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    private void Start()
    {
        LoadAllData();
    }

    public void SetNowStage(int num)
    {
        _nowStage = num;
    }

    public void GameClear()
    {
        if (_nowStage >= _maxStage) _maxStage = _nowStage + 1;
        AddGold(GetClearGold() + _stageGold);
        InitStageGold();
    }

    public void AddStageGold(int gold)
    {
        _stageGold += gold;
    }

    public void AddGold(int gold)
    {
        this._gold += gold;
    }

    public void SubGold(int gold)
    {
        this._gold -= gold;
    }

    public int GetClearGold()
    {
        return (_nowStage * _nowStage + 5) * 300;
    }

    public int GetDefeatGold()
    {
        return (_nowStage * _nowStage + 5) * 60;
    }

    public void GameDefeat()
    {
        AddGold(GetDefeatGold()+_stageGold);
        InitStageGold();
    }

    public void InitStageGold()
    {
        _stageGold = 0;
    }

    void SaveAllData()
    {
        int characterDataCount = TeamManager.instance.CharacterDatas.Count;
        string key;
        for (int i = 0; i < characterDataCount; i++)
        {
            key = ((Enums.CHAR_TYPE)i).ToString();
            SaveManager.instance.SetData(key, TeamManager.instance.CharacterDatas.GetValue((Enums.CHAR_TYPE)i).Level);
        }
        SaveManager.instance.SetData(Strings.gold, _gold);
        SaveManager.instance.SetData(Strings.maxStage, _maxStage);
        SaveManager.instance.SaveData();
    }

    void LoadAllData()
    {
        int characterDataCount = TeamManager.instance.CharacterDatas.Count;
        int tmp;
        string key;
        for (int i = 0; i < characterDataCount; i++)
        {
            tmp = 0;
            key = ((Enums.CHAR_TYPE)i).ToString();
            if (SaveManager.instance.CheckHasKey($"{((Enums.CHAR_TYPE)i).ToString()}"))
            {
                tmp = SaveManager.instance.LoadDataInt(key);
            }
            TeamManager.instance.CharacterDatas.GetValue((Enums.CHAR_TYPE)i).InitStat(tmp);
        }
        if (SaveManager.instance.CheckHasKey(Strings.gold))
        {
            _gold = SaveManager.instance.LoadDataInt(Strings.gold);
        }
        if (SaveManager.instance.CheckHasKey(Strings.maxStage))
        {
            _maxStage = SaveManager.instance.LoadDataInt(Strings.maxStage);
        }
    }

    private void OnApplicationQuit()
    {
        SaveAllData();
    }

    private void OnApplicationPause(bool pause)
    {
        SaveAllData();
    }
}