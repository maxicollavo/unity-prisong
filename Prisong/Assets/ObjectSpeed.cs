using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpeed : MonoBehaviour
{
    public PlayerInputManager playerInputManager;
    public int tipo;
    public bool collision = false;
    void Start()
    {
        playerInputManager = GameObject.FindWithTag("Player").GetComponent<PlayerInputManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (collision = true)
        {
            Efecto();
        }
    }
    public void Efecto()
    {
        switch (tipo)
        {
            case 1:
                playerInputManager.gameObject.transform.localScale = new Vector3(3, 3, 3);
                break;
                
            case 2:
                playerInputManager.speed += 5;
                break;

            
                default:
                Debug.Log("sin efecto");
                break;
        }
    }
}
