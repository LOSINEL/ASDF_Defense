using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterPortrait : MonoBehaviour
{
    [SerializeField] Image userImage;
    Image image;
    private void Start()
    {
        image = GetComponent<Image>();
    }
    public void SetCharacterPortrait(int _num)
    {
        image.sprite = TeamManager.instance.CharacterDatas[_num].Portraits[(int)Enums.PORTRAIT_TYPE.NORMAL];
    }
}