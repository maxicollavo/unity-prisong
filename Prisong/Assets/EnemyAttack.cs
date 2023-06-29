using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public LifeController lifeController;
    public Animator WalkingEnemy;
    public bool EnemyTrigger = false;

    void OnTriggerEnter(Collider collider)
    {
        if (collider.transform.tag == "PlayerTrigger")
        {
            EnemyTrigger = true;
            StartCoroutine(HitEnemy());
        }
    }
    public IEnumerator HitEnemy()
    {
        while (EnemyTrigger == true)
        {
            lifeController.Hit(1);
            Debug.Log(lifeController.lives);
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
            EnemyTrigger = false;
            yield return new WaitForSeconds(2);
            EnemyTrigger = true;
        }
    }

    private void OnTriggerExit(Collider collider)
    {
        if (collider.transform.tag == "PlayerTrigger")
        {
            EnemyTrigger = false;
        }
    }

}
