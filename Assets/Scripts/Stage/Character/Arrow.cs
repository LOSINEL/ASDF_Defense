using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : SingleAttack
{
    [SerializeField] float moveSpeed;
    [SerializeField] int arrowNum;
    [SerializeField] int maxAttack;
    [SerializeField] float waitTime;
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
        StartCoroutine(PlayArrow());
    }

    IEnumerator PlayArrow()
    {
        WaitForSeconds _waitTime = new WaitForSeconds(waitTime);
        while (true)
        {
            tr.Translate(new Vector2(moveSpeed * waitTime, 0f), Space.World);
            if (Enemies.Count > 0)
            {
                for (int i = 0; i < Enemies.Count; i++)
                {
                    if (i == maxAttack) break;
                    Enemies[i].GetComponent<Hp>().SubHp(damage);
                }
                SoundManager.instance.PlaySFX(SoundManager.SFX.ARROW_ATTACK);
                gameObject.SetActive(false);
                yield break;
            }
            if (time >= 1f)
            {
                gameObject.SetActive(false);
                yield break;
            }
            time += waitTime;
            yield return _waitTime;
        }
    }

    public void InitArrow()
    {
        time = 0f;
    }

    public void SetPosition(Vector3 _position)
    {
        tr.position = _position;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            Enemies.Add(collision.gameObject);
        }
    }
}