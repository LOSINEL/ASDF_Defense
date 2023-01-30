using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartButtonScaler : MonoBehaviour
{
    [SerializeField] float minSize;
    [SerializeField] float maxSize;
    [SerializeField] float scaleSpeed;
    float _scaleAmount;
    bool goBigger = true;

    private void Start()
    {
        transform.localScale = Vector3.one;
    }

    private void Update()
    {
        _scaleAmount = scaleSpeed * Time.deltaTime;
        if (goBigger)
        {
            if (transform.localScale.x >= maxSize) goBigger = false;
            transform.localScale += new Vector3(_scaleAmount, _scaleAmount, _scaleAmount);
        }
        else
        {
            if (transform.localScale.x <= minSize) goBigger = true;
            transform.localScale -= new Vector3(_scaleAmount, _scaleAmount, _scaleAmount);
        }
    }
}