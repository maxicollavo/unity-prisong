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
            Debug.Log("isClose true");
            isClose = true;
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("PlayerTrigger"))
        {
            Debug.Log("isClose false");
            isClose = false;
        }
    }
}
