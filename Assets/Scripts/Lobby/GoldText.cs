using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GoldText : MonoBehaviour
{
    [SerializeField] TMP_Text goldText;

    private void Update()
    {
        goldText.text = $"{GameManager.instance.Gold}";
    }
}