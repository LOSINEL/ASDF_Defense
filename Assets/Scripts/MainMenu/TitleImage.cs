using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleImage : MonoBehaviour
{
    const float startWaitTime = 0.5f;
    [SerializeField] float moveSpeed;
    [SerializeField] Vector2 startPos;
    Transform tr;
    WaitForSeconds waitForSeconds = new WaitForSeconds(startWaitTime);

    private void Start()
    {
        tr = GetComponent<Transform>();
        tr.localPosition = startPos;
        StartCoroutine(DropTitleImage());
    }

    IEnumerator DropTitleImage()
    {
        yield return waitForSeconds;
        while (true)
        {
            if (tr.localPosition.y - moveSpeed * Time.unscaledDeltaTime <= 0f)
            {
                tr.localPosition = new Vector2(0f, 0f);
                yield break;
            }
            tr.Translate(Vector2.down * moveSpeed * Time.unscaledDeltaTime);
            yield return null;
        }
    }
}