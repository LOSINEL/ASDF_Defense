using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : MonoBehaviour
{
    public static StageManager instance;

    [SerializeField] GameObject winWindow;
    [SerializeField] GameObject defeatWindow;

    private void Awake()
    {
        instance = this;
    }

    public void ActivateWinWindow(bool _ally)
    {
        if (_ally)
        {
            winWindow.SetActive(true);
        }
        else
        {
            defeatWindow.SetActive(true);
        }
    }
}