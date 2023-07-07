using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeedObjectCollision : MonoBehaviour
{
    public GameObject needObjectInstruction;
    public GameObject needObjectPiano;
    public GameObject needObjectEscapeInstruction;
    public PlayerPickManager playerPickManager;

    void OnTriggerEnter(Collider collision)
    {
        if (collision.transform.tag == "Piano" && Config.picksCountInv == 0)
        {
            needObjectPiano.SetActive(true);
        }
        else if (collision.transform.tag == "Piano" && Config.picksCountInv == 1 && playerPickManager.signOne == true)
        {
            needObjectPiano.SetActive(true);
        }
        else if (collision.transform.tag == "Piano" && Config.rockPickCount == 1)
        {
            needObjectPiano.SetActive(false);
        }
        else if (collision.transform.tag == "DoorEscape")
        {
            if (!PlayerPickManager.winningLightsOn)
            {
                needObjectEscapeInstruction.SetActive(true);
            }
        }
    }

    void OnTriggerExit(Collider collision)
    {
        if (collision.transform.tag == "Piano")
        {
            needObjectInstruction.SetActive(false);
            needObjectPiano.SetActive(false);
        }
        if (collision.transform.tag == "DoorEscape")
        {
            needObjectEscapeInstruction.SetActive(false);
        }
    }
}
