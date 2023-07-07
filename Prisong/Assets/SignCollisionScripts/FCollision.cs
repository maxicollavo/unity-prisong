using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FCollision : MonoBehaviour
{
    public GameObject pressFInstruction;
    public GameObject pressFEscapeInstruction;
    public GameObject pressFKillEnemy;
    public GameObject pressFInteractChest;
    public PlayerPickManager playerPickManager;
    public GameSceneManager gameSceneManager;

    public GameObject tutorialNote;
    public GameObject laserNote;

    void OnTriggerEnter(Collider collision)
    {
        if (collision.transform.tag == "Chest")
        {
            ChestRefs chestRefs = collision.gameObject.GetComponent<ChestRefs>();
            int pianoKeys = chestRefs.piano.GetComponent<PianoKeyCounter>().Keys;
            if (pianoKeys == 2 && collision.gameObject.activeInHierarchy)
            {
                pressFInteractChest.SetActive(true);    
            }
        }
        if (Config.rockPickCount == 2)
        {
            if (collision.transform.tag == "DoorEscape")
            {
                pressFEscapeInstruction.SetActive(true);
            }
        }
            if (collision.gameObject.layer == 20)
            {
                gameSceneManager.LoadMainMenu();
            }

            if (collision.gameObject.layer == 21)
            {
                StartCoroutine(PickTutorial());
            }

            if (collision.gameObject.layer == 22)
            {
                StartCoroutine(LaserTutorial());
            }

    }

    public IEnumerator PickTutorial()
    {
        tutorialNote.SetActive(true);
        yield return new WaitForSeconds(2);
        tutorialNote.SetActive(false);
    }

    public IEnumerator LaserTutorial()
    {
        laserNote.SetActive(true);
        yield return new WaitForSeconds(2);
        laserNote.SetActive(false);
    }

    void OnTriggerExit(Collider collision)
    {
        pressFKillEnemy.SetActive(false);
        pressFEscapeInstruction.SetActive(false);
        pressFInstruction.SetActive(false);
        pressFInteractChest.SetActive(false);

    }
}