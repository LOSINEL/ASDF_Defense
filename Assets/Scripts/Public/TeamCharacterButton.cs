using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TeamCharacterButton : MonoBehaviour
{
    int charType;

    private void Start()
    {
        charType = transform.GetSiblingIndex();
        GetComponent<Button>().onClick.AddListener(ChangeTeamCharacter);
    }

    void ChangeTeamCharacter()
    {
        TeamManager.instance.ChangeCharacter(charType);
        GetComponentsInChildren<Image>()[1].sprite = TeamManager.instance.TeamCharacters[charType].Portraits[(int)Enums.PORTRAIT_TYPE.BUTTON];
        GetComponent<Image>().color = TeamManager.instance.PortraitBackgroundColors[(int)(TeamManager.instance.TeamCharacters[charType].CharType) / 3];
    }
}