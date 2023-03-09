using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CastleCharacterButton : MonoBehaviour
{
    int charType;

    private void Start()
    {
        charType = transform.GetSiblingIndex();
        GetComponent<Button>().onClick.AddListener(SetCharacter);
    }

    void SetCharacter()
    {
        TeamManager.instance.SelectCastleCharacter(charType);
    }
}