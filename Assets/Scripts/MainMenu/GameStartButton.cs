using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameStartButton : MonoBehaviour
{
    [SerializeField] float waitTime;

    private void Start()
    {
        StartCoroutine(ActivateButton());
    }

    IEnumerator ActivateButton()
    {
        yield return new WaitForSecondsRealtime(waitTime);
        GetComponent<Button>().interactable = true;
    }
}