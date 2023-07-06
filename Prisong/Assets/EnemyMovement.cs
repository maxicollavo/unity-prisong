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
    //public GameObject enemyLastObject;
    public LayerMask mask;
    public Animator WalkingEnemy;
    public bool enemyStun;
    public bool stayAlert;
    public Vector3 dir;
    public float contador;
    public float speedRoat;
    public float minDist;
    int _actualIndex;
    NavMeshAgent agent;
    public GameObject target;
    public Vector3 target1;
    public Animator anim;

    private void Start()
    {
        Animator WalkingEnemy = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        UpdateDestination();
        target = GameObject.Find("Player");
    }
    void Update()
    {
        if (Vector3.Distance(transform.position, target1) <1 && EnemyDetection.playerDetected == false) 
        {
            IterateWaypointIndex();
            UpdateDestination();
            anim.SetBool("WalkingEnemy", true);
            anim.SetBool("EnemyFollow", false);
        }
        else if(EnemyDetection.playerDetected)
        {
           agent.SetDestination(player.position);
            anim.SetBool("WalkingEnemy", false);
            anim.SetBool("EnemyFollow", true);
        }
    

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "EnemyTriggerNear")
        {
            agent.SetDestination(player.transform.position);
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
        target1 = Waypoints[_actualIndex].transform.position;
        agent.SetDestination(target1);
    }
}


