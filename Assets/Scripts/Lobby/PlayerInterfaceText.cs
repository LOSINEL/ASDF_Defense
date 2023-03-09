using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInterfaceText : MonoBehaviour
{
    int gold;
    [SerializeField] TMP_Text goldText;

    private void Start()
    {
        gold = GameManager.instance.Gold;
        goldText.text = $"{gold}";
    }

    private void Update()
    {
        RefreshGoldText();
    }

    void RefreshGoldText()
    {
        goldText.text = $"{GameManager.instance.Gold}";
    }
}