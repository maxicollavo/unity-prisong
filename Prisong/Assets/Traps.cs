using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Traps : MonoBehaviour
{
    public LifeController lifeController;
    public float time;
    public static bool alarmActive;
    public bool deactivatedAlarm;
    public AudioSource bombTick;
    public AudioSource electro;
    public AudioSource deactivateBomb;
    public GameObject EscapeX;

    private void Start()
    {
        time = Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 6 && !deactivatedAlarm)
        {
            alarmActive = true;
            StartCoroutine(WaitAndAttack(other.gameObject));
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
                StartCoroutine(lifeController.LivesElectro());
                yield return new WaitForSeconds(1);
                electro.Play();
                yield return new WaitForSeconds(0.5f);
                lifeController.Hit(1);
                yield return new WaitForSeconds(2);
            }
        }
        if (alarmActive == false)
        {
            bombTick.Stop();
            deactivatedAlarm = true;
        }
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.X) && alarmActive)
        {
            deactivateBomb.Play();
            alarmActive = false;
            EscapeX.SetActive(false);
        }
    }
}
