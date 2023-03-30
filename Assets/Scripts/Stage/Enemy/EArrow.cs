using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EArrow : SingleAttack, IFixedUpdate
{
    [SerializeField] float moveSpeed;
    [SerializeField] int arrowNum;
    Transform tr;
    Rigidbody2D rigid;
    float time;
    IFixedUpdate iFixedUpdate;
    float fixedDeltaTime;

    private void Awake()
    {
        fixedDeltaTime = Time.fixedDeltaTime;
        iFixedUpdate = GetComponent<IFixedUpdate>();
        tr = transform;
        rigid = GetComponent<Rigidbody2D>();
        tr.rotation = Quaternion.Euler(new Vector3(0f, 0f, -90f));
    }

    private void OnEnable()
    {
        InitArrow();
        FixedUpdateManager.instance.FixedUpdateList.Add(iFixedUpdate);
    }

    private void OnDisable()
    {
        Enemies.Clear();
        FixedUpdateManager.instance.FixedUpdateList.Remove(iFixedUpdate);
    }

    public void ManagedFixedUpdate()
    {
        rigid.MovePosition(rigid.position -= new Vector2(moveSpeed * fixedDeltaTime * TimeManager.instance.TimeScale, 0f));
        if (Enemies.Count > 0)
        {
            Enemies[0].GetComponent<Hp>().SubHp(damage);
            SoundManager.instance.PlaySFX(SoundManager.SFX.ARROW_ATTACK);
            gameObject.SetActive(false);
        }
        if (time >= 1f)
        {
            gameObject.SetActive(false);
        }
        time += Time.fixedDeltaTime * TimeManager.instance.TimeScale;
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
        if (collision.CompareTag("Character"))
        {
            Enemies.Add(collision.gameObject);
        }
    }
}