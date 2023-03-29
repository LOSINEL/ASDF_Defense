using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    public static TimeManager instance;

    int timeScale = 1;

    public int TimeScale { get { return timeScale; } }

    private void Awake()
    {
        instance = this;
    }

    public void SetDoubleSpeed()
    {
        timeScale = 2;
    }

    public void SetNormalSpeed()
    {
        timeScale = 1;
    }
}