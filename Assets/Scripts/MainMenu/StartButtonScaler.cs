using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartButtonScaler : MonoBehaviour
{
    [SerializeField] float minSize;
    [SerializeField] float maxSize;
    [SerializeField] float scaleSpeed;
    float scaleAmount;
    bool goBigger = true;
    Transform tr;
    Vector3 scaleVector3;

    private void Start()
    {
        tr = GetComponent<Transform>();
        tr.localScale = Vector3.one;
    }

    private void Update()
    {
        scaleAmount = scaleSpeed * Time.deltaTime;
        scaleVector3 = new Vector3(scaleAmount, scaleAmount, scaleAmount);
        if (goBigger)
        {
            if (tr.localScale.x >= maxSize) goBigger = false;
            tr.localScale += scaleVector3;
        }
        else
        {
            if (tr.localScale.x <= minSize) goBigger = true;
            tr.localScale -= scaleVector3;
        }
    }
}