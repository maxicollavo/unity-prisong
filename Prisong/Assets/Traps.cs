using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Traps : MonoBehaviour
{
    public PlayerInputManager playerInputManager;
    public LifeController lifeController;
    public float time;
    public bool alarmActive;
    public bool alarmActiveUse;
    public static bool tutorialTerminado = false;
    public List <GameObject> deactivatedAlarms = new List<GameObject>();
    public AudioSource bombTick;
    public AudioSource electro;
    public AudioSource deactivateBomb;
    public GameObject paredes;
    public GameObject EscapeX;

    private void Start()
    {
        time = Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 18 && deactivatedAlarms.IndexOf(other.gameObject) == -1 && playerInputManager.crouch == false)
        {
            if (!alarmActiveUse)
            {
                alarmActive = true;
                StartCoroutine(WaitAndAttack(other.gameObject));
            }
        }
        if (other.gameObject.layer == 19)
        {
            lifeController.Hit(4);
        }
        if (other.CompareTag("ResetTutorial"))
        {
            if (tutorialTerminado == false)
            {
             paredes.SetActive(false);
                LifeController.lives = Config.maxLives;

            }
        }

    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("ResetTutorial"))
        {
            paredes.SetActive(true);
            tutorialTerminado = true;

        }
    }
    public IEnumerator WaitAndAttack(GameObject alarm)
    {
        while (alarmActive)
        {
            EscapeX.SetActive(true);
            playerInputManager.speed = 0;
            Debug.Log("Se activó");
            yield return new WaitForSeconds(2);
            if (alarmActive)
            {
                electro.Play();
                lifeController.Hit(1);
                Debug.Log("Exploto");
                yield return new WaitForSeconds(2);
            }

        }
        if (alarmActive == false)
        {
            EscapeX.SetActive(false);
            Debug.Log("Se desactivó");
            deactivateBomb.Play();
            bombTick.Stop();
            deactivatedAlarms.Add(alarm);
            playerInputManager.speed = Config.playerSpeed;
        }
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.X))
        {
            alarmActive = false;
            alarmActiveUse = true;
        }
    }
}
