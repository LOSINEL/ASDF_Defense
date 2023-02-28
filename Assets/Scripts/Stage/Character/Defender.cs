using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defender : PlayerCharacter
{
    private void Update()
    {
        if (!IsEnemyChecked)
        {
            Move();
        }
        else
        {
            Defense();
        }
    }

    void Defense()
    {
        animator.SetTrigger("Defense");
    }
}