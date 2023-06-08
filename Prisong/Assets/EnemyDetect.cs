using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDetect : MonoBehaviour
{
    public Transform playerTransform;
    public EnemyMovement enemyMovement;
    public float maxHearingDistance = 1f;
    public float followDistance = 1f;

    private void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, playerTransform.position - transform.position, out hit, Mathf.Infinity, LayerMask.GetMask("Player")))
        {
            Debug.DrawLine(transform.position, playerTransform.position, Color.red);
        }
        else
        {
            Debug.DrawLine(transform.position, playerTransform.position, Color.green);
        }
    }

    public void DetectNoise()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, playerTransform.position);

        if (distanceToPlayer <= maxHearingDistance)
        {
            Vector3 directionToPlayer = (playerTransform.position - transform.position).normalized;
            Vector3 targetPosition = playerTransform.position + directionToPlayer * followDistance;
        }
    }
}
