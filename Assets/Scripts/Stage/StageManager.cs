using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageManager : MonoBehaviour
{
    public static StageManager instance;

    [SerializeField] GameObject clearWindow;
    [SerializeField] GameObject defeatWindow;
    [SerializeField] float gameTime = 0f;

    public float GameTime { get { return gameTime; } }

    private void Awake()
    {
        instance = this;
    }

    private void Update()
    {
        gameTime += Time.deltaTime;
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