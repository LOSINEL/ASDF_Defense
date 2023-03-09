using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneMoveButton : MonoBehaviour
{
    [SerializeField] Enums.SCENE_TYPE sceneType;

    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(MoveScene);
    }

    public void MoveScene()
    {
        SceneManager.LoadScene((int)sceneType);
    }
}