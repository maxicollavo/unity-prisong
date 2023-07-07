using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Traps : MonoBehaviour
{
    public LifeController lifeController;
    public float time;
    public static bool alarmActive;
    public static bool tutorialTerminado = false;
    public bool deactivatedAlarm;
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
        if (other.gameObject.layer == 6 && !deactivatedAlarm)
        {
            Debug.LogWarning("Entro trampa elect");
            alarmActive = true;
            StartCoroutine(WaitAndAttack(other.gameObject));
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
            yield return new WaitForSeconds(2);
            if (alarmActive)
            {
                electro.Play();
                StartCoroutine(lifeController.LivesElectro());
                yield return new WaitForSeconds(2f);
                Debug.Log("Saca vida");
                lifeController.Hit(1);
                yield return new WaitForSeconds(2);
            }
        }
        if (alarmActive == false)
        {
            deactivateBomb.Play();
            EscapeX.SetActive(false);
            bombTick.Stop();
            deactivatedAlarm = true;
        }
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.X) && alarmActive)
        {
            alarmActive = false;
        }
    }
}
