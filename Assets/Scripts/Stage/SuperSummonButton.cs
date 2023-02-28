using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SuperSummonButton : MonoBehaviour
{
    [SerializeField] GameObject summonButtonGroup;
    [SerializeField] bool superSummonOn = false;
    [SerializeField] RectTransform[] summonButtonRectTransforms = new RectTransform[8];
    [SerializeField] TMP_Text[] summonButtonTexts = new TMP_Text[8];
    [SerializeField] int summonButtonNum;
    Image image;

    public bool SuperSummonOn { get { return superSummonOn; } }

    void Start()
    {
        summonButtonNum = summonButtonGroup.transform.childCount;
        image = GetComponent<Image>();
        for (int i = 0; i < summonButtonNum; i++)
        {
            summonButtonRectTransforms[i] = summonButtonGroup.transform.GetChild(i).GetComponent<RectTransform>();
            summonButtonTexts[i] = summonButtonGroup.transform.GetChild(i).GetComponentInChildren<TMP_Text>();
        }
    }

    public void ActivateSuperSummon()
    {
        superSummonOn = !superSummonOn;
        if (superSummonOn)
        {
            image.color = Color.red;
            for (int i = 0; i < summonButtonNum; i++)
            {
                summonButtonTexts[i].text = TeamManager.instance.TeamCharacters[i].SuperSummonCost.ToString();
                summonButtonGroup.transform.GetChild(i).GetComponent<SummonButton>().SetSuper(superSummonOn);
            }
        }
        else
        {
            image.color = Color.white;
            for (int i = 0; i < summonButtonNum; i++)
            {
                summonButtonTexts[i].text = TeamManager.instance.TeamCharacters[i].SummonCost.ToString();
                summonButtonGroup.transform.GetChild(i).GetComponent<SummonButton>().SetSuper(superSummonOn);
            }
        }
    }
}