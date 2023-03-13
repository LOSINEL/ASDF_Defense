using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SfxPlay : MonoBehaviour
{
    [SerializeField] SoundManager.SFX sfxSound;

    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(PlaySfx);
    }

    public void PlaySfx()
    {
        SoundManager.instance.PlaySFX(sfxSound);
    }
}