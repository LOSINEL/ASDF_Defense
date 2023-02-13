using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Home : MonoBehaviour
{
    [SerializeField] float maxHp;
    [SerializeField] float nowHp;
    [SerializeField] bool isBreak = false;
    [SerializeField] bool isAlly = true;
    [SerializeField] BoxCollider2D boxCollider2D;
    [SerializeField] Image hpBar;
    [SerializeField] TMP_Text hpBarText;
    [SerializeField] float hpBarRefreshTime;
    WaitForSeconds waitTime;

    public bool IsBreak { get { return isBreak; } }

    private void Start()
    {
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

    public void SubHp(float _damage)
    {
        if (nowHp - _damage <= 0f)
        {
            isBreak = true;
            boxCollider2D.enabled = false;
            nowHp = 0f;
        }
        else
        {
            nowHp -= _damage;
        }
    }
}