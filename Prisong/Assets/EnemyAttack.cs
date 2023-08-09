using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public LifeController lifeController;
    bool _isAttacking = false;

    public void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("PlayerTrigger") && !_isAttacking)
        {
            StartCoroutine(WaitAndAttack());
        }
    }

    public IEnumerator WaitAndAttack()
    {
        _isAttacking = true;
        while (EnemyCloseToPlayer.isClose)
        {
            lifeController.Hit(1);
            yield return new WaitForSeconds(2);
        }
        _isAttacking = false;
    }
}
