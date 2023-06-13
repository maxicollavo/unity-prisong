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
    public Animator WalkingE;
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
        Animator WalkingE = GetComponent<Animator>();
        NavMeshAgent agent = GetComponent<NavMeshAgent>();
    }
    void Update()
    {
        if (followTrigger == false)
        {
            WaypointsMetodo();
        }
        FaceTarget(player.transform.position);
        EnemyAnim();
        EnemyStun();
    }

    private void WaypointsMetodo ()
    {
        var dir = Waypoints[_actualIndex].position - transform.position;
        transform.forward = dir;
        transform.position += dir.normalized * agent.speed * Time.deltaTime;

        if (Vector3.Distance(transform.position, Waypoints[_actualIndex].position) <= minDist)
        {
            _actualIndex++;
            if (_actualIndex >= Waypoints.Length)
            {
                _actualIndex = 0;
            }
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

        }
    }  

    void EnemyAnim()
    {
        if (stayAlert == true) WalkingE.SetBool("WalkingE", true);
        else if (stayAlert == false) WalkingE.SetBool("WalkingE", false);

    }

    public void EnemyStun()
    {
        if (Config.rockPickCount == 1)
        {
            stayAlert = false;
            enemyStun = true;
            agent.speed = 0f;
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "FollowTrigger")
        {
            followTrigger = true;
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.transform.tag == "FollowTrigger")
        {
            followTrigger = false;
        }
    }
}
