using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    float damage;
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

    public void SetDamage(float _damage)
    {
        damage = _damage;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            collision.GetComponent<EnemyCharacter>().GetDamage(damage);
            Destroy(this.gameObject);
        }
        if (collision.CompareTag("EnemyHome"))
        {
            collision.GetComponent<Home>().GetDamage(damage);
            Destroy(this.gameObject);
        }
    }
}