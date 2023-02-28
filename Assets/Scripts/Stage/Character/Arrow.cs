using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : Weapon
{
    [SerializeField] float moveSpeed;
    Transform tr;

    private void Start()
    {
        tr = transform;
        tr.Rotate(0f, 0f, 90f);
        Destroy(this.gameObject, 1f);
    }

    private void Update()
    {
        tr.Translate(new Vector2(moveSpeed * Time.deltaTime, 0f), Space.World);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            collision.GetComponent<Hp>().SubHp(damage);
            Destroy(this.gameObject);
        }
    }
}