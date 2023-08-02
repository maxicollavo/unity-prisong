using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DWEnemyMovement : MonoBehaviour
{
    public Transform player;
    public static bool followingPlayer;
    NavMeshAgent agent;
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
        agent.SetDestination(waypoints[_currentWaypointIndex].position);
    }

    void Update()
    {
        if (!followingPlayer)
        {
            if (Vector3.Distance(transform.position, waypoints[_currentWaypointIndex].position) < 1)
            {
                SetNextWaypoint();
                agent.speed = 3.5f;
            }
        }
        else
        {
            agent.SetDestination(player.transform.position);
            agent.speed = 5f;
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
        if (other.CompareTag("PlayerTrigger") && Vector3.Distance(transform.position, player.transform.position) > 3.5f)
        {
            followingPlayer = false;
            SetNextWaypoint();
            agent.speed = 3.5f;
        }
    }
}
