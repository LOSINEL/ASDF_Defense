using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TeamCharacterButton : MonoBehaviour
{
    int charType;
    Image backImage;
    Image buttonImage;


    private void Start()
    {
        backImage = GetComponentsInChildren<Image>()[1];
        buttonImage = GetComponent<Image>();
        charType = transform.GetSiblingIndex();
        GetComponent<Button>().onClick.AddListener(ChangeTeamCharacter);
        SetImage();
    }

    void ChangeTeamCharacter()
    {
        TeamManager.instance.ChangeCharacter(charType);
        SetImage();
    }

    void SetImage()
    {
        backImage.sprite = TeamManager.instance.TeamCharacters[charType].Portraits[(int)Enums.PORTRAIT_TYPE.BUTTON];
        buttonImage.color = TeamManager.instance.PortraitBackgroundColors[(int)(TeamManager.instance.TeamCharacters[charType].CharType) / 3];
    }
}