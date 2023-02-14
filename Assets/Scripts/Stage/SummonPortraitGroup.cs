using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SummonPortraitGroup : MonoBehaviour
{
    public static SummonPortraitGroup instance;

    [SerializeField] SuperSummonButton superSummonButton;
    [SerializeField] GameObject summonPortrait;
    Transform tr;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        tr = GetComponent<Transform>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            SummonPortrait((Enums.CHAR_TYPE)Random.Range(0, 12));
        }
    }

    public void SummonPortrait(Enums.CHAR_TYPE _charType)
    {
        if (superSummonButton.SuperSummonOn)
        {
            GameObject _summonPortrait = Instantiate(summonPortrait, new Vector3(tr.parent.position.x, tr.parent.position.y, 0f), Quaternion.identity, tr);
            _summonPortrait.GetComponent<SummonPortrait>().SetImage(_charType);
            _summonPortrait.GetComponent<SummonPortrait>().SetSpeed(tr.parent.position.x * 2f);
        }
    }
}