using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageBgmPlay : MonoBehaviour
{
    [SerializeField] SoundManager.BGM[] stageBgms;

    private void Start()
    {
        int rand = Random.Range(0, stageBgms.Length);
        SoundManager.instance.PlayBGM(stageBgms[rand]);
    }
}