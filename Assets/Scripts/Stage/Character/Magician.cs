using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magician : PlayerCharacter
{
    [SerializeField] float cooltimeCheck = 0f;
    [SerializeField] bool canAttack = true;
    [SerializeField] BoxCollider2D weaponCollider;
    [SerializeField] int magicianNum;

    private void Update()
    {
        if (isEnemyChecked && canAttack)
        {
            canAttack = false;
            StartCoroutine(Attack());
        }
        if (!canAttack)
            CheckAttackCooltime();
    }

    void CheckAttackCooltime()
    {
        if (cooltimeCheck >= attackCooltime)
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
        animator.SetTrigger("Attack");
        yield return null;
        float waitTime = animator.GetCurrentAnimatorStateInfo(0).length / 2f;
        yield return new WaitForSeconds(waitTime);
        weaponCollider.enabled = true;
        SoundManager.instance.PlaySFX(SoundManager.SFX.MAGICIAN_ATTACK1 + magicianNum);
    }
}