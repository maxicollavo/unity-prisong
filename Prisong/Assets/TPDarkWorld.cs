using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TPDarkWorld : MonoBehaviour
{
    public float teleportHeight = -122.6f;
    public Collider other;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Mirror"))
        {
            Debug.Log("Entro");
            TeleportPlayer();
        }
    }

    void TeleportPlayer()
    {
        Vector3 newPosition = new Vector3(transform.position.x, teleportHeight, transform.position.z);
        transform.position = newPosition;
    }
}
