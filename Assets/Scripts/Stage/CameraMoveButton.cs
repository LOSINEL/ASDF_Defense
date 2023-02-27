using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMoveButton : MonoBehaviour
{
    [SerializeField] Transform mainCamera;
    int num = 0;

    private void Start()
    {
        mainCamera.position = new Vector3(0f, 0f, -10f);
    }

    public void SelectMoveButton(bool _tf)
    {
        if (_tf)
        {
            if (num >= 2) return;
            num++;
            mainCamera.Translate(new Vector3(600f, 0f, 0f));
        }
        else
        {
            if (num <= -2) return;
            num--;
            mainCamera.Translate(new Vector3(-600f, 0f, 0f));
        }
    }
}