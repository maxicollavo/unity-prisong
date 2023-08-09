using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;
using UnityEngine.AI;

public class Powervelocida : MonoBehaviour
{

    public bool destruirConCursor;
    public bool destruirAutomatico;
    public PlayerInputManager playerInputManager;
    public LifeController lifeController;



    public int aumentavelocidad; 

    void Start()
    {
        playerInputManager = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInputManager>();


    }

    
   
  
    public void Efecto()
    {
        switch (aumentavelocidad)
        {
            case 1:
                lifeController.lives += 1;
                break;
            case 2: playerInputManager.speed += 100;
                break;
            case 3: 
            default:
                Debug.Log("sin efecto");
                break;
        }

    }

}
