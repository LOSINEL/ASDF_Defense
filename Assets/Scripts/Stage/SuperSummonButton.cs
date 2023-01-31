using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperSummonButton : MonoBehaviour
{
    [SerializeField] GameObject summonButtonGroup;
    [SerializeField] bool superSummonOn = false;

    public bool SuperSummonOn { get { return superSummonOn; } }

    public void ActivateSuperSummon()
    {
        superSummonOn = !superSummonOn;
    }
}