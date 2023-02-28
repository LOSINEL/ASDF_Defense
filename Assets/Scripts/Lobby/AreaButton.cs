using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AreaButton : MonoBehaviour
{
    [SerializeField] int areaNum;

    private void Start()
    {
        areaNum = transform.GetSiblingIndex() + 1;
        if (GameManager.instance.MaxStage < areaNum)
        {
            GetComponent<Button>().interactable = false;
        }
        else
        {
            GetComponent<Button>().interactable = true;
        }
    }

    public void StartStage()
    {
        GameManager.instance.SetNowStage(areaNum);
        SceneManager.LoadScene(2);
    }
}