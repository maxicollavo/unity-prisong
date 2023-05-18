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
        if (collision.transform.tag == "Piano" && Config.picksCount == 0)
        {
            needObjectPiano.SetActive(true);
        }
        if (collision.transform.tag == "Piano" && Config.picksCount == 1 && playerPickManager.signOne == true)
        {
            needObjectPiano.SetActive(true);
        }
        if (collision.transform.tag == "Piano" && Config.rockPickCount == 1)
        {
            needObjectPiano.SetActive(false);
        }
        if (Config.rockPickCount < Config.escapePicksRequired)
        {
            if (collision.transform.tag == "DoorEscape")
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
