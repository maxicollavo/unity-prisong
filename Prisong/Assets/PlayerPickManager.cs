using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public partial class PlayerPickManager : MonoBehaviour
{
    public LightConfig lightConfig;
    public PlayerInputManager playerInputManager;
    public GameSceneManager gameSceneManager;
    public LifeController lifeController;
    public ECollision eCollision;
    public FCollision fCollision;
    public NeedObjectCollision needObjectCollision;
    public LayerMask pickMask, diskMask, rockMask, chestMask, doorEscapeMask, pianoMask, noteMask, playRecordMask, buttonMask, panelMask;
    float radious = 1.33f;
    int rocksInDoor = 0;
    public static bool winningLightsOn = false;
    public GameObject mirrors, enemy, runSign, runAwaySign, note, noteUI, disk, diskTwo, openWall, stoneLeft1, stoneLeft2, panelButton;
    public GameObject piano2Dark, pianoFullDark, cageDark, closeChestDark, openChestDark;
    [HideInInspector] public bool putRockOneB = false, putRockTwoB = true, Audio, enemyKill = false, haveDisk = false, chestOpen = false, signOne = false, signTwo = false, signThree = false, signFour = false, noteOn;
    [HideInInspector] public float timeCount;
    public AudioSource music, putRock, putDisk, firstDoor, pickSound, pianoCompleted, putKey, openCage, monsterScream, openChest, rockPickSound, diskPick, noteSound, winningMusic, runAwayMusic;
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
            diskPick.Play();
            Collider pick = collidersDisk[0];
            disk.gameObject.SetActive(false);
            eCollision.pressEInstruction.SetActive(false);
            haveDisk = true;
        }
    }

    public IEnumerator SoundsPlay()
    {
        haveDisk = false;
        diskTwo.SetActive(true);
        putDisk.Play();
        yield return new WaitForSeconds(1);
        openWall.SetActive(false);
        firstDoor.Play();
        yield return new WaitForSeconds(0.5f);
        music.Play();
    }

    public void PlayRecord()
    {
        if (haveDisk == true)
        {
            Collider[] collidersPlayRecord = Physics.OverlapSphere(transform.position, radious, playRecordMask);
            for (int i = 0; i < collidersPlayRecord.Length; i++)
            {
                Collider playRecord = collidersPlayRecord[0];
                StartCoroutine(SoundsPlay());
            }
        }
    }

    public IEnumerator EnemyScream()
    {
        yield return new WaitForSeconds(1);
        monsterScream.Play();
    }

    public void LaserDeactivate()
    {
        Collider[] collidersPanel = Physics.OverlapSphere(transform.position, radious, panelMask);
        for (int i = 0; i < collidersPanel.Length; i++)
        {
            Collider button = collidersPanel[0];
            if (Config.buttonCount == 1)
            {
                panelButton.SetActive(true);
                Config.buttonCount--;
                eCollision.pressEInstruction.SetActive(false);
            }
        }
    }

    public void Picks()
    {
        Collider[] collidersPick = Physics.OverlapSphere(transform.position, radious, pickMask);
        for (int i = 0; i < collidersPick.Length; i++)
        {
            pickSound.Play();
            Collider pick = collidersPick[0];
            pick.gameObject.SetActive(false);
            enemy.SetActive(true);
            Config.picksCount++;
            Config.picksCountInv++;
            eCollision.pressEInstruction.SetActive(false);
            lightConfig.YellowLight();
            if (Config.picksCount == 1)
            {
                StartCoroutine(EnemyScream());
            }
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
                Config.picksCountInv--;
                Config.picksCountUsed++;
                counter.Keys++;

                eCollision.pressEInteractPiano.SetActive(false);

                if (counter.Keys == 1)
                {
                    putKey.Play();
                    pianoRefs.key1.SetActive(true);
                }
                else if (counter.Keys == 2)
                {
                    pianoRefs.key2.SetActive(true);
                    StartCoroutine(PianoCoroutina());
                    pianoRefs.cage.SetActive(false);
                }

                // Version simplificada del bloque de arriba, hace lo mismo
                //pianoRefs.key1.SetActive(counter.Keys >= 1);
                //pianoRefs.key2.SetActive(counter.Keys >= 2);
            }
        }
    }

    public IEnumerator PianoCoroutina()
    {
        pianoCompleted.Play();
        yield return new WaitForSeconds(1);
        openCage.Play();
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
                openChest.Play();
                chestRefs.openChest.SetActive(true);
                chestRefs.rock.SetActive(true);
                chestGO.SetActive(false);
                fCollision.pressFInteractChest.SetActive(false);

            }
        }
    }
    private void Update()
    {
        if (Config.rockPickCount == 2)
        {
            timeCount += Time.deltaTime;
        }
        if (timeCount >= 3)
        {
            runAwaySign.SetActive(false);
        }
    }

    public void StoneInteract()
    {
        Collider[] collidersStones = Physics.OverlapSphere(transform.position, radious, rockMask);
        if (collidersStones.Length > 0 && collidersStones[0].gameObject.activeInHierarchy)
        {
            mirrors.SetActive(true);
            rockPickSound.Play();
            Config.rockPickCount++;
            eCollision.pressEInstruction.SetActive(false);
            collidersStones[0].gameObject.SetActive(false);

            if (Config.rockPickCount == 2)
            {
                runAwayMusic.Play();
                music.Stop();
                runAwaySign.SetActive(true);
            }
        }
    }

    public IEnumerator putRockOne()
    {
        putRock.Play();
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
        putRock.Play();
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
        Collider[] collidersDoor = Physics.OverlapSphere(transform.position, radious, doorEscapeMask);
        if (collidersDoor.Length > 0)
        {
            while (Config.rockPickCount > 0)
            {
                //poner piedra puerta
                if (rocksInDoor == 0)
                {
                    StartCoroutine(putRockOne());
                }
                else
                {
                    StartCoroutine(putRockTwo());
                }
                rocksInDoor++;
                Config.rockPickCount--;
            }

            if (winningLightsOn)
            {
                gameSceneManager.LoadWinMenu();
            }
            else if (rocksInDoor == 2)
            {
                StartCoroutine(putRockOne());
                winningMusic.Play();
                lightConfig.WinningLights(3);
                winningLightsOn = true;
            }
        }
    }

    /* public void EscapeDoor()
    {
        if (Config.rockPickCount == 1)
        {
            Collider[] collidersDoor = Physics.OverlapSphere(transform.position, radious, doorEscapeMask);
            if (collidersDoor.Length > 0)
            {
                StartCoroutine(putRockOne());
                putRockOneB = true;
                Config.rockPickCount--;
            }
        }
        if (Config.rockPickCount == 1 && putRockOneB)
        {
            Collider[] collidersDoor = Physics.OverlapSphere(transform.position, radious, doorEscapeMask);
            if (collidersDoor.Length > 0)
            {
                fCollision.pressFEscapeInstruction.SetActive(true);
                winningMusic.Play();
                StartCoroutine(putRockTwo());
                lightConfig.WinningLights(3);
                Config.rockPickCount--;
            }
        }

        if (Config.rockPickCount == 2)
        {
            Collider[] collidersDoor = Physics.OverlapSphere(transform.position, radious, doorEscapeMask);
            if (collidersDoor.Length > 0)
            {
                fCollision.pressFEscapeInstruction.SetActive(true);
                winningMusic.Play();
                StartCoroutine(putRockOne());
                StartCoroutine(putRockTwo());
                lightConfig.WinningLights(3);
                putRockTwoB = true;
                Config.rockPickCount -= 2;
            }
        }
        if (putRockTwoB)
        {
            Collider[] collidersDoor = Physics.OverlapSphere(transform.position, radious, doorEscapeMask);
            if (collidersDoor.Length > 0) //no entra
            {
                fCollision.pressFEscapeInstruction.SetActive(false);
                gameSceneManager.LoadWinMenu();
            }
        }
    }*/
    public void NotePick()
    {
        Collider[] collidersPick = Physics.OverlapSphere(transform.position, radious, noteMask);
        for (int i = 0; i < collidersPick.Length; i++)
        {
            if (noteOn == false)
            {
                noteSound.Play();
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
                noteSound.Play();
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