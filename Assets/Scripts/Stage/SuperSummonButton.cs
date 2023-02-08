using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SuperSummonButton : MonoBehaviour
{
    [SerializeField] GameObject summonButtonGroup;
    [SerializeField] bool superSummonOn = false;
    [SerializeField] Transform[] summonButtonTransforms;
    [SerializeField] TMP_Text[] summonButtonTexts;
    int summonButtonCount;
    Image image;

    public bool SuperSummonOn { get { return superSummonOn; } }

    private void Start()
    {
        image = GetComponent<Image>();
        summonButtonCount = summonButtonGroup.transform.childCount;
        for (int i = 0; i < summonButtonCount; i++)
        {
            summonButtonTransforms[i] = summonButtonGroup.transform.GetChild(i).transform;
            summonButtonTexts[i] = summonButtonGroup.transform.GetChild(i).GetComponent<TMP_Text>();
        }
    }

    public void ActivateSuperSummon()
    {
        superSummonOn = !superSummonOn;
        if (superSummonOn)
        {
            image.color = Color.red;
            for (int i = 0; i < summonButtonCount; i++)
            {
                summonButtonTexts[i].text = TeamManager.instance.TeamCharacters[i].SuperSummonCost.ToString();
            }
        }
        else
        {
            image.color = Color.white;
        }
    }
}