using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeButton : MonoBehaviour
{
    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(SelectUpgradeCharacterButton);
    }

    void SelectUpgradeCharacterButton()
    {
        if (UpgradeManager.instance.GetUpgradable())
        {
            UpgradeManager.instance.UpgradeCharacter();
        }
    }
}