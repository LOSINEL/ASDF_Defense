using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DataResetButton : MonoBehaviour
{
    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(ResetData);
    }

    void ResetData()
    {
        SaveManager.instance.DeleteAllData();
    }
}