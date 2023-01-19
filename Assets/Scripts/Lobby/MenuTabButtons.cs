using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MenuTabButtons : MonoBehaviour
{
    [SerializeField] float menuTabMoveSpeed;
    RectTransform rectTransform;

    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    public void SelectMenuTabBar()
    {
        GameObject menuTabBar;
        menuTabBar = EventSystem.current.currentSelectedGameObject;
        if (menuTabBar.transform.localScale.x == 1f)
        {
            menuTabBar.transform.localScale = new Vector3(-1f, 1f, 1f);
            StartCoroutine(MoveRightMenuTab(menuTabBar.GetComponent<Button>()));
        }
        else
        {
            menuTabBar.transform.localScale = new Vector3(1f, 1f, 1f);
            StartCoroutine(MoveLeftMenuTab(menuTabBar.GetComponent<Button>()));
        }
    }

    IEnumerator MoveLeftMenuTab(Button _btn)
    {
        Vector2 basePos = rectTransform.anchoredPosition;
        _btn.interactable = false;
        while(true)
        {
            if (rectTransform.anchoredPosition.x < 0f)
            {
                basePos.x = 0f;
                rectTransform.anchoredPosition = basePos;
                _btn.interactable = true;
                yield break;
            }
            transform.Translate(new Vector2(menuTabMoveSpeed * Time.deltaTime * -1, 0f));
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
            if (rectTransform.anchoredPosition.x > moveDistance)
            {
                basePos.x = moveDistance;
                rectTransform.anchoredPosition = basePos;
                _btn.interactable = true;
                yield break;
            }
            transform.Translate(new Vector2(menuTabMoveSpeed * Time.deltaTime, 0f));
            yield return null;
        }
    }

    public void SelectDungeonButton()
    {
    }

    public void SelectInventoryButton()
    {
    }

    public void SelectCastleButton()
    {
    }

    public void SelectMissionButton()
    {
    }
}