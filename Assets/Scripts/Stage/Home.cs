using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Home : Hp
{
    private void Start()
    {
        maxHp = GameManager.instance.NowStage * 10000;
        nowHp = maxHp;
    }
}