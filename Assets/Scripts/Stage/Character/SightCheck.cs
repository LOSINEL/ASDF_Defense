using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SightCheck : MonoBehaviour
{
    PlayerCharacter playerCharacter;

    private void Start()
    {
        playerCharacter = GetComponentInParent<PlayerCharacter>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy") || collision.CompareTag("EnemyHome"))
        {
            playerCharacter.Enemies.Add(collision.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy") || collision.CompareTag("EnemyHome"))
        {
            playerCharacter.Enemies.Remove(collision.gameObject);
        }
    }
}