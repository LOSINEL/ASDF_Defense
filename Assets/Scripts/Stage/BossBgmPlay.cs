using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBgmPlay : MonoBehaviour
{
    [SerializeField] SoundManager.BGM[] bossBgms;

    private void Start()
    {
        int rand = Random.Range(0, bossBgms.Length);
        SoundManager.instance.PlayBGM(bossBgms[rand]);
    }
}