using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EMagician : EnemyCharacter
{
    [SerializeField] float cooltimeCheck = 0f;
    [SerializeField] bool canAttack = true;
    [SerializeField] BoxCollider2D weaponCollider;

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
        if (cooltimeCheck >= _attackCooltime)
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
        _attackCooltime = Random.Range(attackCooltime * attackCooltimeRandomMin, attackCooltime * attackCooltimeRandomMax);
        animator.SetTrigger("Attack");
        GameObject magicAttack = EMagicianAttackPoolManager.instance.GetAttack();
        magicAttack.SetActive(true);
        magicAttack.GetComponent<MagicianAttackAnimation>().SetPosition(tr.position);
        yield return null;
        SoundManager.instance.PlaySFX(SoundManager.SFX.EMAGICIAN_ATTACK);
        float waitTime = animator.GetCurrentAnimatorStateInfo(0).length / 2f;
        yield return new WaitForSeconds(waitTime);
        weaponCollider.enabled = true;
    }
}