using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoLobbyButton : MonoBehaviour
{
    [SerializeField] GameObject goLobbyButton;

    private void OnEnable()
    {
        if (SceneManager.GetActiveScene().buildIndex == (int)Enums.SCENE_TYPE.STAGE)
        {
            goLobbyButton.SetActive(true);
        }
        else
        {
            goLobbyButton.SetActive(false);
        }
    }
}