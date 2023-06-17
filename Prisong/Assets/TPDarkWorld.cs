using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TPDarkWorld : MonoBehaviour
{
    public float teleportHeightDown = -48f;
    public float teleportHeightUp = 41f;
    public Collider other;
    public static bool realWorld = true;
    public static bool darkWorld = false;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Mirror"))
        {
            TeleportPlayer();
        }
    }

    void TeleportPlayer()
    {
        if (realWorld == true && darkWorld == false)
        {
            Vector3 newPosition = new Vector3(transform.parent.localPosition.x, teleportHeightDown, transform.parent.localPosition.z);
            transform.parent.localPosition = newPosition;
            realWorld = !realWorld;
            darkWorld = !darkWorld;
        }
        else if (darkWorld == true && realWorld == false)
        {
            Vector3 newPosition = new Vector3(transform.parent.localPosition.x, teleportHeightUp, transform.parent.localPosition.z);
            transform.parent.localPosition = newPosition;
            realWorld = !realWorld;
            darkWorld = !darkWorld;
        }
        
    }
}
