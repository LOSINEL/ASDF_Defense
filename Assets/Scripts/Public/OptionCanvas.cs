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
    int[] fpsArr = { 60, 45, 30, 20 };
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

    private void Start()
    {
        if (SaveManager.instance.CheckHasKey(Strings.bgmVolumeBarNum))
        {
            ActivateBgmVolumeBar(SaveManager.instance.LoadDataInt(Strings.bgmVolumeBarNum));
        }
        if (SaveManager.instance.CheckHasKey(Strings.sfxVolumeBarNum))
        {
            ActivateSfxVolumeBar(SaveManager.instance.LoadDataInt(Strings.sfxVolumeBarNum));
        }
    }

    void ActivateBgmVolumeBar(int num)
    {
        int count = bgmVolumeBarGroup.transform.childCount;
        for (int i = 0; i < count; i++)
        {
            if (i >= num) bgmVolumeBarGroup.transform.GetChild(i).gameObject.SetActive(false);
        }
        SoundManager.instance.SetBgmVolume(num * Nums.volumeBarScale);
    }

    void ActivateSfxVolumeBar(int num)
    {
        int count = sfxVolumeBarGroup.transform.childCount;
        for (int i = 0; i < count; i++)
        {
            if (i >= num) sfxVolumeBarGroup.transform.GetChild(i).gameObject.SetActive(false);
        }
        SoundManager.instance.SetSfxVolume(num * Nums.volumeBarScale);
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

    public void SetSound()
    {
        SaveManager.instance.SetData(Strings.bgmVolumeBarNum, CheckBgmVolumeBarNum());
        SaveManager.instance.SetData(Strings.sfxVolumeBarNum, CheckSfxVolumeBarNum());
    }

    public void SelectBgmVolumeUpButton()
    {
        int bgmVolume = CheckBgmVolumeBarNum();
        if (bgmVolume == bgmVolumeBarGroup.transform.childCount) return;
        bgmVolumeBarGroup.transform.GetChild(bgmVolume).gameObject.SetActive(true);
        SoundManager.instance.SetBgmVolume(Nums.volumeBarScale * (bgmVolume + 1));
    }

    public void SelectBgmVolumeDownButton()
    {
        int bgmVolume = CheckBgmVolumeBarNum();
        if (bgmVolume == 0) return;
        bgmVolumeBarGroup.transform.GetChild(bgmVolume - 1).gameObject.SetActive(false);
        SoundManager.instance.SetBgmVolume(Nums.volumeBarScale * (bgmVolume - 1));
    }

    public void SelectSfxVolumeUpButton()
    {
        int sfxVolume = CheckSfxVolumeBarNum();
        if (sfxVolume == sfxVolumeBarGroup.transform.childCount) return;
        sfxVolumeBarGroup.transform.GetChild(sfxVolume).gameObject.SetActive(true);
        SoundManager.instance.SetSfxVolume(Nums.volumeBarScale * (sfxVolume + 1));
    }

    public void SelectSfxVolumeDownButton()
    {
        int sfxVolume = CheckSfxVolumeBarNum();
        if (sfxVolume == 0) return;
        sfxVolumeBarGroup.transform.GetChild(sfxVolume - 1).gameObject.SetActive(false);
        SoundManager.instance.SetSfxVolume(Nums.volumeBarScale * (sfxVolume - 1));
    }

    public int CheckBgmVolumeBarNum()
    {
        return bgmVolumeBarGroup.GetComponentsInChildren<Image>().Length;
    }

    public int CheckSfxVolumeBarNum()
    {
        return sfxVolumeBarGroup.GetComponentsInChildren<Image>().Length;
    }

    public void ChangeGameFps()
    {
        Application.targetFrameRate = fpsArr[frameSelectDropdown.value];
    }

    private void OnApplicationQuit()
    {
        SetSound();
        PlayerPrefs.Save();
    }
}