using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightConfig : MonoBehaviour
{
    public bool yellowLightOn;
    public bool greenLightOn;
    public bool enemyNear;
    public GameObject yellowLight;
    public GameObject greenLight;

    public IEnumerator LightsEnemy()
    {   
        while (enemyNear == true)
        {
            yellowLightOn = false;
            greenLightOn = true;
            yield return new WaitForSeconds(1);
            yellowLightOn = true;
            greenLightOn = false;
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
        if (other.transform.tag == "EnemyTriggerNear")
        {
            Debug.Log("TriggerEnter");
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
            Debug.Log("TriggerExit");
        }
    }

    public void Start()
    {
        yellowLight.SetActive(true);
        greenLight.SetActive(false);
        yellowLightOn = true;
        greenLightOn = false;
        enemyNear = false;
    }

    public void Update()
    {
        if (greenLightOn == true && yellowLightOn == false)
        {
            greenLight.SetActive(true);
            yellowLight.SetActive(false);
        }
        else if (yellowLight == true && greenLightOn == false)
        {
            greenLight.SetActive(false);
            yellowLight.SetActive(true);
        }
    }
}
