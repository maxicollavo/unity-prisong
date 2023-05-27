using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightConfig : MonoBehaviour
{
    public bool yellowLightOn;
    public bool greenLightOn;
    public bool redLightOn;
    public bool enemyNear;
    public GameObject yellowLight;
    public GameObject greenLight;
    public GameObject redLight;

    public IEnumerator LightsEnemy()
    {   
        while (enemyNear == true)
        {
            yellowLightOn = false;
            redLightOn = true;
            yield return new WaitForSeconds(1);
            yellowLightOn = true;
            redLightOn = false;
            yield return new WaitForSeconds(1);
        }
    }

    public IEnumerator PickAndEnemy()
    {
        while (enemyNear == true)
        {
            yellowLightOn = false;
            greenLightOn = true;
            redLightOn = true;
            yield return new WaitForSeconds(1);
            yellowLightOn = true;
            greenLightOn = false;
            redLightOn = false;
            yield return new WaitForSeconds(1);
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "KeyTrigger")
        {
            greenLightOn = true;
            yellowLightOn = false;
        }
        if (other.transform.tag == "KeyTrigger" && other.transform.tag == "EnemyTriggerNear")
        {
            enemyNear = true;
            StartCoroutine(PickAndEnemy());
        }
        if (other.transform.tag == "EnemyTriggerNear")
        {
            enemyNear = true;
            StartCoroutine(LightsEnemy());
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.transform.tag == "KeyTrigger")
        {
            greenLightOn = false;
            yellowLightOn = true;
        }
        if (other.transform.tag == "EnemyTriggerNear")
        {
            enemyNear = false;
        }
    }

    public void Start()
    {
        yellowLight.SetActive(true);
        greenLight.SetActive(false);
        yellowLightOn = true;
        greenLightOn = false;
        redLightOn = false;
        enemyNear = false;
    }

    public void Update()
    {
        if (greenLightOn == true && yellowLightOn == false && redLightOn == false)
        {
            greenLight.SetActive(true);
            yellowLight.SetActive(false);
            redLight.SetActive(false);
        }
        else if (yellowLight == true && greenLightOn == false && redLightOn == false)
        {
            greenLight.SetActive(false);
            yellowLight.SetActive(true);
            redLight.SetActive(false);
        }
        else if (redLightOn == true && yellowLight == false && greenLightOn == false)
        {
            greenLight.SetActive(false);
            yellowLight.SetActive(false);
            redLight.SetActive(true);
        }
        else if (yellowLight == true && greenLight == true && redLight == false)
        {
            greenLight.SetActive(false);
            yellowLight.SetActive(false);
            redLight.SetActive(true);
        }
    }
}
