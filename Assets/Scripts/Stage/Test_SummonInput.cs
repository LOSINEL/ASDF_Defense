using System.Collections;
using System.Collections.Generic;
using UnityEditor.U2D.Animation;
using UnityEngine;

public class Test_SummonInput : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Instantiate(SummonManager.instance.Characters[0], transform.position, Quaternion.identity, transform);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Instantiate(SummonManager.instance.Characters[1], transform.position, Quaternion.identity, transform);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            Instantiate(SummonManager.instance.Characters[2], transform.position, Quaternion.identity, transform);
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            Instantiate(SummonManager.instance.Characters[3], transform.position, Quaternion.identity, transform);
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            Instantiate(SummonManager.instance.Characters[4], transform.position, Quaternion.identity, transform);
        }
        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            Instantiate(SummonManager.instance.Characters[5], transform.position, Quaternion.identity, transform);
        }
        if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            Instantiate(SummonManager.instance.Characters[6], transform.position, Quaternion.identity, transform);
        }
        if (Input.GetKeyDown(KeyCode.Alpha8))
        {
            Instantiate(SummonManager.instance.Characters[7], transform.position, Quaternion.identity, transform);
        }
        if (Input.GetKeyDown(KeyCode.Alpha9))
        {
            Instantiate(SummonManager.instance.Characters[8], transform.position, Quaternion.identity, transform);
        }
        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            Instantiate(SummonManager.instance.Characters[9], transform.position, Quaternion.identity, transform);
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            Instantiate(SummonManager.instance.Characters[10], transform.position, Quaternion.identity, transform);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            Instantiate(SummonManager.instance.Characters[11], transform.position, Quaternion.identity, transform);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            Instantiate(SummonManager.instance.Characters[12], transform.position, Quaternion.identity, transform);
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            Instantiate(SummonManager.instance.Characters[13], transform.position, Quaternion.identity, transform);
        }
        if (Input.GetKeyDown(KeyCode.G))
        {
            Instantiate(SummonManager.instance.Characters[14], transform.position, Quaternion.identity, transform);
        }
    }
}