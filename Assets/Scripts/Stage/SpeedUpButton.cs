using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpeedUpButton : MonoBehaviour
{
    public void SelectSpeedUpButton()
    {
        SoundManager.instance.PlaySFX(SoundManager.SFX.BUTTON_CLICK);
        if (GetComponent<Toggle>().isOn)
        {
            Time.timeScale = 2f;
        }
        else
        {
            Time.timeScale = 1f;
        }
    }
}