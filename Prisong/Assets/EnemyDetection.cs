using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyDetection : MonoBehaviour
{
    public static bool playerDetected;
    public float rangoVision = 10f; // Distancia máxima de detección
    public float anguloVision = 60f; // Ángulo de visión
    public Transform jugador;
    public float velocidad = 5f;
    public NavMeshAgent agent;
    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    private void OnDrawGizmos()
    {
        // Dibujar el arco del ángulo de visión
        Gizmos.color = Color.yellow;
        Gizmos.matrix = Matrix4x4.TRS(transform.position, transform.rotation, Vector3.one);
        Gizmos.DrawFrustum(Vector3.zero, anguloVision, 0f, rangoVision, 1f);

        // Dibujar la línea hacia el jugador
        Gizmos.color = Color.red;
        if (jugador != null)
        {
            Gizmos.DrawLine(transform.position, jugador.position);
        }
    }

    void Update()
    {
        // Obtener la dirección hacia el jugador
        Vector3 direccion = (jugador.position - transform.position).normalized;
        // Calcular el ángulo entre la dirección del jugador y el frente del enemigo
        float angulo = Vector3.Angle(transform.forward, direccion);
        // Verificar si el jugador está dentro del rango de visión y dentro del ángulo de visión
        if (angulo <= anguloVision && Vector3.Distance(transform.position, jugador.position) <= rangoVision)
        {
            // Crear un Raycast para detectar al jugador
            if (Physics.Raycast(transform.position, direccion, Vector3.Distance(transform.position, jugador.position)))
            {
                // Moverse hacia el jugador
                playerDetected = true;
            }
            else
            {
               playerDetected = false;
            }
        }
    }
}
