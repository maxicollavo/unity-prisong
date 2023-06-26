using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    public Transform[] Waypoints;
    public TrepidationBarBehaviour trepBarBeh;
    public PlayerPickManager playerPickManager;
    public LifeController lifeController;
    public GameObject player;
    public GameObject enemy;
    public GameObject enemyLastObject;
    public LayerMask mask;
    public Animator WalkingEnemy;
    public bool followTrigger;
    public bool enemyStun;
    public bool stayAlert;
    public Vector3 dir;
    public float speedRoat;
    public float minDist;
    int _actualIndex;
    public NavMeshAgent agent;

    private void Start()
    {
        followTrigger = false;
        enemyStun = false;
        stayAlert = true;
        Animator WalkingEnemy = GetComponent<Animator>();
        NavMeshAgent agent = GetComponent<NavMeshAgent>();
        _actualIndex = Random.Range(0, Waypoints.Length);
    }
    void Update()
    {
        if (followTrigger == false)
        {
            WaypointsMethod();
            agent.speed = 3.5f;
        }
        FaceTarget(player.transform.position);
        EnemyAnim();
        EnemyStun();
    }
    private void WaypointsMethod ()
    {
        agent.SetDestination(Waypoints[_actualIndex].position);
        if (Vector3.Distance(transform.position, Waypoints[_actualIndex].position) <= minDist)
            {
        
            _actualIndex = Random.Range(0, Waypoints.Length);
        }
    }
    private void FaceTarget(Vector3 destination)
    {
        if (followTrigger == true)
        {
            agent.SetDestination(player.transform.position);
            Vector3 lookPos = destination - transform.position;
            lookPos.y = 0;
            Quaternion rotation = Quaternion.LookRotation(lookPos);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, 1);
            agent.speed = 6;
        }
    }  
    void EnemyAnim()
    {
        if (stayAlert == true) WalkingEnemy.SetBool("WalkingEnemy", true);
        else if (stayAlert == false) WalkingEnemy.SetBool("WalkingEnemy", false);

    }
    public void EnemyStun()
    {
        if (Config.rockPickCount == 1 && TPDarkWorld.realWorld == true)
        {
            stayAlert = false;
            enemyStun = true;
            agent.speed = 0f;
        }
    }
}
