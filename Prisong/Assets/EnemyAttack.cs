using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public LifeController lifeController;
    public Animator WalkingEnemy;
    public bool enemyTrigger = false;

    public IEnumerator HitEnemy()
    {
        while (enemyTrigger == true)
        {
            WalkingEnemy.SetBool("enemyTrigger", true);
            lifeController.Hit();
            if (lifeController.lives == 3)
            {
                lifeController.heart1.SetActive(false);
            }
            if (lifeController.lives == 2)
            {
                lifeController.heart2.SetActive(false);
            }
            if (lifeController.lives == 1)
            {
                lifeController.heart3.SetActive(false);
            }
            yield return new WaitForSeconds(0.0001f);
            WalkingEnemy.SetBool("enemyTrigger", false);
            yield return new WaitForSeconds(2);
        }
    }

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
        if (collider.transform.tag == "PlayerTrigger")
        {
            enemyTrigger = false;
            WalkingEnemy.SetBool("enemyTrigger", false);
        }
    }
}
