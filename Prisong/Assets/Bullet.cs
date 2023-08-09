using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    LifeController lifeC;
    public float speed;

    private void Start()
    {
        lifeC = GetComponent<LifeController>();
        Destroy(gameObject, 2);
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PlayerTrigger"))
        {
            lifeC.Hit(1);
        }
    }

    void Update()
    {
        transform.position += transform.forward * speed * Time.deltaTime;
    }
}
