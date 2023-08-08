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
    public NavMeshAgent navMesh;

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
       navMesh.speed += 80;




    }




}
