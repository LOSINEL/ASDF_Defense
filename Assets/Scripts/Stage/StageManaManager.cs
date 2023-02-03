using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StageManaManager : MonoBehaviour
{
    public static StageManaManager instance;

    const float baseMaxMana = 100f;
    const float baseManaRecovery = 5f;

    [SerializeField] TMP_Text manaText;
    [SerializeField] TMP_Text needManaText;
    [SerializeField] int manaLevel;
    [SerializeField] float nowMana;
    [SerializeField] float maxMana;
    [SerializeField] float manaRecovery;
    [SerializeField] float manaRecoveryTime;
    WaitForSeconds recoveryTime;

    public float NowMana { get { return nowMana; } }

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        InitMana();
        recoveryTime = new WaitForSeconds(manaRecoveryTime);
        StartCoroutine(RecoverMana());
    }

    void InitMana()
    {
        manaLevel = 1;
        nowMana = 0f;
        maxMana = baseMaxMana + ManaManager.instance.MaxMana;
        manaRecovery = baseManaRecovery + ManaManager.instance.ManaRecovery;
    }

    public void UpgradeMana() // 마나스톤 버튼
    {
        if (nowMana < maxMana * 0.5f) return;
        nowMana -= maxMana * 0.5f;
        manaLevel++;
        manaRecovery += manaLevel * 0.5f;
        maxMana *= 1.5f;
        RefreshNeedManaText();
    }

    public void UseMana(float _mana)
    {
        nowMana -= _mana;
        RefreshManaText();
    }

    IEnumerator RecoverMana()
    {
        while(true)
        {
            if (nowMana < maxMana)
            {
                nowMana += manaRecovery * manaRecoveryTime;
                RefreshManaText();
            }
            yield return recoveryTime;
        }
    }

    void RefreshManaText()
    {
        manaText.text = $"{(int)nowMana}/{(int)maxMana}";
    }

    void RefreshNeedManaText()
    {
        needManaText.text = $"MANA {(int)(maxMana / 2f)}";
    }
}