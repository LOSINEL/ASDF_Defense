using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Assassin : PlayerCharacter
{
    float cooltimeCheck = 0f;
    bool canAttack = true;
    [SerializeField] BoxCollider2D weaponCollider;

    private void Update()
    {
        if (!IsEnemyChecked)
        {
            Move();
        }
        else if (IsEnemyChecked && canAttack)
        {
            StartCoroutine(Attack());
        }
        CheckAttackCooltime();
    }

    void CheckAttackCooltime()
    {
        if (cooltimeCheck > AttackCooltime)
        {
            cooltimeCheck = 0f;
            canAttack = true;
        }
        else
        {
            cooltimeCheck += Time.deltaTime;
        }
    }

    IEnumerator Attack()
    {
        animator.SetTrigger(0);
        yield return null;
        float waitTime = animator.GetCurrentAnimatorStateInfo(0).length / 2f;
        yield return new WaitForSeconds(waitTime);
        weaponCollider.enabled = true;
    }
}