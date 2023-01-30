using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SummonButton : MonoBehaviour
{
    [SerializeField] GameObject character;
    [SerializeField] float summonCooltime;
    [SerializeField] float summonCost;

    [SerializeField] Image coolTimeImage;

    private void Start()
    {
        InitButton();
    }

    void InitButton()
    {
        coolTimeImage.fillAmount = 0f;
    }

    public void SetButton(GameObject _character, float _coolTime, float _cost)
    {
        character = _character;
        summonCooltime = _coolTime;
        summonCost = _cost;
    }

    public void SummonCharacter()
    {
    }
}