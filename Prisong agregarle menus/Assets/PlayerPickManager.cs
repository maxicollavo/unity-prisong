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
    public LayerMask rockMask;
    public LayerMask doorEscapeMask;
    public LayerMask dispenserMask;
    public LayerMask pianoMask;
    float radious = 1.33f;
    public GameObject enemy;
    public GameObject runSign;
    public GameObject piano2;
    public GameObject pianoFull;
    public GameObject cage;
    public GameObject closeChest;
    public GameObject openChest;
    public GameObject rock;
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

    public void RockPick()
    {
        if (Config.picksCount >= Config.picksRequired && Config.pianoCount == 2)
        {
            Collider[] collidersRock = Physics.OverlapSphere(transform.position, radious, rockMask);
            if (collidersRock.Length > 0)
            {
                Collider rock = collidersRock[0];
                rock.gameObject.SetActive(false);
                Config.rockPickCount++;
                //anxietyBarBehaviour.TokenEarned();
                fCollision.pressFInstruction.SetActive(false);
            }
        }
    }

    public void PianoInteract()
    {
        if (Config.picksCount >= 1 && Config.pianoCount == 0)
        {
            Collider[] collidersPiano = Physics.OverlapSphere(transform.position, radious, pianoMask);
            if (collidersPiano.Length > 0)
            {
                Collider piano1 = collidersPiano[0];
                piano2.SetActive(true);
                eCollision.pressEInteractPiano.SetActive(false);
                Config.pianoCount++;
            }
        }
        else if (Config.picksCount >= 2 && Config.pianoCount == 1)
        {
            Collider[] collidersPiano = Physics.OverlapSphere(transform.position, radious, pianoMask);
            if (collidersPiano.Length > 0)
            {
                Collider piano2 = collidersPiano[0];
                piano2.gameObject.SetActive(false);
                pianoFull.SetActive(true);
                eCollision.pressEInteractPiano.SetActive(false);
                Config.pianoCount++;
                cage.SetActive(false);
                closeChest.SetActive(false);
                openChest.SetActive(true);
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
        if (Config.rockPickCount >= Config.escapePicksRequired)
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