using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class OptionCanvas : MonoBehaviour
{
    public static OptionCanvas instance;

    [SerializeField] GameObject optionGrayWindow;
    [SerializeField] GameObject bgmVolumeBarGroup;
    [SerializeField] GameObject sfxVolumeBarGroup;
    [SerializeField] TMP_Dropdown frameSelectDropdown;
    [SerializeField] float volumeBarScale;
    int[] fpsArr = { 60, 45, 30, 24 };
    float timeScale;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            if (instance != this)
            {
                Destroy(this.gameObject);
            }
        }
    }

    public void SelectOptionWindowButton()
    {
        optionGrayWindow.SetActive(!optionGrayWindow.activeSelf);
        if (optionGrayWindow.activeSelf)
        {
            timeScale = Time.timeScale;
            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = timeScale;
        }
    }

    public void SelectBgmVolumeUpButton()
    {
        int bgmVolume = CheckBgmVolumeBarNum();
        if (bgmVolume == bgmVolumeBarGroup.transform.childCount) return;
        bgmVolumeBarGroup.transform.GetChild(bgmVolume).gameObject.SetActive(true);
        SoundManager.instance.SetBgmVolume(volumeBarScale * (bgmVolume + 1));
    }

    public void SelectBgmVolumeDownButton()
    {
        int bgmVolume = CheckBgmVolumeBarNum();
        if (bgmVolume == 0) return;
        bgmVolumeBarGroup.transform.GetChild(bgmVolume - 1).gameObject.SetActive(false);
        SoundManager.instance.SetBgmVolume(volumeBarScale * (bgmVolume - 1));
    }

    public void SelectSfxVolumeUpButton()
    {
        int sfxVolume = CheckSfxVolumeBarNum();
        if (sfxVolume == sfxVolumeBarGroup.transform.childCount) return;
        sfxVolumeBarGroup.transform.GetChild(sfxVolume).gameObject.SetActive(true);
        SoundManager.instance.SetSfxVolume(volumeBarScale * (sfxVolume + 1));
    }

    public void SelectSfxVolumeDownButton()
    {
        int sfxVolume = CheckSfxVolumeBarNum();
        if (sfxVolume == 0) return;
        sfxVolumeBarGroup.transform.GetChild(sfxVolume - 1).gameObject.SetActive(false);
        SoundManager.instance.SetSfxVolume(volumeBarScale * (sfxVolume - 1));
    }

    int CheckBgmVolumeBarNum()
    {
        return bgmVolumeBarGroup.GetComponentsInChildren<Image>().Length;
    }

    int CheckSfxVolumeBarNum()
    {
        return sfxVolumeBarGroup.GetComponentsInChildren<Image>().Length;
    }

    public void ChangeGameFps()
    {
        Application.targetFrameRate = fpsArr[frameSelectDropdown.value];
    }
}