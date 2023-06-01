using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FCollision : MonoBehaviour
{
    public GameObject pressFInstruction;
    public GameObject pressFEscapeInstruction;
    public GameObject pressFKillEnemy;
    public GameObject pressFInteractChest;
    public PlayerPickManager playerPickManager;

    void OnTriggerEnter(Collider collision)
    {
        if (collision.transform.tag == "Chest" && Config.keyCount == 2 && playerPickManager.chestOpen == false)
        {
            pressFInteractChest.SetActive(true);
        }
        else if (collision.transform.tag == "Chest" && playerPickManager.chestOpen == true)
        {
            pressFInteractChest.SetActive(false);
        }
        if (Config.rockPickCount == 1)
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
        pressFInteractChest.SetActive(false);

    }
}