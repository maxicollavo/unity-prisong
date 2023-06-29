using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TPDarkWorld : MonoBehaviour
{
    public float teleportHeightDown = -89f;
    public float teleportHeightUp = 0.6f;
    public static bool realWorld = true;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Mirror"))
        {
            TeleportPlayer();
        }
    }

    public void TeleportPlayer()
    {
        Vector3 newPosition = new Vector3(transform.parent.parent.localPosition.x, realWorld ? teleportHeightDown : teleportHeightUp, transform.parent.parent.localPosition.z);
        transform.parent.parent.localPosition = newPosition;
        realWorld = !realWorld;
    }

    public void TeleportPlayerDead()
    {
        Vector3 newPosition = new Vector3(realWorld ? 0 : 0, realWorld ? teleportHeightDown : teleportHeightUp, transform.parent.parent.localPosition.z);
        transform.parent.parent.localPosition = newPosition;
        realWorld = !realWorld;
    }
}
