using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ECollision : MonoBehaviour
{
    public GameObject pressEInstruction;

    void OnTriggerEnter(Collider collision)
    {
        if (collision.transform.tag == "Picks")
        {
            pressEInstruction.SetActive(true);
        }
    }

    void OnTriggerExit(Collider collision)
    {
        pressEInstruction.SetActive(false);
    }


}
