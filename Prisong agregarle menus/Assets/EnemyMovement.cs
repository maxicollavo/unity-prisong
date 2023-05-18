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
    public bool enemyTrigger = false;


    private void Start()
    {
        stayAlert = true;
        Animator AnimE = GetComponent<Animator>();
        NavMeshAgent agent = GetComponent<NavMeshAgent>();
    }
    void Update()
    {
        FaceTarget(player.transform.position);
        EnemyAnim();
        EnemyStun();
        agent.SetDestination(player.transform.position);
    }

    private void FaceTarget(Vector3 destination)
    {
        Vector3 lookPos = destination - transform.position;
        lookPos.y = 0;
        Quaternion rotation = Quaternion.LookRotation(lookPos);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, 1);
    }

    void EnemyMove()
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

    public IEnumerator HitEnemy()
    {
        while (enemyTrigger == true)
        {
            WalkingEnemy.SetBool("enemyTrigger", true);
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
            yield return new WaitForSeconds(2);
        }
    }

    void OnTriggerEnter(Collider collider)
     {
        if (collider.transform.tag == "PlayerTrigger")
        {
            enemyTrigger = true;
            StartCoroutine(HitEnemy());
        }
     }

    private void OnTriggerExit(Collider collider)
    {
        if (collider.transform.tag == "PlayerTrigger")
        {
            enemyTrigger = false;
            WalkingEnemy.SetBool("enemyTrigger", false);

        }
    }
}
