using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hp : MonoBehaviour
{
    [SerializeField] protected float maxHp;
    [SerializeField] protected float nowHp;
    [SerializeField] protected BoxCollider2D boxCollider;

    public void SubHp(float _damage)
    {
        if (nowHp - _damage <= 0f)
        {
            nowHp = 0f;
            if (boxCollider.enabled)
            {
                boxCollider.enabled = false;
            }
        }
        else
        {
            nowHp -= _damage;
        }
    }
}