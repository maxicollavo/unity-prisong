using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ECollision : MonoBehaviour
{
    public GameObject pressEInstruction;
    public GameObject pressEMachineInstruction;

    void OnTriggerEnter(Collider collision)
    {
        if (collision.transform.tag == "Picks")
        {
            pressEInstruction.SetActive(true);
        }

        if (collision.transform.tag == "DispenserMask")
        {
            pressEMachineInstruction.SetActive(true);
        }
    }

    void OnTriggerExit(Collider collision)
    {
        pressEInstruction.SetActive(false);
        pressEMachineInstruction.SetActive(false);
    }


}
