using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManaManager : MonoBehaviour
{
    public static ManaManager instance;



    [SerializeField] int manaLevel = 0;
    [SerializeField] float manaRecovery = 0f;
    [SerializeField] float maxMana = 0f;

    public int ManaLevel { get { return manaLevel; } }
    public float ManaRecovery { get { return manaRecovery; } }
    public float MaxMana { get { return maxMana; } }

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public void LevelUpMana()
    {
        manaLevel++;
        manaRecovery += 1.0f;
        maxMana += 25f;
    }
}