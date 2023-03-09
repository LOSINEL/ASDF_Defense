using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AreaButton : MonoBehaviour
{
    int areaNum;

    private void Start()
    {
        areaNum = transform.GetSiblingIndex() + 1;
        if (GameManager.instance.MaxStage >= areaNum)
        {
            GetComponent<Button>().interactable = true;
        }
        else
        {
            GetComponent<Button>().interactable = false;
        }
        GetComponent<Button>().onClick.AddListener(StartStage);
    }

    public void StartStage()
    {
        GameManager.instance.SetNowStage(areaNum);
        SceneManager.LoadScene((int)Enums.SCENE_TYPE.STAGE);
    }
}