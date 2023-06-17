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
        if (collision.transform.tag == "Chest")
        {
            ChestRefs chestRefs = collision.gameObject.GetComponent<ChestRefs>();
            int pianoKeys = chestRefs.piano.GetComponent<PianoKeyCounter>().Keys;
            if (pianoKeys == 2 && collision.gameObject.activeInHierarchy)
            {
                pressFInteractChest.SetActive(true);
            }
        }
        if (Config.rockPickCount == 2)
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