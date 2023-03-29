using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EArrow : SingleAttack, IFixedUpdate
{
    [SerializeField] float moveSpeed;
    [SerializeField] int arrowNum;
    Transform tr;
    float time;
    IFixedUpdate iFixedUpdate;

    private void Awake()
    {
        iFixedUpdate = GetComponent<IFixedUpdate>();
        tr = transform;
        tr.rotation = Quaternion.Euler(new Vector3(0f, 0f, -90f));
    }

    private void OnEnable()
    {
        InitArrow();
        FixedUpdateManager.instance.FixedUpdateList.Add(iFixedUpdate);
    }

    private void OnDisable()
    {
        FixedUpdateManager.instance.FixedUpdateList.Remove(iFixedUpdate);
    }

    public void ManagedFixedUpdate()
    {
        tr.Translate(new Vector2(-moveSpeed * Time.fixedDeltaTime, 0f), Space.World);
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
        time += Time.fixedDeltaTime;
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