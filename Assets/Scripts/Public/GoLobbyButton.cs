using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoLobbyButton : MonoBehaviour
{
    [SerializeField] GameObject goLobbyButton;
    [SerializeField] GameObject gameExitButton;

    private void OnEnable()
    {
        if (SceneManager.GetActiveScene().buildIndex == (int)Enums.SCENE_TYPE.STAGE)
        {
            goLobbyButton.SetActive(true);
            gameExitButton.SetActive(false);
        }
        else
        {
            goLobbyButton.SetActive(false);
            gameExitButton.SetActive(true);
        }
    }
}