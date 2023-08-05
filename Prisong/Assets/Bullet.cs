using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    private void Start()
    {
        Destroy(gameObject, 2 );
    }

    public float speed; 
    void Update()
    {
        transform.position += transform.forward * speed * Time.deltaTime; 
    }
}
