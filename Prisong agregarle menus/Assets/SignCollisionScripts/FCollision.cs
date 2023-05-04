using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FCollision : MonoBehaviour
{
    public GameObject pressFInstruction;
    public GameObject pressFEscapeInstruction;
    public GameObject pressFKillEnemy;
    public PlayerPickManager playerPickManager;

    void OnTriggerEnter(Collider collision)
    {
        if (Config.picksCount >= Config.picksRequired)
        {
            if (collision.transform.tag == "Partitures")
            {
                pressFInstruction.SetActive(true);
            }
            if (collision.transform.tag == "EnemyTrigger" && Config.partiturePickCount >= 1 && playerPickManager.enemyKill == false)
            {
                pressFKillEnemy.SetActive(true);
            }
            if (playerPickManager.enemyKill == true)
            {
                pressFKillEnemy.SetActive(false);
            }

        }
        if (/*Config.picksCount >= Config.escapePicksRequired && */playerPickManager.enemyKill == true)
        {
            if (collision.transform.tag == "DoorEscape")
            {
                pressFEscapeInstruction.SetActive(true);
            }
        }

    }

    void OnTriggerExit(Collider collision)
    {
        pressFKillEnemy.SetActive(false);
        pressFEscapeInstruction.SetActive(false);
        pressFInstruction.SetActive(false);

    }
}