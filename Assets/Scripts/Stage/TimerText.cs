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
        int startTime = (int)Time.time;
        int time;
        while (true)
        {
            time = (int)Time.time - startTime;
            if (time % 60 < 10)
            {
                timeText.text = $"{time / 60}:0{time % 60}";
            }
            else
            {
                timeText.text = $"{time / 60}:{time % 60}";
            }
            yield return waitRefreshTime;
        }
    }
}