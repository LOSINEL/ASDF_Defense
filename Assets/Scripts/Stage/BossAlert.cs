using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAlert : MonoBehaviour
{
    public static BossAlert instance;

    [SerializeField] GameObject bossAlertImage;

    private void Awake()
    {
        instance = this;
    }

    public void PlayBossAlert()
    {
        bossAlertImage.SetActive(true);
    }
}