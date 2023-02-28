using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Archer : PlayerCharacter
{
    float cooltimeCheck = 0f;
    bool canAttack = true;
    [SerializeField] GameObject arrow;

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
        animator.SetTrigger("Attack");
        canAttack = false;
        yield return null;
        float waitTime = animator.GetCurrentAnimatorStateInfo(0).length / 2f;
        yield return new WaitForSeconds(waitTime);
        GameObject _arrow = Instantiate(arrow, tr.position, Quaternion.identity);
        _arrow.GetComponent<Arrow>().SetDamage(Damage);
    }
}