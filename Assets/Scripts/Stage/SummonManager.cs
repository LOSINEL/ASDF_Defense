using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SummonManager : MonoBehaviour
{
    public static SummonManager instance;

    [SerializeField] Transform characterSummonTransform;
    [SerializeField] GameObject[] characters;

    public GameObject[] Characters { get { return characters; } }
    public Transform CharacterSummonTransform { get { return characterSummonTransform; } }

    private void Awake()
    {
        instance = this;
    }

    public Vector3 GetRandomPositionRange(Vector3 _pos)
    {
        Vector3 tmpPos = new Vector3(0f, Random.Range(80f, 128f), 0f);
        return _pos - tmpPos;
    }

    public Vector3 GetRandomPositionRange()
    {
        Vector3 tmpPos = new Vector3(0f, Random.Range(80f, 128f), 0f);
        return CharacterSummonTransform.position - tmpPos;
    }
}