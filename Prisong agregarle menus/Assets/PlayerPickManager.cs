using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPickManager : MonoBehaviour
{
    public PlayerInputManager playerInputManager;
    public EnemyMovement enemyMovement;
    public GameSceneManager gameSceneManager;
    public LifeController lifeController;
    public ECollision eCollision;
    public FCollision fCollision;
    public NeedObjectCollision needObjectCollision;
    public AnxietyBarBehaviour anxietyBarBehaviour;
    public LayerMask pickMask;
    public LayerMask partitureMask;
    public LayerMask doorEscapeMask;
    public LayerMask dispenserMask;
    float radious = 1.33f;
    public GameObject enemy;
    public GameObject runSign;
    public bool enemyKill = false;
    public float timeCount;

    void Start()
    {
        timeCount = 0f;
    }

    void Update()
    {
        if (Config.picksCount == 1)
        {
            runSign.SetActive(true);
            timeCount += Time.deltaTime;
        }
        if (timeCount >= 3f)
        {
            runSign.SetActive(false);
        }
    }

    public void Picks()
    {
        Collider[] collidersPick = Physics.OverlapSphere(transform.position, radious, pickMask);
        for (int i = 0; i < collidersPick.Length; i++)
        {
            Collider pick = collidersPick[0];
            pick.gameObject.SetActive(false);
            enemy.SetActive(true);
            Config.picksCount++;
            eCollision.pressEInstruction.SetActive(false);
            //PowerUp powerUp = collidersPick[i].gameObject.GetComponent<PowerUp>();
            //powerUp.Active(playerInputManager);
        }
    }

    public void DispenserMachineInteract()
    {
        for (int i = 1; i >= Config.anxietyBarTokensEarned; i++)
        {
            Collider[] collidersDispenser = Physics.OverlapSphere(transform.position, radious, dispenserMask);
            if (collidersDispenser.Length > 0)
            {
                Collider dispenser = collidersDispenser[0];
                if (Config.anxietyBarTokensEarned <= Config.anxietyBarMaxToken)
                {
                    lifeController.lives = Config.maxLives;
                }
            }
        }
    }

    public void PartiturePick()
    {
        if (Config.picksCount >= Config.picksRequired)
        {
            Collider[] collidersPartiture = Physics.OverlapSphere(transform.position, radious, partitureMask);
            if (collidersPartiture.Length > 0)
            {
                Collider partiture = collidersPartiture[0];
                partiture.gameObject.SetActive(false);
                Config.partiturePickCount++;
                //anxietyBarBehaviour.TokenEarned();
                fCollision.pressFInstruction.SetActive(false);
            }
        }
    }

    /*public void EnemyKill()
    {
        if (enemyMovement.enemyStun == true)
        {
            EnemyInteract();
            enemyKill = true;
        }
    }

    public void EnemyInteract()
    {
        enemy.SetActive(false);
        if (Config.objectInstantiateCount == 0)
        {
            Vector3 posicion = new Vector3(0, 8.27f, 0);
            Instantiate(enemyMovement.enemyLastObject, posicion, Quaternion.identity);
            Config.objectInstantiateCount++;
        }
        else return;
    }*/

    public void EscapeDoor()
    {
        if (Config.partiturePickCount >= Config.escapePicksRequired)
        {
            Collider[] collidersDoor = Physics.OverlapSphere(transform.position, radious, doorEscapeMask);
            if (collidersDoor.Length > 0)
            {
                fCollision.pressFEscapeInstruction.SetActive(false);
                gameSceneManager.LoadWinMenu();
            }
        }
    }
}