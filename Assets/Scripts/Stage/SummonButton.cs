using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SummonButton : MonoBehaviour
{
    [SerializeField] CharacterData characterData;
    [SerializeField] float summonCooltime;
    [SerializeField] float summonCost;
    [SerializeField] float coolTime;
    [SerializeField] bool canSummon;
    [SerializeField] Image coolTimeImage;
    [SerializeField] bool isSuper = false;
    [SerializeField] int slotNum;

    private void Start()
    {
        InitButton();
    }

    void InitButton()
    {
        slotNum = transform.GetSiblingIndex();
        coolTimeImage.fillAmount = 0f;
        characterData = TeamManager.instance.TeamCharacters[transform.GetSiblingIndex()];
        summonCooltime = characterData.SummonCoolTime;
        summonCost = characterData.SummonCost;
        coolTime = 0f;
        canSummon = true;
        GetComponent<Image>().sprite = characterData.Portraits[(int)Enums.PORTRAIT_TYPE.BUTTON];
        GetComponentInChildren<TMP_Text>().text = $"{(int)summonCost}";
    }

    public void SetSuper(bool _tf)
    {
        isSuper = _tf;
        if (isSuper)
        {
            summonCost = characterData.SuperSummonCost;
        }
        else
        {
            summonCost = characterData.SummonCost;
        }
    }

    public void SummonCharacter()
    {
        if (canSummon && StageManaManager.instance.CheckEnoughMana(summonCost))
        {
            StageManaManager.instance.UseMana(summonCost);
            GameObject tmpObj = SummonManager.instance.GetCharacter(slotNum);
            tmpObj.transform.SetAsFirstSibling();
            tmpObj.SetActive(true);
            if (isSuper) tmpObj.GetComponent<PlayerCharacter>().CheckSuper();
            SummonPortraitGroup.instance.SummonPortrait(characterData.CharType);
            StartCoroutine(RefreshSummonCooltime());
        }
    }

    IEnumerator RefreshSummonCooltime()
    {
        canSummon = false;
        coolTime = summonCooltime;
        coolTimeImage.fillAmount = 1f;
        while(true)
        {
            if (coolTime <= 0)
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