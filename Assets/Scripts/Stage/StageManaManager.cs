using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageManaManager : MonoBehaviour
{
    const float baseMaxMana = 100f;
    const float baseManaRecovery = 5f;

    [SerializeField] Text manaText;
    [SerializeField] Text needManaText;
    [SerializeField] int manaLevel;
    [SerializeField] float nowMana;
    [SerializeField] float maxMana;
    [SerializeField] float manaRecovery;

    private void Start()
    {
        InitMana();
    }

    void InitMana()
    {
        manaLevel = 1;
        nowMana = 0f;
        maxMana = baseMaxMana + ManaManager.instance.MaxMana;
        manaRecovery = baseManaRecovery + ManaManager.instance.ManaRecovery;
    }

    public void UpgradeMana()
    {
        if (nowMana < maxMana * 0.5f) return;
        nowMana -= maxMana * 0.5f;
        manaLevel++;
        manaRecovery += manaLevel * 0.5f;
        maxMana *= 1.5f;
    }
}