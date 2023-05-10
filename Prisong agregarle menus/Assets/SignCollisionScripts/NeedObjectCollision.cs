using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeedObjectCollision : MonoBehaviour
{
    public GameObject needObjectInstruction;
    public GameObject needObjectEscapeInstruction;
    public PlayerPickManager playerPickManager;

    void OnTriggerEnter(Collider collision)
    {
        if (Config.picksCount < Config.picksRequired)
        {
            if (collision.transform.tag == "Partitures")
            {
                needObjectInstruction.SetActive(true);
            }
        }
        if (Config.partiturePickCount < Config.escapePicksRequired)
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
    }
}
