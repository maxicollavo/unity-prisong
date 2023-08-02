using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public LifeController lifeController;

    public void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("PlayerTrigger"))
        {
            WaitAndAttack();
        }
    }

    public IEnumerator WaitAndAttack()
    {
        while (EnemyCloseToPlayer.isClose)
        {
            lifeController.Hit(1);
            yield return new WaitForSeconds(2);
        }
    }
}
