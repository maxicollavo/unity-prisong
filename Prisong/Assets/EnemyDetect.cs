using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDetect : EnemyMovement
{
    public void OnTriggerEnter(Collider other) //Necesito que cuando el vision trigger del enemigo colisione con el player trigger el enemigo me vea y me corra
    {
        if (other.gameObject.layer == 16)
        {
            //followTrigger = true;
        }
    }
    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == 16)
        {
            //followTrigger = false;
        }
    }
}
