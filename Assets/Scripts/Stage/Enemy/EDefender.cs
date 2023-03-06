using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EDefender : EnemyCharacter
{
    [SerializeField] bool isDefending = false;

    private void Update()
    {
        if (!isEnemyChecked)
        {
            if (isDefending)
            {
                DefenseOff();
            }
        }
        else if (!isDefending)
        {
            DefenseOn();
        }
    }

    void DefenseOn()
    {
        isDefending = true;
        animator.SetBool("Defense", true);
    }

    void DefenseOff()
    {
        isDefending = false;
        animator.SetBool("Defense", false);
    }
}