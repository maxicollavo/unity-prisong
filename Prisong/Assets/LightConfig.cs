using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightConfig : MonoBehaviour
{
    public bool yellowLightOn;
    public bool greenLightOn;
    public bool redLightOn;
    public bool enemyNear;
    public bool enemyPickNear;
    public bool keyTrigger;
    public GameObject yellowLight;
    public GameObject greenLight;
    public GameObject redLight;

    public void GreenLight()
    {
        yellowLightOn = false;
        greenLightOn = true;
        redLightOn = false;
    }

    public void YellowLight()
    {
        yellowLightOn = true;
        greenLightOn = false;
        redLightOn = false;
    }

    public void RedLight()
    {
        yellowLightOn = false;
        greenLightOn = false;
        redLightOn = true;
    }

    public void NoLights()
    {
        yellowLightOn = false;
        greenLightOn = false;
        redLightOn = false;
    }

    public IEnumerator RedYellowInter()
    {
        enemyNear = true;
        enemyPickNear = false;
        while (enemyNear == true)
        {
            NoLights();
            yield return new WaitForSeconds(0.3f);
            YellowLight();
            yield return new WaitForSeconds(0.3f);
        }
    }

    public IEnumerator GreenRedInter()
    {
        enemyNear = false;
        enemyPickNear = true;
        while (enemyPickNear == true)
        {
            GreenLight();
            yield return new WaitForSeconds(1);
            RedLight();
            yield return new WaitForSeconds(1);
        }
    }

    public void LightEnemyOff()
    {
        yellowLightOn = true;
        greenLightOn = false;
        redLightOn = false;
        enemyNear = false;
        enemyPickNear = false;
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "KeyTrigger")
        {
            keyTrigger = true;
            GreenLight();
        }
        else if (other.transform.tag == "EnemyTriggerNear" && keyTrigger == true)
        {
            StartCoroutine(GreenRedInter());
        }
        else if (other.transform.tag == "EnemyTriggerNear")
        {
            StartCoroutine(RedYellowInter());
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.transform.tag == "KeyTrigger")
        {
            keyTrigger = false;
            LightEnemyOff();
        }
        else if (other.transform.tag == "EnemyTriggerNear" && keyTrigger == true)
        {
            enemyPickNear = false;
            LightEnemyOff();
        }
        if (other.transform.tag == "EnemyTriggerNear")
        {
            LightEnemyOff();
        }
    }

    public void Start()
    {
        keyTrigger = false;
        YellowLight();
        LightEnemyOff();
    }

    public void Update()
    {
        if (greenLightOn == true && yellowLightOn == false && redLightOn == false)
        {
            greenLight.SetActive(true);
            yellowLight.SetActive(false);
            redLight.SetActive(false);
        }
        if (greenLightOn == false && yellowLightOn == true && redLightOn == false)
        {
            greenLight.SetActive(false);
            yellowLight.SetActive(true);
            redLight.SetActive(false);
        }
        if (greenLightOn == false && yellowLightOn == false && redLightOn == true)
        {
            greenLight.SetActive(false);
            yellowLight.SetActive(false);
            redLight.SetActive(true);
        }
    }
}
