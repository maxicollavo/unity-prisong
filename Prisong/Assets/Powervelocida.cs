using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class Powervelocida : MonoBehaviour
{

    public bool destruirConCursor;
    public bool destruirAutomatico;
    public PlayerInputManager playerInputManager;

    public int aumentavelocidad; 

    void Start()
    {
        playerInputManager = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInputManager>();


    }

    
    void Update()
    {
        
    
    
    
    
    
    }

    public void Efecto()
    {
        PlayerInputManager.spe += 80;




    }




}
