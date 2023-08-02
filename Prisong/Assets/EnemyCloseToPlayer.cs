using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCloseToPlayer : MonoBehaviour
{
    public static bool isClose;

    public void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("PlayerTrigger"))
        {
            isClose = true;
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("PlayerTrigger"))
        {
            isClose = false;
        }
    }
}
