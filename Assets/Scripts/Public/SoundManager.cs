using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    [SerializeField] AudioSource bgmPlayer;
    [SerializeField] AudioSource[] sfxPlayers = new AudioSource[(int)SFX.ENUM_SIZE];

    [SerializeField] AudioClip[] bgm = new AudioClip[(int)BGM.ENUM_SIZE];
    [SerializeField] AudioClip[] sfx = new AudioClip[(int)SFX.ENUM_SIZE];

    public enum BGM { MAIN_MENU, LOBBY, STAGE1, STAGE2, STAGE3, STAGE4, BOSS1, BOSS2, BOSS3, BOSS4, ENUM_SIZE }
    public enum SFX { BUTTON_CLICK, WARRIOR_ATTACK, ARCHER_ATTACK, ARROW_ATTACK, ASSASSIN_ATTACK, MAGICIAN_ATTACK1, MAGICIAN_ATTACK2, MAGICIAN_ATTACK3, EMAGICIAN_ATTACK, ENUM_SIZE }

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
        bgmPlayer = gameObject.AddComponent<AudioSource>();
        for (int i = 0; i < (int)SFX.ENUM_SIZE; i++)
        {
            sfxPlayers[i] = gameObject.AddComponent<AudioSource>();
            sfxPlayers[i].clip = sfx[i];
        }
    }

    public void PlaySFX(SFX _sfx)
    {
        if (!sfxPlayers[(int)_sfx].isPlaying)
            sfxPlayers[(int)_sfx].PlayOneShot(sfx[(int)_sfx]);
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
        for (int i = 0; i < (int)SFX.ENUM_SIZE; i++)
        {
            sfxPlayers[i].volume = _volume;
        }
    }
}