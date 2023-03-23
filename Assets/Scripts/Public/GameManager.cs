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
        SaveManager.instance.JsonCreate();
        LoadAllData();
        StartCoroutine(AutoSave());
    }

    IEnumerator AutoSave()
    {
        WaitForSecondsRealtime waitTime = new(3f);
        while (true)
        {
            yield return waitTime;
            SaveAllData();
        }
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
        SaveManager.instance.SaveData();
    }

    void LoadAllData()
    {
        if (!SaveManager.instance.JsonDataExist()) return;
        for (int i = 0; i < Nums.characterNum; i++)
        {
            TeamManager.instance.CharacterDatas.GetValue((Enums.CHAR_TYPE)i).InitStat(SaveManager.instance.JsonLoad().characterLevelList[i]);
        }
        _gold = SaveManager.instance.JsonLoad().gold;
        _maxStage = SaveManager.instance.JsonLoad().maxStage;
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