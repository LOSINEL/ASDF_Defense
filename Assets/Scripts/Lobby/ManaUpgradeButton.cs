using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManaUpgradeButton : MonoBehaviour
{
    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(UpgradeMana);
    }

    public void UpgradeMana()
    {
        ManaManager.instance.UpgradeMana();
    }
}