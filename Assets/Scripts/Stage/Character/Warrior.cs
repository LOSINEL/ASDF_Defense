using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warrior : PlayerCharacter
{
    private void Update()
    {
        if (!isEnemyChecked)
        {
            Move();
        }
    }
}