using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HpBar : MonoBehaviour
{
    [SerializeField] Hp hp;
    [SerializeField] Image hpBar;
    [SerializeField] TMP_Text hpText;

    private void Update()
    {
        RefreshHpBar();
    }

    void RefreshHpBar()
    {
        hpBar.fillAmount = hp.GetNowHp() / hp.GetMaxHp();
        hpText.text = $"{(int)hp.GetNowHp()}";
    }
}