using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CameraMoveSwipe : MonoBehaviour
{
    [SerializeField] Transform allyHomeTr;
    [SerializeField] Transform enemyHomeTr;
    Transform tr;
    float minXPos;
    float maxXPos;
    float deltaXPos;

    private void Start()
    {
        tr = transform;
        tr.position = new Vector3(0f, 0f, -10f);
        minXPos = allyHomeTr.position.x;
        maxXPos = enemyHomeTr.position.x;
    }

    private void Update()
    {
        if (Input.touchCount > 0)
        {
            deltaXPos = Input.GetTouch(0).deltaPosition.x;
            if (tr.position.x - deltaXPos < minXPos) return;
            else if (tr.position.x - deltaXPos > maxXPos) return;
            tr.Translate(-deltaXPos, 0f, 0f);
        }
    }
}