using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ESightCheck : MonoBehaviour
{
    const string characterTag = "Character";

    EnemyCharacter enemyCharacter;

    private void Start()
    {
        enemyCharacter = GetComponentInParent<EnemyCharacter>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(characterTag))
        {
            enemyCharacter.Enemies.Add(collision.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag(characterTag))
        {
            enemyCharacter.Enemies.Remove(collision.gameObject);
        }
    }
}