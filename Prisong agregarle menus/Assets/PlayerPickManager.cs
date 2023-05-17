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
    public LayerMask chestMask;
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
        Debug.Log(Config.picksCount);
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

    public void PianoInteract()
    {
        /*if (Config.picksCount == 0)
        {
            Collider[] collidersPiano = Physics.OverlapSphere(transform.position, radious, pianoMask);
            if (collidersPiano.Length > 0)
            {
                Collider piano1 = collidersPiano[0];
                //needObjectCollision.needObjectInstruction.SetActive(true);
            }
        }*/
        
        if (Config.picksCount == 2 && Config.keyCount == 0)
        {
            Collider[] collidersPiano = Physics.OverlapSphere(transform.position, radious, pianoMask);
            if (collidersPiano.Length > 0)
            {
                Config.picksCount--;
            }
        }
        else if (Config.picksCount == 1 && Config.keyCount == 0)
        {
            Collider[] collidersPiano = Physics.OverlapSphere(transform.position, radious, pianoMask);
            if (collidersPiano.Length > 0)
            {
                Collider piano1 = collidersPiano[0];
                piano2.SetActive(true);
                Config.keyCount++;
            }
        }
        else if (Config.picksCount == 2 && Config.keyCount == 1)
        {
            Collider[] collidersPiano = Physics.OverlapSphere(transform.position, radious, pianoMask);
            if (collidersPiano.Length > 0)
            {
                Collider piano1 = collidersPiano[0];
                piano2.SetActive(true);
                pianoFull.SetActive(true);
                cage.SetActive(false);
                Config.keyCount++;
            }
        }
    }

    public void ChestInteract()
    {
        if (Config.keyCount == 2)
        {
            Collider[] collidersChest = Physics.OverlapSphere(transform.position, radious, chestMask);
            if (collidersChest.Length > 0)
            {
                closeChest.SetActive(false);
                openChest.SetActive(true);
                eCollision.pressEInstruction.SetActive(false);
            }
        }
    }

    public void StoneInteract()
    {
        if (Config.keyCount == 2)
        {
            Collider[] collidersStone = Physics.OverlapSphere(transform.position, radious, rockMask);
            if (collidersStone.Length > 0)
            {
                rock.SetActive(false);
                Config.rockPickCount++;
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
        if (Config.rockPickCount >= 1)
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