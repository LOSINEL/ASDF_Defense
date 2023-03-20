using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossAlertImage : MonoBehaviour
{
    [SerializeField] float alphaTime;
    [SerializeField] Image alertImage;
    [SerializeField] Text alertText;

    private void Start()
    {
        StartCoroutine(PlayAlertImage());
    }

    IEnumerator PlayAlertImage()
    {
        Color color = alertImage.color;
        Color colort = alertText.color;
        float alphaNum = 1f / alphaTime;
        while (true)
        {
            if (color.a <= 0f)
            {
                gameObject.SetActive(false);
                yield break;
            }
            color.a -= Time.deltaTime * alphaNum;
            colort.a -= Time.deltaTime * alphaNum;
            alertImage.color = color;
            alertText.color = colort;
            yield return null;
        }
    }
}