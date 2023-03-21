using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterPortrait : MonoBehaviour
{
    Image image;
    int num = 2;

    private void Start()
    {
        image = GetComponent<Image>();
        GetComponent<Button>().onClick.AddListener(SetCharacterPortrait);
    }
    void SetCharacterPortrait()
    {
        int tmp = -1;
        do { tmp = Random.Range(0, 15); } while (tmp == num);
        num = tmp;
        image.sprite = TeamManager.instance.CharacterDatas.GetValue((Enums.CHAR_TYPE)tmp).Portraits[(int)Enums.PORTRAIT_TYPE.NORMAL];
        image.SetNativeSize();
    }
}