using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimerText : MonoBehaviour
{
    [SerializeField] float refreshTime;
    WaitForSeconds waitRefreshTime;
    TMP_Text timeText;

    private void Start()
    {
        waitRefreshTime = new WaitForSeconds(refreshTime);
        timeText = GetComponent<TMP_Text>();
        StartCoroutine(PlayTimer());
    }

    IEnumerator PlayTimer()
    {
        float time = 0f;
        while (true)
        {
            time += refreshTime * TimeManager.instance.TimeScale;
            timeText.text = $"{time / 60:f0}:{time % 60:f0}";
            yield return waitRefreshTime;
        }
    }
}