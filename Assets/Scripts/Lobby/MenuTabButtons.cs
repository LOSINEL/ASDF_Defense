using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MenuTabButtons : MonoBehaviour
{
    [SerializeField] float menuTabMoveSpeed;
    [SerializeField] GameObject worldMapWindow;
    [SerializeField] GameObject manaWindow;
    [SerializeField] GameObject castleWindow;
    RectTransform rectTransform;
    Transform tr;

    private void Start()
    {
        tr = GetComponent<Transform>();
        rectTransform = GetComponent<RectTransform>();
    }

    public void SelectMenuTabBar()
    {
        Transform menuTabBarTr;
        menuTabBarTr = EventSystem.current.currentSelectedGameObject.transform;
        if (menuTabBarTr.localScale.x == 1f)
        {
            menuTabBarTr.localScale = new Vector3(-1f, 1f, 1f);
            StartCoroutine(MoveRightMenuTab(menuTabBarTr.GetComponent<Button>()));
        }
        else
        {
            menuTabBarTr.localScale = new Vector3(1f, 1f, 1f);
            StartCoroutine(MoveLeftMenuTab(menuTabBarTr.GetComponent<Button>()));
        }
    }

    IEnumerator MoveLeftMenuTab(Button _btn)
    {
        Vector2 basePos = rectTransform.anchoredPosition;
        _btn.interactable = false;
        while(true)
        {
            if (rectTransform.anchoredPosition.x - menuTabMoveSpeed * Time.unscaledDeltaTime < 0f)
            {
                basePos.x = 0f;
                rectTransform.anchoredPosition = basePos;
                _btn.interactable = true;
                yield break;
            }
            tr.Translate(new Vector2(menuTabMoveSpeed * Time.unscaledDeltaTime * -1, 0f));
            yield return null;
        }
    }

    IEnumerator MoveRightMenuTab(Button _btn)
    {
        Vector2 basePos = rectTransform.anchoredPosition;
        float moveDistance = rectTransform.rect.width;
        _btn.interactable = false;
        while (true)
        {
            if (rectTransform.anchoredPosition.x + menuTabMoveSpeed * Time.unscaledDeltaTime > moveDistance)
            {
                basePos.x = moveDistance;
                rectTransform.anchoredPosition = basePos;
                _btn.interactable = true;
                yield break;
            }
            tr.Translate(new Vector2(menuTabMoveSpeed * Time.unscaledDeltaTime, 0f));
            yield return null;
        }
    }

    public void SelectWorldMapButton()
    {
        worldMapWindow.SetActive(true);
    }

    public void SelectManaButton()
    {
        manaWindow.SetActive(true);
    }

    public void SelectCastleButton()
    {
        castleWindow.SetActive(true);
    }
}