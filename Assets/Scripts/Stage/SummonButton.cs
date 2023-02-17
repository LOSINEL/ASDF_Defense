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

    public float SummonCost { get { return summonCost; } }

    private void Start()
    {
        InitButton();
    }

    void InitButton()
    {
        coolTimeImage.fillAmount = 0f;
        characterData = TeamManager.instance.TeamCharacters[transform.GetSiblingIndex()];
        summonCooltime = characterData.SummonCoolTime;
        summonCost = characterData.SummonCost;
        coolTime = 0f;
        canSummon = true;
        GetComponent<Image>().sprite = characterData.Portraits[(int)Enums.PORTRAIT_TYPE.BUTTON];
        GetComponentInChildren<TMP_Text>().text = $"{(int)summonCost}";
    }

    public void SummonCharacter()
    {
        if (canSummon && StageManaManager.instance.NowMana >= summonCost)
        {
            StageManaManager.instance.UseMana(summonCost);
            Instantiate(characterData.Character, StageManager.instance.CharacterSummonTransform.position, Quaternion.identity);
            SummonPortraitGroup.instance.SummonPortrait(characterData.CharType);
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