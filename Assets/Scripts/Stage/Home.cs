using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Home : Hp
{
    [SerializeField] bool isBreak = false;
    [SerializeField] Image hpBar;
    [SerializeField] TMP_Text hpBarText;
    [SerializeField] float hpBarRefreshTime;
    WaitForSeconds waitTime;

    public bool IsBreak { get { return isBreak; } }

    private void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        maxHp = GameManager.instance.NowStage * 10000;
        nowHp = maxHp;
        waitTime = new WaitForSeconds(hpBarRefreshTime);
        StartCoroutine(RefreshHpBar());
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