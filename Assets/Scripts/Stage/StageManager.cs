using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : MonoBehaviour
{
    public static StageManager instance;

    [SerializeField] GameObject clearWindow;
    [SerializeField] GameObject defeatWindow;

    private void Awake()
    {
        instance = this;
    }

    public void ActivateClearWindow(bool _ally)
    {
        if (!_ally)
        {
            clearWindow.SetActive(true);
        }
        else
        {
            defeatWindow.SetActive(true);
        }
    }
}