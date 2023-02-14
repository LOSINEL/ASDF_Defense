using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SummonPortrait : MonoBehaviour
{
    Image image;
    RectTransform rectTransform;
    [SerializeField] float moveSpeed;
    Sprite superSprite;

    private void Awake()
    {
        image = GetComponent<Image>();
    }

    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        StartCoroutine(MoveLeft());
        StartCoroutine(AlphaUp());
    }

    IEnumerator MoveLeft()
    {
        while(true)
        {
            if (rectTransform.anchoredPosition.x - moveSpeed * Time.deltaTime < 0f)
            {
                rectTransform.anchoredPosition = Vector3.zero;
                SetSuperImage();
                yield break;
            }
            rectTransform.Translate(-1 * moveSpeed * Time.deltaTime, 0f, 0f);
            yield return null;
        }
    }

    IEnumerator AlphaUp()
    {
        Color color = image.color;
        while(true)
        {
            if (image.color.a >= 1f)
            {
                yield return new WaitForSeconds(0.5f);
                StartCoroutine(AlphaDown());
                yield break;
            }
            color.a += Time.deltaTime * 2f;
            image.color = color;
            yield return null;
        }
    }

    IEnumerator AlphaDown()
    {
        Color color = image.color;
        while(true)
        {
            if (image.color.a <= 0f)
            {
                Destroy(this.gameObject);
                yield break;
            }
            color.a -= Time.deltaTime * 3f;
            image.color = color;
            yield return null;
        }
    }

    public void SetImage(Enums.CHAR_TYPE _charType)
    {
        image.sprite = TeamManager.instance.CharacterDatas.GetValue(_charType).Portraits[(int)Enums.PORTRAIT_TYPE.SUMMON];
        image.SetNativeSize();
        superSprite = TeamManager.instance.CharacterDatas.GetValue(_charType).Portraits[(int)Enums.PORTRAIT_TYPE.SUPER];
    }

    void SetSuperImage()
    {
        image.sprite = superSprite;
        image.SetNativeSize();
    }

    public void SetSpeed(float _speed)
    {
        moveSpeed = _speed;
    }
}