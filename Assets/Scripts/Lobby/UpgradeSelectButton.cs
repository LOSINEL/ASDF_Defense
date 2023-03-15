using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeSelectButton : MonoBehaviour
{
    Enums.CHAR_TYPE charType;

    private void Start()
    {
        charType = (Enums.CHAR_TYPE)transform.GetSiblingIndex();
        GetComponent<Button>().onClick.AddListener(SelectUpgradeCharacterButton);
    }

    void SelectUpgradeCharacterButton()
    {
        UpgradeManager.instance.ActivateCharacterInfoWindow();
        UpgradeManager.instance.SetCharacter(charType);
    }
}