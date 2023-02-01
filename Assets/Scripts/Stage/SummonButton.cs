using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SummonButton : MonoBehaviour
{
    [SerializeField] CharacterData characterData;
    [SerializeField] GameObject character;
    [SerializeField] float summonCooltime;
    [SerializeField] float summonCost;
    [SerializeField] float coolTime;
    [SerializeField] bool canSummon;

    [SerializeField] Image coolTimeImage;

    private void Start()
    {
        InitButton();
    }

    void InitButton()
    {
        coolTimeImage.fillAmount = 0f;
        characterData = TeamManager.instance.CharacterDatas.GetValue((Enums.CHAR_TYPE)transform.GetSiblingIndex());
        summonCooltime = characterData.SummonCoolTime;
        summonCost = characterData.SummonCost;
        coolTime = 0f;
        canSummon = true;
    }

    public void SummonCharacter()
    {
        if (canSummon)
        {
            Instantiate(character, StageManager.instance.CharacterSummonTransform.position, Quaternion.identity);
            StartCoroutine(RefreshSummonCooltime());
        }
    }

    IEnumerator RefreshSummonCooltime()
    {
        coolTime = summonCooltime;
        while(true)
        {
            if (coolTime <= summonCooltime)
            {
                coolTime = 0f;
                canSummon = true;
                yield break;
            }
            coolTime -= Time.deltaTime;
            coolTimeImage.fillAmount = coolTime / summonCooltime;
            yield return null;
        }
    }
}