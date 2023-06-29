using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBehaviour : MonoBehaviour
{
    public Transform[] waypoints;
    public float moveSpeed = 3f;
    public float runSpeed = 6f;
    public Transform player;
    public float chaseDistance = 5f;
    public Animator animator;

    private int currentWaypointIndex = 0;
    private bool isChasing = false;
    private NavMeshAgent agent;
    public AudioSource walkingEnemy;
    public AudioSource runningEnemy;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        SetNextWaypoint();
    }

    private void Update()
    {
        if (isChasing)
        {
            agent.speed = 7;
            ChasePlayer();
        }
        else
        {
            agent.speed = 3.5f;
            PatrolWaypoints();
        }
    }

    private void PatrolWaypoints()
    {
        if (Vector3.Distance(transform.position, waypoints[currentWaypointIndex].position) < 0.1f)
        {
            SetNextWaypoint();
        }

        agent.SetDestination(waypoints[currentWaypointIndex].position);
        animator.SetBool("EnemyFollow", false);
    }

    private void SetNextWaypoint()
    {
        currentWaypointIndex = Random.Range(0, waypoints.Length);
    }

    private void ChasePlayer()
    {
        if (Vector3.Distance(transform.position, player.position) > chaseDistance)
        {
            agent.speed = 3.5f;
            animator.SetBool("WalkingEnemy", true);
            animator.SetBool("EnemyFollow", false);
            isChasing = false;
            return;
        }

        agent.speed = 7f;
        agent.SetDestination(player.position);
        animator.SetBool("WalkingEnemy", false);
        animator.SetBool("EnemyFollow", true);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PlayerTrigger"))
        {
            isChasing = true;
            animator.SetBool("EnemyTrigger", true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("PlayerTrigger"))
        {
            isChasing = false;
            animator.SetBool("EnemyTrigger", false);
        }
    }
}
