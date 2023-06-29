using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public LifeController lifeController;
    public Animator WalkingEnemy;
    public bool enemyTrigger = false;
    public bool cooldown = false;

    void OnTriggerEnter(Collider collider)
    {
        if (collider.transform.tag == "PlayerTrigger")
        {
            enemyTrigger = true;
            StartCoroutine(HitEnemy());
        }
    }

    private void OnTriggerExit(Collider collider)
    {
        StartCoroutine(HitEnemyCooldown());
    }

    public IEnumerator HitEnemy()
    {
        while (enemyTrigger && cooldown)
        {
            lifeController.Hit(1);
            cooldown = false;
            yield return new WaitForSeconds(2);
        }
    }

    public IEnumerator HitEnemyCooldown()
    {
        enemyTrigger = false;
        yield return new WaitForSeconds(2);
        cooldown = true;
    }
}
