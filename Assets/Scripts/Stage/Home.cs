using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Home : Hp
{
    [SerializeField] Image hpBar;
    [SerializeField] TMP_Text hpBarText;
    [SerializeField] float hpBarRefreshTime;
    [SerializeField] bool isAlly;
    WaitForSeconds waitTime;

    private void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        maxHp = GameManager.instance.NowStage * 10000;
        nowHp = maxHp;
        waitTime = new WaitForSeconds(hpBarRefreshTime);
        StartCoroutine(RefreshHpBar());
    }

    private void OnDisable()
    {
        if (!isAlly) EnemySummonManager.instance.StopSummon();
        StopCoroutine(RefreshHpBar());
        StageManager.instance.ActivateClearWindow(isAlly);
    }

    IEnumerator RefreshHpBar()
    {
        while (true)
        {
            hpBarText.text = $"{(int)nowHp}";
            hpBar.fillAmount = nowHp / maxHp;
            yield return waitTime;
        }
    }
}