using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpTeleport : MonoBehaviour
{
    public float teleportHeightDown = 27.57f;
    public float teleportHeightUp = 8.960f;
    public bool realWorld = true;
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PowerUp"))
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
}
