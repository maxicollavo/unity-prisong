using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpcontroller : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "PowerUp")
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                other.GetComponent<Powervelocida>().Efecto();
                Debug.Log("se hizo");
            }
        }
    }
}
