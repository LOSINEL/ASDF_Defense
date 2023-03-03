using System.Collections;
using System.Collections.Generic;
using UnityEditor.U2D.Animation;
using UnityEngine;

public class Test_SummonInput : MonoBehaviour
{
    [SerializeField] CharacterData[] characterData;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Instantiate(characterData[0].Character, transform.position, Quaternion.identity, transform);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Instantiate(characterData[1].Character, transform.position, Quaternion.identity, transform);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            Instantiate(characterData[2].Character, transform.position, Quaternion.identity, transform);
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            Instantiate(characterData[3].Character, transform.position, Quaternion.identity, transform);
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            Instantiate(characterData[4].Character, transform.position, Quaternion.identity, transform);
        }
        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            Instantiate(characterData[5].Character, transform.position, Quaternion.identity, transform);
        }
        if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            Instantiate(characterData[6].Character, transform.position, Quaternion.identity, transform);
        }
        if (Input.GetKeyDown(KeyCode.Alpha8))
        {
            Instantiate(characterData[7].Character, transform.position, Quaternion.identity, transform);
        }
        if (Input.GetKeyDown(KeyCode.Alpha9))
        {
            Instantiate(characterData[8].Character, transform.position, Quaternion.identity, transform);
        }
        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            Instantiate(characterData[9].Character, transform.position, Quaternion.identity, transform);
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                transform.GetChild(i).transform.Translate(-400f, 0f, 0f);
            }
        }
    }
}