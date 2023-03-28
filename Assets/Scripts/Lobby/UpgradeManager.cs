using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeManager : MonoBehaviour
{
    public static UpgradeManager instance;

    [SerializeField] GameObject characterInfoWindow;

    [SerializeField] CharacterData selectedCharacterData;

    [SerializeField] Image characterPortraitImage;
    [SerializeField] Text damageText;
    [SerializeField] Text maxHpText;
    [SerializeField] Text moveSpeedText;
    [SerializeField] Text attackSpeedText;
    [SerializeField] Text upgradeGoldText;

    [SerializeField] int upgradeLevelMax;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        InitWindow();
    }

    public void SelectCharacter(Enums.CHAR_TYPE charType)
    {
        selectedCharacterData = TeamManager.instance.CharacterDatas.GetValue(charType);
        characterPortraitImage.sprite = selectedCharacterData.Portraits[(int)Enums.PORTRAIT_TYPE.MINI];
        RefreshWindow();
    }

    public bool CheckUpgradable()
    {
        if (GameManager.instance.Gold >= selectedCharacterData.UpgradeCost) return true;
        else return false;
    }

    public void UpgradeCharacter()
    {
        GameManager.instance.SubGold(selectedCharacterData.UpgradeCost);
        selectedCharacterData.Upgrade();
        RefreshWindow();
    }

    public bool CheckMaxLevel()
    {
        if (selectedCharacterData.Level >= upgradeLevelMax) return true;
        else return false;
    }

    void RefreshWindow()
    {
        if (characterInfoWindow.activeSelf)
        {
            damageText.text = $"데미지 : {selectedCharacterData.Damage:F0}(+{(selectedCharacterData.BaseDamage * selectedCharacterData.UpgradePower):F1})";
            maxHpText.text = $"Hp : {selectedCharacterData.MaxHp:F0}(+{(selectedCharacterData.BaseMaxHp * selectedCharacterData.UpgradePower):F1})";
            moveSpeedText.text = $"이동속도 : {selectedCharacterData.MoveSpeed:F0}(+{(selectedCharacterData.BaseMoveSpeed * selectedCharacterData.UpgradePower):F2})";
            attackSpeedText.text = $"공격속도 : {selectedCharacterData.AttackSpeed:F2}(+{(selectedCharacterData.BaseAttackSpeed * selectedCharacterData.UpgradePower):F3})/s";
            upgradeGoldText.text = $"{selectedCharacterData.UpgradeCost} Gold";
        }
    }

    void InitWindow()
    {
        characterPortraitImage.sprite = null;
        damageText.text = "";
        maxHpText.text = "";
        moveSpeedText.text = "";
        attackSpeedText.text = "";
        upgradeGoldText.text = "";
        characterInfoWindow.SetActive(false);
    }

    public void ActivateCharacterInfoWindow()
    {
        characterInfoWindow.SetActive(true);
    }
}