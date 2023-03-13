using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicianAttackAnimation : MonoBehaviour
{
    Transform tr;

    private void Awake()
    {
        tr = transform;
    }

    public void AnimationEnd()
    {
        gameObject.SetActive(false);
    }

    public void SetPosition(Vector3 _position)
    {
        tr.position = _position;
    }
}