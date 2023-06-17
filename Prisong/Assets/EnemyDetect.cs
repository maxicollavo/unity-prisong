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
        if (CanSeePlayer())
        {
            // El enemigo te ha detectado visualmente
            Debug.Log("Player detected!");
            // Aquí puedes realizar las acciones que deseas que ocurran cuando el enemigo te vea
        }
    }

    private bool CanSeePlayer()
    {
        Vector3 directionToPlayer = playerTransform.position - transform.position;
        float distanceToPlayer = directionToPlayer.magnitude;

        if (distanceToPlayer <= maxHearingDistance)
        {
            // Comprueba si no hay obstáculos entre el enemigo y el jugador
            RaycastHit hit;
            if (Physics.Raycast(transform.position, directionToPlayer, out hit, distanceToPlayer))
            {
                if (hit.transform.CompareTag("Player"))
                {
                    // El rayo ha alcanzado al jugador sin ser bloqueado por otros objetos
                    return true;
                }
            }
        }

        return false;
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
