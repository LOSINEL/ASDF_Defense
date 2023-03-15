using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StageDefeatWindow : MonoBehaviour
{
    [SerializeField] TMP_Text titleText;
    [SerializeField] TMP_Text goldText;

    private void OnEnable()
    {
        titleText.text = $"STAGE{GameManager.instance.NowStage} DEFEAT";
        goldText.text = $"{GameManager.instance.GetDefeatGold()} Gold";
    }
}