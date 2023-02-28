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

    public void SetSuper(bool _tf)
    {
        isSuper = _tf;
    }

    public void SummonCharacter()
    {
        if (canSummon && StageManaManager.instance.NowMana >= summonCost)
        {
            StageManaManager.instance.UseMana(summonCost);
            GameObject tmpObj = Instantiate(characterData.Character, StageManager.instance.CharacterSummonTransform.position - new Vector3(0f, Random.Range(80f, 128f), 0f), Quaternion.identity);
            if (isSuper) tmpObj.GetComponent<PlayerCharacter>().CheckSuper();
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