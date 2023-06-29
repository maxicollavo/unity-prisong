using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public partial class PlayerPickManager : MonoBehaviour
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
    public GameObject enemy, runSign, runAwaySign, note, noteUI, disk, diskTwo, openWall, stoneLeft1, stoneLeft2;
    public GameObject piano2Dark, pianoFullDark, cageDark, closeChestDark, openChestDark;
    public bool putRockOneB = false, enemyKill = false, chestOpen = false, signOne = false, signTwo = false, signThree = false, signFour = false, haveDisk = false, noteOn;
    public float timeCount;
    public bool Audio;
    public AudioSource Audiosource;
    public AudioSource putRock;

    public void Start()
    {
        timeCount = 0f;
        noteOn = false;
        Audio = false;
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
                if (diskTwo.activeInHierarchy)
                {
                    Audio = true;
                    if (Audio == true)
                    {
                        Audiosource.Play();
                    }
                    else Audio = false;
                    
                }
            }
        }

    }
    public void OnTriggerEnter(Collider collider)
    {
        if (collider.transform.tag == "EnemyTriggerNear")
        {
            Audiosource.volume = 0.90f;
          
        }
        else
        {
            return;
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
        Collider[] collidersPiano = Physics.OverlapSphere(transform.position, radious, pianoMask);
        if (collidersPiano.Length > 0)
        {
            GameObject pianoGO = collidersPiano[0].gameObject;
            var counter = pianoGO.GetComponent<PianoKeyCounter>();
            var pianoRefs = pianoGO.GetComponent<PianoRefs>();

            if (Config.picksCountUsed < Config.picksCount)
            {
                Config.picksCountUsed++;
                counter.Keys++;

                eCollision.pressEInteractPiano.SetActive(false);

                // if (counter.Keys == 1) {
                //     keyRefs.key1.SetActive(true);
                // }
                // else if (counter.Keys == 2) {
                //     keyRefs.key2.SetActive(true);
                // }

                // Version simplificada del bloque de arriba, hace lo mismo
                pianoRefs.key1.SetActive(counter.Keys >= 1);
                pianoRefs.key2.SetActive(counter.Keys >= 2);

                if (counter.Keys == 2)
                {
                    fCollision.pressFInteractChest.SetActive(true);
                    pianoRefs.cage.SetActive(false);
                }
            }
        }
    }

    public void ChestInteract()
    {
        Collider[] collidersChest = Physics.OverlapSphere(transform.position, radious, chestMask);
        if (collidersChest.Length > 0)
        {
            GameObject chestGO = collidersChest[0].gameObject;
            ChestRefs chestRefs = chestGO.GetComponent<ChestRefs>();
            int pianoKeys = chestRefs.piano.GetComponent<PianoKeyCounter>().Keys;

            if (pianoKeys == 2 && chestGO.activeInHierarchy)
            {
                chestRefs.openChest.SetActive(true);
                chestRefs.rock.SetActive(true);
                chestGO.SetActive(false);
                fCollision.pressFInteractChest.SetActive(false);
            }
        }
    }

    public void StoneInteract()
    {
        Collider[] collidersStones = Physics.OverlapSphere(transform.position, radious, rockMask);
        if (collidersStones.Length > 0 && collidersStones[0].gameObject.activeInHierarchy)
        {
            Config.rockPickCount++;
            eCollision.pressEInstruction.SetActive(false);
            collidersStones[0].gameObject.SetActive(false);

            if (Config.rockPickCount == 2)
            {
                runAwaySign.SetActive(true);
            }
        }
    }

    public IEnumerator putRockOne()
    {
        stoneLeft1.SetActive(true);
        yield return new WaitForSeconds(.5f);
        stoneLeft1.SetActive(false);
        yield return new WaitForSeconds(.5f);
        stoneLeft1.SetActive(true);
        yield return new WaitForSeconds(.5f);
        stoneLeft1.SetActive(false);
        yield return new WaitForSeconds(.5f);
        stoneLeft1.SetActive(true);
    }

    public IEnumerator putRockTwo()
    {
        stoneLeft2.SetActive(true);
        yield return new WaitForSeconds(.5f);
        stoneLeft2.SetActive(false);
        yield return new WaitForSeconds(.5f);
        stoneLeft2.SetActive(true);
        yield return new WaitForSeconds(.5f);
        stoneLeft2.SetActive(false);
        yield return new WaitForSeconds(.5f);
        stoneLeft2.SetActive(true);
    }

    public void EscapeDoor()
    {
        if (Config.rockPickCount == 1)
        {
            Collider[] collidersDoor = Physics.OverlapSphere(transform.position, radious, doorEscapeMask);
            if (collidersDoor.Length > 0)
            {
                StartCoroutine(putRockOne());
                putRockOneB = true;
            }
        }
        if (Config.rockPickCount == 2 && putRockOneB == true)
        {
            Collider[] collidersDoor = Physics.OverlapSphere(transform.position, radious, doorEscapeMask);
            if (collidersDoor.Length > 0)
            {
                StartCoroutine(putRockTwo());
                Config.rockPickCount++;
            }
        }
        if (Config.rockPickCount == 2 && putRockOneB == false)
        {
            Collider[] collidersDoor = Physics.OverlapSphere(transform.position, radious, doorEscapeMask);
            if (collidersDoor.Length > 0)
            {
                StartCoroutine(putRockOne());
                StartCoroutine(putRockTwo());
                Config.rockPickCount++;
                lightConfig.WinningLights(3);
            }
        }
        else if (Config.rockPickCount == 3)
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