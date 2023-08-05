using SojaExiles;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class TowerEnemy : MonoBehaviour
{
    public Bullet bullet; 
    public Transform player;
    public float speedRot;
    public float minDist;
    public float cooldown;
    public LayerMask layerDetect;
    float _counter;
    

    void Update()
    {

                                                       
        
        var dir = player.position - transform.position;
        // Vector3.Distance(player.position, transform.position);
        if (dir.magnitude <= minDist)
        {

            if(!Physics.Raycast(transform.position, dir, dir.magnitude, layerDetect))
            {
                transform.forward = Vector3.Lerp(transform.forward, dir, speedRot * Time.deltaTime);
                _counter += Time.deltaTime;
                if (_counter >= cooldown)
                {
                    Instantiate(bullet, transform.position, transform.rotation);
                    _counter = 0;
                }


            }
           
            
        }
        
    }
}
 