using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeManager : MonoBehaviour
{
    public static UpgradeManager instance;

    [SerializeField] GameObject characterInfoWindow;

    [SerializeField] CharacterData characterData;

    [SerializeField] Image characterPortraitImage;
    [SerializeField] Text damageText;
    [SerializeField] Text maxHpText;
    [SerializeField] Text moveSpeedText;
    [SerializeField] Text attackSpeedText;
    [SerializeField] Text upgradeGoldText;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        InitWindow();
    }

    private void Update()
    {
        RefreshWindow();
    }

    public void SetCharacter(Enums.CHAR_TYPE charType)
    {
        characterData = TeamManager.instance.CharacterDatas.GetValue(charType);
        characterPortraitImage.sprite = characterData.Portraits[(int)Enums.PORTRAIT_TYPE.MINI];
    }

    public bool GetUpgradable()
    {
        if (GameManager.instance.Gold >= characterData.UpgradeCost) return true;
        else return false;
    }

    public void UpgradeCharacter()
    {
        GameManager.instance.SubGold(characterData.UpgradeCost);
        characterData.Upgrade();
    }

    void RefreshWindow()
    {
        if (characterInfoWindow.activeSelf)
        {
            damageText.text = $"데미지 : {characterData.Damage:#}(+{(characterData.BaseDamage * characterData.UpgradePower):#.#})";
            maxHpText.text = $"Hp : {characterData.MaxHp:#}(+{(characterData.BaseMaxHp * characterData.UpgradePower):#.#})";
            moveSpeedText.text = $"이동속도 : {characterData.MoveSpeed}(+{(characterData.BaseMoveSpeed * characterData.UpgradePower):#.#})";
            attackSpeedText.text = $"공격속도 : {characterData.AttackSpeed}(+{(characterData.BaseAttackSpeed * characterData.UpgradePower):#.#})/s";
            upgradeGoldText.text = $"{characterData.UpgradeCost} Gold";
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