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
    public bool enemyStun = false;
    public bool stayAlert = true;
    public Vector3 dir;
    public float speedRoat;
    public NavMeshAgent agent;

    private void Start()
    {
        Animator AnimE = GetComponent<Animator>();
        NavMeshAgent agent = GetComponent<NavMeshAgent>();
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
        dir = player.transform.position - transform.position;
        transform.forward = dir;
    }

    void EnemyAnim()
    {
        if (stayAlert == true) WalkingEnemy.SetBool("WalkingE", true);
        else if (stayAlert == false) WalkingEnemy.SetBool("WalkingE", false);
    }

    public void EnemyStun()
    {
        if (Config.partiturePickCount == 1)
        {
            stayAlert = false;
            enemyStun = true;
            agent.speed = 0f;
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
