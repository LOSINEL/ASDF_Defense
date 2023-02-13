using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    [SerializeField] AudioSource bgmPlayer;
    [SerializeField] AudioSource sfxPlayer;

    [SerializeField] AudioClip[] bgm;
    [SerializeField] AudioClip[] sfx;

    public enum BGM { MAIN_MENU, ENUM_SIZE }
    public enum SFX { BUTTON_CLICK, ENUM_SIZE }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public void PlaySFX(SFX _sfx)
    {
        sfxPlayer.PlayOneShot(sfx[(int)_sfx]);
    }

    public void PlayBGM(BGM _bgm)
    {
        StopBGM();
        bgmPlayer.clip = bgm[(int)_bgm];
        bgmPlayer.Play();
    }

    public void StopBGM()
    {
        bgmPlayer.Stop();
    }

    public void PauseBGM()
    {
        bgmPlayer.Pause();
    }

    public void ResumeBGM()
    {
        bgmPlayer.UnPause();
    }

    public void SetBgmVolume(float _volume)
    {
        bgmPlayer.volume = _volume;
    }

    public void SetSfxVolume(float _volume)
    {
        sfxPlayer.volume = _volume;
    }
}