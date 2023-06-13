using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPickManager : MonoBehaviour
{
    public LightConfig lightConfig;
    public PlayerInputManager playerInputManager;
    public TrepidationBarBehaviour trepBarBeh;
    public EnemyMovement enemyMovement;
    public GameSceneManager gameSceneManager;
    public LifeController lifeController;
    public ECollision eCollision;
    public FCollision fCollision;
    public NeedObjectCollision needObjectCollision;
    public AnxietyBarBehaviour anxietyBarBehaviour;
    public LayerMask pickMask;
    public LayerMask diskMask;
    public LayerMask rockMask;
    public LayerMask chestMask;
    public LayerMask doorEscapeMask;
    public LayerMask dispenserMask;
    public LayerMask pianoMask;
    public LayerMask noteMask;
    public LayerMask playRecordMask;
    float radious = 1.33f;
    public GameObject enemy;
    public GameObject runSign;
    public GameObject runAwaySign;
    public GameObject piano2;
    public GameObject pianoFull;
    public GameObject cage;
    public GameObject closeChest;
    public GameObject openChest;
    public GameObject rock;
    public GameObject note;
    public GameObject noteUI;
    public GameObject disk;
    public GameObject diskTwo;
    public bool enemyKill = false;
    public bool chestOpen = false;
    public bool signOne = false;
    public bool signTwo = false;
    public bool haveDisk = false;
    public bool noteOn;
    public float timeCount;


    void Start()
    {
        timeCount = 0f;
        noteOn = false;

    }

   

    /*public void DispenserMachineInteract()
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
    }*/

    public void Disk()
    {
        Collider[] collidersDisk = Physics.OverlapSphere(transform.position, radious, diskMask);
        for (int i = 0; i < collidersDisk.Length; i++)
        {
            Collider pick = collidersDisk[0];
            disk.gameObject.SetActive(false);
            eCollision.pressEInstruction.SetActive(false);
            haveDisk = true;
        }
       
    }

    public void PlayRecord()
    {
        if (haveDisk == true)
        {
            Collider[] collidersPlayRecord = Physics.OverlapSphere(transform.position, radious, playRecordMask);
            for (int i = 0; i < collidersPlayRecord.Length; i++)
            {
                Collider playRecord = collidersPlayRecord[0];
                diskTwo.gameObject.SetActive(true);
                eCollision.pressEInstruction.SetActive(false);
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
            lightConfig.YellowLight();
        }
    }

    public void PianoInteract()
    {
        if (Config.picksCount == 1 && signOne == false)
        {
            Collider[] collidersPiano = Physics.OverlapSphere(transform.position, radious, pianoMask);
            if (collidersPiano.Length > 0)
            {
                //Collider piano1 = collidersPiano[0];
                eCollision.pressEInteractPiano.SetActive(false);
                piano2.SetActive(true);
                signOne = true;
                if (Config.trepCount < 4 && Config.anxietyBarCount < 4)
                {
                    trepBarBeh.enemyTriggerMap.SetActive(true);
                }
                else trepBarBeh.enemyTriggerMap.SetActive(false);
            }
        }
        else if (Config.picksCount == 2 && signTwo == false)
        {
            Collider[] collidersPiano = Physics.OverlapSphere(transform.position, radious, pianoMask);
            if (collidersPiano.Length > 0)
            {
                //Collider piano1 = collidersPiano[0];
                piano2.SetActive(true);
                pianoFull.SetActive(true);
                eCollision.pressEInteractPiano.SetActive(false);
                cage.SetActive(false);
                Config.keyCount = 2;
                signTwo = true;
                Config.picksCount = 0;
                fCollision.pressFInteractChest.SetActive(true);
            }
        }
        else if (signTwo == true)
        {
            eCollision.pressEInteractPiano.SetActive(false);
        }
    }

    public void ChestInteract()
    {
        if (Config.keyCount == 2 && closeChest.activeInHierarchy)
        {
            Collider[] collidersChest = Physics.OverlapSphere(transform.position, radious, chestMask);
            if (collidersChest.Length > 0)
            {
                closeChest.SetActive(false);
                openChest.SetActive(true);
                rock.SetActive(true);
                fCollision.pressFInteractChest.SetActive(false);
                chestOpen = true;
            }
        }
    }

    public void StoneInteract()
    {
        if (rock.activeInHierarchy)
        {
            Collider[] collidersStone = Physics.OverlapSphere(transform.position, radious, rockMask);
            if (collidersStone.Length > 0)
            {
                rock.SetActive(false);
                Config.rockPickCount++;
                eCollision.pressEInstruction.SetActive(false);
                runAwaySign.SetActive(true);
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
    public void NotePick()
    {
        Collider[] collidersPick = Physics.OverlapSphere(transform.position, radious, noteMask);
        for (int i = 0; i < collidersPick.Length; i++)
        {
            if (noteOn == false)
            {
                Collider pick = collidersPick[0];
                note.gameObject.SetActive(false);
                noteUI.gameObject.SetActive(true);
                eCollision.pressEInstruction.SetActive(false);
                Time.timeScale = 0f;
                noteOn = true;
                note.gameObject.SetActive(true);

            }
            else if (noteOn == true)
            {
                Collider pick = collidersPick[0];
                note.gameObject.SetActive(true);
                noteUI.gameObject.SetActive(false);
                eCollision.pressEInstruction.SetActive(true);
                noteOn = false;
                Time.timeScale = 1f;
            }
        }
    }

   
}