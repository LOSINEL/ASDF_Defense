using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ManaWindowText : MonoBehaviour
{
    public static ManaWindowText instance;

    [SerializeField] TMP_Text maxManaText;
    [SerializeField] TMP_Text recoverManaText;
    [SerializeField] TMP_Text maxManaUpgradeText;
    [SerializeField] TMP_Text recoverManaUpgradeText;
    [SerializeField] TMP_Text upgradeGoldText;

    private void Awake()
    {
        instance = this;
        RefreshTexts();
    }

    public void RefreshTexts()
    {
        maxManaText.text = $"MAX MANA {(int)ManaManager.instance.MaxMana}";
        recoverManaText.text = $"MANA RECOVER {ManaManager.instance.ManaRecovery}/s";
        maxManaUpgradeText.text = $"MAX MANA + {(int)ManaManager.instance.MaxManaUpgradeNum}";
        recoverManaUpgradeText.text = $"MANA RECOVER + {ManaManager.instance.ManaRecoveryUpgradeNum:F1}/s";
        upgradeGoldText.text = $"{ManaManager.instance.UpgradeGold} Gold";
    }
}