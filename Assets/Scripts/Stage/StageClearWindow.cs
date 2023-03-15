using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StageClearWindow : MonoBehaviour
{
    [SerializeField] TMP_Text titleText;
    [SerializeField] TMP_Text goldText;

    private void OnEnable()
    {
        titleText.text = $"STAGE{GameManager.instance.NowStage} CLEAR!";
        goldText.text = $"{GameManager.instance.GetClearGold()} Gold";
    }
}