using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EArrow : SingleAttack
{
    [SerializeField] float moveSpeed;
    [SerializeField] int arrowNum;
    Transform tr;
    float time;

    private void Awake()
    {
        tr = transform;
        tr.rotation = Quaternion.Euler(new Vector3(0f, 0f, 90f));
    }

    private void OnEnable()
    {
        InitArrow();
    }

    private void FixedUpdate()
    {
        tr.Translate(new Vector2(moveSpeed * Time.fixedDeltaTime, 0f), Space.World);
        if (Enemies.Count > 0)
        {
            Enemies[0].GetComponent<Hp>().SubHp(damage);
            gameObject.SetActive(false);
        }
        if (time >= 1f)
        {
            tr.parent = PoolManager.instance.ArrowGroups[arrowNum].transform;
            gameObject.SetActive(false);
        }
        time += Time.deltaTime;
    }

    public void InitArrow()
    {
        time = 0f;
        Enemies.Clear();
    }

    public void SetPosition(Vector3 _position)
    {
        tr.position = _position;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Character"))
        {
            Enemies.Add(collision.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Character"))
        {
            Enemies.Remove(collision.gameObject);
        }
    }
}