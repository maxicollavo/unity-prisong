using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyDetection : MonoBehaviour
{
    public static bool playerDetected;
    public float rangoVision = 10f; // Distancia m�xima de detecci�n
    public float anguloVision = 60f; // �ngulo de visi�n
    public Transform jugador;
    public float velocidad = 5f;
    public NavMeshAgent agent;
    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    private void OnDrawGizmos()
    {
        // Dibujar el arco del �ngulo de visi�n
        Gizmos.color = Color.yellow;
        Gizmos.matrix = Matrix4x4.TRS(transform.position, transform.rotation, Vector3.one);
        Gizmos.DrawFrustum(Vector3.zero, anguloVision, 0f, rangoVision, 1f);

        // Dibujar la l�nea hacia el jugador
        Gizmos.color = Color.red;
        if (jugador != null)
        {
            Gizmos.DrawLine(transform.position, jugador.position);
        }
    }

    void Update()
    {
        // Obtener la direcci�n hacia el jugador
        Vector3 direccion = (jugador.position - transform.position).normalized;
        // Calcular el �ngulo entre la direcci�n del jugador y el frente del enemigo
        float angulo = Vector3.Angle(transform.forward, direccion);
        // Verificar si el jugador est� dentro del rango de visi�n y dentro del �ngulo de visi�n
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
