using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    public Waypoint[] Waypoints;
    public Transform player;
    public static bool followingPlayer;
    NavMeshAgent agent;
    public Vector3 target1;
    private int _currentWaypointIndex = 0;
    public Transform[] waypoints;

    private void Start()
    {
        Animator WalkingEnemy = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        SetNextWaypoint();
    }

    private void SetNextWaypoint()
    {
        _currentWaypointIndex = Random.Range(0, waypoints.Length);
    }

    void Update()
    {
        if (!followingPlayer)
        {
            if (Vector3.Distance(transform.position, target1) < 1)
            {
                SetNextWaypoint();
            }
        }
    }
    public void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("PlayerTrigger"))
        {
            followingPlayer = true;
            agent.SetDestination(player.transform.position);
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("PlayerTrigger"))
        {
            followingPlayer = false;
            SetNextWaypoint();
        }
    }
}


