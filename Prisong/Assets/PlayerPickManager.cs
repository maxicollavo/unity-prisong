using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    public LayerMask pickMask, diskMask, rockMask, chestMask, doorEscapeMask, pianoMask, noteMask, playRecordMask;
    float radious = 1.33f;
    public GameObject enemy, runSign, runAwaySign, piano2, pianoFull, cage, closeChest, openChest, rock, note, noteUI, disk, diskTwo, openWall;
    public GameObject piano2Dark, pianoFullDark, cageDark, closeChestDark, openChestDark, rockDark;
    public bool enemyKill = false, chestOpen = false, signOne = false, signTwo = false, signThree = false, signFour = false, haveDisk = false, noteOn;
    public float timeCount;

    public void Start()
    {
        timeCount = 0f;
        noteOn = false;
    }

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
                openWall.gameObject.SetActive(false);
                eCollision.pressEInteractPiano.SetActive(false);
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

    /*public void PianoInteractDarkWorld()
    {
        if (Config.picksCount == 1 && signThree == false)
        {
            Collider[] collidersPiano = Physics.OverlapSphere(transform.position, radious, pianoMask);
            if (collidersPiano.Length > 0)
            {
                eCollision.pressEInteractPiano.SetActive(false);
                piano2Dark.SetActive(true);
                signThree = true;
                if (Config.trepCount < 4 && Config.anxietyBarCount < 4)
                {
                    trepBarBeh.enemyTriggerMap.SetActive(true);
                }
                else trepBarBeh.enemyTriggerMap.SetActive(false);
            }
        }
        else if (Config.picksCount == 2 && signFour == false)
        {
            Collider[] collidersPiano = Physics.OverlapSphere(transform.position, radious, pianoMask);
            if (collidersPiano.Length > 0)
            {
                piano2Dark.SetActive(true);
                pianoFullDark.SetActive(true);
                eCollision.pressEInteractPiano.SetActive(false);
                cageDark.SetActive(false);
                Config.keyCount = 2;
                signFour = true;
                Config.picksCount = 0;
                fCollision.pressFInteractChest.SetActive(true);
            }
        }
        else if (signThree == true)
        {
            eCollision.pressEInteractPiano.SetActive(false);
        }
    }*/

    public void PianoInteract()
    {
        if (Config.picksCount == 1 && signOne == false)
        {
            Collider[] collidersPiano = Physics.OverlapSphere(transform.position, radious, pianoMask);
            if (collidersPiano.Length > 0)
            {
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
                if (Config.rockPickCount == 1)
                {
                    runAwaySign.SetActive(true);
                }
            }
        }
    }

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