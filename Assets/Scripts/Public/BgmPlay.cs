using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgmPlay : MonoBehaviour
{
    [SerializeField] SoundManager.BGM bgmSound;
    private void Start()
    {
        SoundManager.instance.PlayBGM(bgmSound);
    }
}