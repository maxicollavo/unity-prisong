using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NieblaTest : MonoBehaviour
{
    public Transform Player;
    public float minDist;
    void Start()
    {
        
    }

    
    void Update()
    {

        float dist = Vector3.Distance(Player.position, transform.position);
        
        if (dist < minDist) 
        {
            RenderSettings.fog = true;
        
        
        }
        else
        RenderSettings.fog = false;
        
    
    
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, minDist);
    }

}


