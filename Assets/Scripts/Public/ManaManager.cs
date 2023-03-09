using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManaManager : MonoBehaviour
{
    public static ManaManager instance;

    [SerializeField] int manaLevel = 0;
    [SerializeField] float maxMana = 0f;
    [SerializeField] float manaRecovery = 0f;
    [SerializeField] float maxManaUpgradeNum;
    [SerializeField] float manaRecoveryUpgradeNum;
    [SerializeField] int upgradeGold;

    public int ManaLevel { get { return manaLevel; } }
    public float ManaRecovery { get { return manaRecovery; } }
    public float MaxMana { get { return maxMana; } }
    public float MaxManaUpgradeNum { get { return maxManaUpgradeNum; } }
    public float ManaRecoveryUpgradeNum { get { return manaRecoveryUpgradeNum; } }
    public int UpgradeGold { get { return upgradeGold; } }

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

    private void Start()
    {
        RefreshUpgradeNum();
    }

    public void UpgradeMana()
    {
        if (GameManager.instance.Gold >= upgradeGold)
        {
            GameManager.instance.SubGold(upgradeGold);
            manaLevel++;
            maxMana += maxManaUpgradeNum;
            manaRecovery += manaRecoveryUpgradeNum;
            RefreshUpgradeNum();
            ManaWindowText.instance.RefreshTexts();
        }
    }

    void RefreshUpgradeNum()
    {
        maxManaUpgradeNum = 15f + manaLevel;
        manaRecoveryUpgradeNum = 1.0f + manaLevel * 0.1f;
        upgradeGold = (manaLevel + 1) * 200;
    }
}