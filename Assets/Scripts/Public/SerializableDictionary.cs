using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SerializableDictionary<TKey, TValue>
{
    [SerializeField] List<TKey> keys = new();
    [SerializeField] List<TValue> values = new();

    public TValue GetValue(TKey _key)
    {
        return values[keys.IndexOf(_key)];
    }
}