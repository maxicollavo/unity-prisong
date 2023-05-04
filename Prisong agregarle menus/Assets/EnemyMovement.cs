using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    public PlayerPickManager playerPickManager;
    public LifeController lifeController;
    public GameObject player;
    public GameObject enemy;
    public GameObject enemyLastObject;
    public LayerMask mask;
    float radious = 2f;
    public Animator WalkingEnemy;
    public bool stayAlert = false;
    public bool enemyStun = false;
    public Vector3 dir;
    public float speedRoat;
    public NavMeshAgent agent;

    private void Start()
    {
        Animator AnimE = GetComponent<Animator>();
    }
    void Update()
    {
        enemyMove();
        EnemyAnim();
        EnemyStun();
        agent.SetDestination(player.transform.position);
    }

    void enemyMove()
    {
        Collider[] collidersPick = Physics.OverlapSphere(player.transform.position, radious, mask);
        stayAlert = true;
        dir = player.transform.position - transform.position;
        transform.forward = dir;
    }

    void EnemyAnim()
    {
        if (stayAlert == true)
        {
            WalkingEnemy.SetBool("WalkingE", true);
        }
    }

    public void EnemyStun()
    {
        if (Config.partiturePickCount == 1)
        {
            stayAlert = false;
            enemyStun = true;
        }
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.transform.tag == "PlayerTrigger")
        {
            lifeController.Hit();
        }
    }
}
