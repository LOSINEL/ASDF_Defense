using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WorldMapButtons : MonoBehaviour
{
    float lengthW;
    float lengthH;
    [SerializeField] GameObject worldMapBase;
    [SerializeField] Button[] worldMapButtons;
    [SerializeField] Vector3[] buttonSizes = new Vector3[9];
    [SerializeField] Vector3[] buttonPos = new Vector3[9];
    private void Start()
    {
        worldMapButtons = worldMapBase.GetComponentsInChildren<Button>();
        SaveButtons();
        lengthW = 2000f;
        lengthH = 1080f;
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.C))
        {
            InitButtons();
        }
        if (Input.GetKeyDown(KeyCode.B))
        {
            Debug.Log(GetComponent<RectTransform>().rect.size);
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            float sizeW = worldMapBase.GetComponent<RectTransform>().rect.width / lengthW;
            float sizeH = worldMapBase.GetComponent<RectTransform>().rect.height / lengthH;
            for (int i = 0; i < worldMapButtons.Length; i++)
            {
                worldMapButtons[i].transform.localScale = new Vector3(worldMapButtons[i].transform.localScale.x * sizeW, worldMapButtons[i].transform.localScale.y * sizeH, 1f);
                worldMapButtons[i].GetComponent<RectTransform>().anchoredPosition = new Vector3(worldMapButtons[i].GetComponent<RectTransform>().anchoredPosition.x * sizeW, worldMapButtons[i].GetComponent<RectTransform>().anchoredPosition.y * sizeH, 0f);
            }
        }
    }

    void InitButtons()
    {
        for (int i = 0; i < worldMapButtons.Length; i++)
        {
            worldMapButtons[i].GetComponent<RectTransform>().localScale = buttonSizes[i];
            worldMapButtons[i].GetComponent<RectTransform>().anchoredPosition = buttonPos[i];
        }
    }

    void SaveButtons()
    {
        for (int i = 0; i < worldMapButtons.Length; i++)
        {
            buttonSizes[i] = worldMapButtons[i].GetComponent<RectTransform>().localScale;
            buttonPos[i] = worldMapButtons[i].GetComponent<RectTransform>().anchoredPosition;
        }
    }
}