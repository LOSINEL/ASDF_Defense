using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInterfaceText : MonoBehaviour
{
    int gold;
    [SerializeField] TMP_Text levelText;
    [SerializeField] TMP_Text goldText;
    [SerializeField] Image expBar;
    [SerializeField] float goldRollingTime;

    private void Start()
    {
        gold = GameManager.instance.Gold;
        goldText.text = $"{gold}";
        RefreshLevelText();
        RefreshExpBar();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.A))
        {
            CheckGold();
        }
    }

    void RefreshLevelText()
    {
        levelText.text = $"LEVEL {GameManager.instance.Level}";
    }

    void RefreshExpBar()
    {
        expBar.fillAmount = GameManager.instance.NowExp / GameManager.instance.MaxExp;
    }

    public void CheckGold()
    {
        if (GameManager.instance.Gold > gold)
        {
            StartCoroutine(RollingUpGoldText());
        }
        else if (GameManager.instance.Gold < gold)
        {
            StartCoroutine(RollingDownGoldText());
        }
    }

    IEnumerator RollingUpGoldText()
    {
        float _goldGap = GameManager.instance.Gold - gold;
        int _gold;
        while (true)
        {
            _gold = (int)(_goldGap * Time.deltaTime / goldRollingTime) + 1;
            if (gold + _gold >= GameManager.instance.Gold)
            {
                gold = GameManager.instance.Gold;
                goldText.text = $"{gold}";
                yield break;
            }
            gold += _gold;
            goldText.text = $"{gold}";
            yield return null;
        }
    }

    IEnumerator RollingDownGoldText()
    {
        float _goldGap = gold - GameManager.instance.Gold;
        int _gold;
        while (true)
        {
            _gold = (int)(_goldGap * Time.deltaTime / goldRollingTime) + 1;
            if (gold - _gold <= GameManager.instance.Gold)
            {
                gold = GameManager.instance.Gold;
                goldText.text = $"{gold}";
                yield break;
            }
            gold -= _gold;
            goldText.text = $"{gold}";
            yield return null;
        }
    }
}