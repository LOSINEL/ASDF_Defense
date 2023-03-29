using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixedUpdateManager : MonoBehaviour
{
    public static FixedUpdateManager instance;

    List<IFixedUpdate> fixedUpdateList = new();

    public List<IFixedUpdate> FixedUpdateList { get { return fixedUpdateList; } }

    private void Awake()
    {
        instance = this;
    }

    private void FixedUpdate()
    {
        for (int i = 0; i < fixedUpdateList.Count; i++)
        {
            fixedUpdateList[i].ManagedFixedUpdate();
        }
    }
}