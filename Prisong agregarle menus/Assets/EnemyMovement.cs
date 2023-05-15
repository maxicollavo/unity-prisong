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
    public bool stayAlert;
    public Vector3 dir;
    public float speedRoat;
    public NavMeshAgent agent;


    private void Start()
    {
        stayAlert = true;
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
        if (Config.rockPickCount == 1)
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
            if (lifeController.lives == 3)
            {
                lifeController.heart1.SetActive(false);
            }
            if (lifeController.lives == 2)
            {
                lifeController.heart2.SetActive(false);
            }
            if (lifeController.lives == 1)
            {
                lifeController.heart3.SetActive(false);
            }
        }
    }
}
