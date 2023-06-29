using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    public Waypoint[] Waypoints;
    public PlayerPickManager playerPickManager;
    public LifeController lifeController;
    public Transform player;
    public GameObject enemy;
    public GameObject enemyLastObject;
    public LayerMask mask;
    public Animator WalkingEnemy;
    public bool followTrigger;
    public bool enemyStun;
    public bool stayAlert;
    public Vector3 dir;
    public float contador;
    public float speedRoat;
    public float minDist;
    int _actualIndex;
    NavMeshAgent agent;
    Vector3 target;
    

    private void Start()
    {
       
        Animator WalkingEnemy = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        UpdateDestination();
    }
    void Update()
    {
        if (Vector3.Distance(transform.position, target )<1 && !EnemyDetection.playerDetected) 
        {
            
            IterateWaypointIndex();
            UpdateDestination();

        }
        else if(EnemyDetection.playerDetected)
        {
           agent.SetDestination(player.position);
        }
        
    }

    void IterateWaypointIndex()
    {
        contador += Time.deltaTime;

        if (contador >= Waypoints[_actualIndex ].duration)
        {
          _actualIndex++;
            contador = 0;
        }
        if (_actualIndex>= Waypoints.Length)
        {
          _actualIndex = 0;
        }
        

    
    }
   


    public void UpdateDestination()
    {
        target = Waypoints[_actualIndex].transform.position;
        agent.SetDestination(target);
    }

}


