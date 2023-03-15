using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeveloperButton : MonoBehaviour
{
    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(SelectButton);
    }

    void SelectButton()
    {
        GameManager.instance.AddGold(10000);
    }
}