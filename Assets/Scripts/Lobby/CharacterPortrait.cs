using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterPortrait : MonoBehaviour
{
    Image image;
    private void Start()
    {
        image = GetComponent<Image>();
    }
    public void SetCharacterPortrait(Enums.CHAR_TYPE _charType)
    {
        image.sprite = TeamManager.instance.CharacterDatas.GetValue(_charType).Portraits[(int)Enums.PORTRAIT_TYPE.NORMAL];
    }
}