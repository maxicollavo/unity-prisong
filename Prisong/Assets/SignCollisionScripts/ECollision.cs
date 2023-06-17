using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ECollision : MonoBehaviour
{
    public GameObject pressEInstruction;
    public GameObject pressEMachineInstruction;
    public GameObject pressEInteractPiano;
    public PlayerPickManager playerPickManager;

    void OnTriggerEnter(Collider collision)
    {
        if (collision.transform.tag == "Picks")
        {
            pressEInstruction.SetActive(true);
        }
        else if (collision.transform.tag == "Piano" && Config.picksCount == 1 && playerPickManager.signOne == false)
        {
            pressEInteractPiano.SetActive(true);
        }
        else if (collision.transform.tag == "Piano" && Config.picksCount == 2)
        {
            pressEInteractPiano.SetActive(true);
        }
        else if (collision.transform.tag == "Piano" && Config.picksCount == 3 && playerPickManager.signThree == false)
        {
            pressEInteractPiano.SetActive(true);
        }
        else if (collision.transform.tag == "Piano" && Config.picksCount == 4)
        {
            pressEInteractPiano.SetActive(true);
        }
        else if (collision.transform.tag == "Piano" && Config.picksCount == 0 && playerPickManager.signTwo == true)
        {
            pressEInteractPiano.SetActive(false);
        }
        else if (collision.transform.tag == "Rock")
        {
            pressEInstruction.SetActive(true);
        }
        else if (collision.transform.tag == "Dispenser")
        {
            pressEMachineInstruction.SetActive(true);
        }
        else if (collision.transform.tag == "Note")
        {
            pressEInstruction.SetActive(true);
        }
        else if (collision.transform.tag == "Disco")
        {
            pressEInstruction.SetActive(true);
        }
        else if (collision.transform.tag == "PlayRecord" && playerPickManager.haveDisk == true)
        {
            pressEInteractPiano.SetActive(true);
        }
    }

    void OnTriggerExit(Collider collision)
    {
        if (collision.transform.tag == "Picks")
        {
            pressEInstruction.SetActive(false);
        }
        else if (collision.transform.tag == "Piano")
        {
            pressEInteractPiano.SetActive(false);
        }
        else if (collision.transform.tag == "Rock")
        {
            pressEInstruction.SetActive(false);
        }
        else if (collision.transform.tag == "Dispenser")
        {
            pressEMachineInstruction.SetActive(false);
        }
        else if (collision.transform.tag == "Note")
        {
            pressEInstruction.SetActive(false);
        }
        else if (collision.transform.tag == "Disco")
        {
            pressEInstruction.SetActive(false);
        }
        else if (collision.transform.tag == "PlayRecord")
        {
            pressEInteractPiano.SetActive(false);
        }
    }


}
