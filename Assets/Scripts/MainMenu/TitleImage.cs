using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleImage : MonoBehaviour
{
    const float startWaitTime = 0.5f;
    [SerializeField] float moveSpeed;
    [SerializeField] Vector2 startPos;

    private void Start()
    {
        transform.localPosition = startPos;
        StartCoroutine(DropTitleImage());
    }

    IEnumerator DropTitleImage()
    {
        yield return new WaitForSeconds(startWaitTime);
        while (true)
        {
            if (transform.localPosition.y - moveSpeed * Time.deltaTime <= 0f)
            {
                transform.localPosition = new Vector2(0f, 0f);
                yield break;
            }
            transform.Translate(Vector2.down * moveSpeed * Time.deltaTime);
            yield return null;
        }
    }
}