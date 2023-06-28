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

    private void Start()
    {
        SetNextWaypoint();
    }

    private void Update()
    {
        if (isChasing)
        {
            ChasePlayer();
        }
        else
        {
            PatrolWaypoints();
        }
    }

    private void PatrolWaypoints()
    {
        if (Vector3.Distance(transform.position, waypoints[currentWaypointIndex].position) < 0.1f)
        {
            SetNextWaypoint();
        }

        Vector3 targetDirection = waypoints[currentWaypointIndex].position - transform.position;
        Vector3 moveDirection = targetDirection.normalized;
        transform.position += moveDirection * moveSpeed * Time.deltaTime;

        Quaternion targetRotation = Quaternion.LookRotation(targetDirection);
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, 0.1f);

        animator.SetBool("IsRunning", false);
    }

    private void SetNextWaypoint()
    {
        currentWaypointIndex = Random.Range(0, waypoints.Length);
    }

    private void ChasePlayer()
    {
        if (Vector3.Distance(transform.position, player.position) > chaseDistance)
        {
            isChasing = false;
            return;
        }

        Vector3 targetDirection = player.position - transform.position;
        Vector3 moveDirection = targetDirection.normalized;
        transform.position += moveDirection * runSpeed * Time.deltaTime;

        Quaternion targetRotation = Quaternion.LookRotation(targetDirection);
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, 0.1f);

        animator.SetBool("IsRunning", true);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PlayerTrigger"))
        {
            isChasing = true;
        }
    }
}
