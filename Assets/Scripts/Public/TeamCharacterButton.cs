using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TeamCharacterButton : MonoBehaviour
{
    int slotNum;
    Image backImage;
    Image buttonImage;


    private void Start()
    {
        backImage = GetComponentsInChildren<Image>()[1];
        buttonImage = GetComponent<Image>();
        slotNum = transform.GetSiblingIndex();
        GetComponent<Button>().onClick.AddListener(ChangeTeamCharacter);
        SetImage();
    }

    void ChangeTeamCharacter()
    {
        TeamManager.instance.ChangeCharacter(slotNum);
        SetImage();
    }

    void SetImage()
    {
        backImage.sprite = TeamManager.instance.TeamCharacters[slotNum].Portraits[(int)Enums.PORTRAIT_TYPE.BUTTON];
        buttonImage.color = TeamManager.instance.PortraitBackgroundColors[(int)(TeamManager.instance.TeamCharacters[slotNum].CharType) / Nums.characterGradeNum];
    }
}