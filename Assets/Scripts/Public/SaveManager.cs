using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    public static SaveManager instance;

    const string jsonPath = "Assets/Data.json";

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

    void JsonSave() // gold, maxStage, 캐릭터 레벨 저장
    {
        Debug.Log("HI1");
        Data data = new();
        if (!File.Exists(jsonPath))
        {
            File.Create(jsonPath);
        }
        Debug.Log("HI2");
        for (int i = 0; i < TeamManager.instance.CharacterDatas.Count; i++)
        {
            data.characterLevelList.Add(TeamManager.instance.CharacterDatas.GetValue((Enums.CHAR_TYPE)i).Level);
        }
        Debug.Log("HI3");
        data.gold = GameManager.instance.Gold;
        data.maxStage = GameManager.instance.MaxStage;
        Debug.Log("HI4");
        File.WriteAllText(jsonPath, JsonUtility.ToJson(data), System.Text.Encoding.UTF8);
        Debug.Log("HI5");
    }

    class Data
    {
        public List<int> characterLevelList = new();
        public int gold;
        public int maxStage;
    }

    public void SetData(string key, int value)
    {
        PlayerPrefs.SetInt(key, value);
    }

    public void SetData(string key, float value)
    {
        PlayerPrefs.SetFloat(key, value);
    }

    public void SaveData()
    {
        JsonSave();
        PlayerPrefs.Save();
    }

    public int LoadDataInt(string key)
    {
        return PlayerPrefs.GetInt(key);
    }

    public float LoadDataFloat(string key)
    {
        return PlayerPrefs.GetFloat(key);
    }

    public void DeleteAllData()
    {
        PlayerPrefs.DeleteAll();
    }

    public bool CheckHasKey(string key)
    {
        if (PlayerPrefs.HasKey(key))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}