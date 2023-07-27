using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnim : MonoBehaviour
{
    public Animator enemyAnim;

    public void Update()
    {
        if (EnemyMovement.followingPlayer)
        {
            if (EnemyCloseToPlayer.isClose)
            {
                enemyAnim.SetBool("EnemyAttack", true);
            }
            else
            {
                enemyAnim.SetBool("EnemyRun", true);
                enemyAnim.SetBool("EnemyAttack", false);
            }
        }
        else
        {
            enemyAnim.SetBool("EnemyAttack", false);
            enemyAnim.SetBool("EnemyRun", false);
            enemyAnim.SetBool("EnemyWalk", true);
        }
    }
}
