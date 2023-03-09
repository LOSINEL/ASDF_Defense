using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonAlpha : MonoBehaviour
{
    const float alphaNum = 0.1f;
    void Awake()
    {
        GetComponent<Image>().alphaHitTestMinimumThreshold = alphaNum;
    }
}