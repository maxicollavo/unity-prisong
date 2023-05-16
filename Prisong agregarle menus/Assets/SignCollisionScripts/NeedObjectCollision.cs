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
        if (Config.picksCount < Config.picksRequired)
        {
            if (collision.transform.tag == "Rocks")
            {
                needObjectInstruction.SetActive(true);
            }
        }

        if (collision.transform.tag == "Piano" && Config.picksCount < 2)
        {
            needObjectPiano.SetActive(true);
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
        needObjectInstruction.SetActive(false);
        needObjectEscapeInstruction.SetActive(false);
        needObjectPiano.SetActive(false);
    }
}
