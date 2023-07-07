using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TPDarkWorld : MonoBehaviour
{
    public float teleportHeightDown = -91.5f;
    public float teleportHeightUp = -1.65f;
    public bool realWorld = true;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Mirror"))
        {
            TeleportPlayer();
        }
    }

    void TeleportPlayer()
    {
        Vector3 newPosition = new Vector3(transform.parent.parent.localPosition.x, realWorld ? teleportHeightDown : teleportHeightUp, transform.parent.parent.localPosition.z);
        transform.parent.parent.localPosition = newPosition;
        realWorld = !realWorld;
    }
}