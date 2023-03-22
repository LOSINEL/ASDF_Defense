using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    public static SaveManager instance;

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