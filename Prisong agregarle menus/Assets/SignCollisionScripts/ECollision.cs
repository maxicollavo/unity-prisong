using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ECollision : MonoBehaviour
{
    public GameObject pressEInstruction;
    public GameObject pressEMachineInstruction;
    public GameObject pressEInteractPiano;
    public GameObject pressEInteractChest;

    void OnTriggerEnter(Collider collision)
    {
        if (collision.transform.tag == "Picks")
        {
            pressEInstruction.SetActive(true);
        }

        if (collision.transform.tag == "Piano" && Config.picksCount >= 1)
        {
            pressEInteractPiano.SetActive(true);
        }

        if (collision.transform.tag == "DispenserMask")
        {
            pressEMachineInstruction.SetActive(true);
        }
        if (collision.transform.tag == "ChestMask" && Config.keyCount == 2)
        {
            pressEInstruction.SetActive(true);
        }
    }

    void OnTriggerExit(Collider collision)
    {
        pressEInstruction.SetActive(false);
        pressEMachineInstruction.SetActive(false);
        pressEInteractPiano.SetActive(false);
    }


}
