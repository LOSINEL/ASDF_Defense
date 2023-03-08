using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SightCheck : MonoBehaviour
{
    const string enemyTag = "Enemy";

    PlayerCharacter playerCharacter;

    private void Start()
    {
        playerCharacter = GetComponentInParent<PlayerCharacter>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(enemyTag))
        {
            playerCharacter.Enemies.Add(collision.gameObject);
        }
    }
}