using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    public static SaveManager instance;

    [SerializeField] Data data = new();

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
        if (JsonDataExist())
        {
            string str = File.ReadAllText(Strings.jsonPath, Encoding.UTF8);
            data = JsonUtility.FromJson<Data>(str);
        }
    }

    public void JsonCreate()
    {
        if (!JsonDataExist())
        {
            FileStream fileStream = new FileStream(Strings.jsonPath, FileMode.Create);
            for (int i = 0; i < Nums.characterNum; i++)
            {
                data.characterLevelList.Add(0);
            }
            data.gold = 0;
            data.maxStage = 1;
            data.manaLevel = 0;
            fileStream.Close();
        }
    }

    void JsonSave() // gold, maxStage, manaLevel, 캐릭터 레벨 저장
    {
        if (!JsonDataExist()) return;
        for (int i = 0; i < Nums.characterNum; i++)
        {
            data.characterLevelList[i] = (TeamManager.instance.CharacterDatas.GetValue((Enums.CHAR_TYPE)i).Level);
        }
        data.gold = GameManager.instance.Gold;
        data.maxStage = GameManager.instance.MaxStage;
        data.manaLevel = ManaManager.instance.ManaLevel;
        File.WriteAllText(Strings.jsonPath, JsonUtility.ToJson(data), Encoding.UTF8);
    }

    public Data JsonLoad()
    {
        return data;
    }

    public bool JsonDataExist()
    {
        if (File.Exists(Strings.jsonPath))
        {
            return true;
        }
        else
        {
            return false;
        }
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
        File.Delete(Strings.jsonPath);
        data.InitData();
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

[System.Serializable]
public class Data
{
    public List<int> characterLevelList = new();
    public int gold;
    public int maxStage;
    public int manaLevel;

    public void InitData()
    {
        for (int i = characterLevelList.Count - 1; i >= 0; i--)
        {
            characterLevelList.RemoveAt(i);
        }
        gold = 0;
        maxStage = 1;
        manaLevel = 0;
    }
}