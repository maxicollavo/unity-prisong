using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightConfig : MonoBehaviour
{
    public bool yellowLightOn;
    public bool greenLightOn;
    public bool redLightOn;
    public bool roseLightOn;
    public bool blueLightOn;
    public bool enemyNear;
    public bool enemyPickNear;
    public bool keyTrigger;
    public bool noLights;
    public GameObject yellowLight;
    public GameObject greenLight;
    public GameObject redLight;
    public GameObject roseLight;
    public GameObject blueLight;

    public void WinningLights(int repeatCount)
    {
        enemyNear = false;
        enemyPickNear = false;
        keyTrigger = false;
        noLights = false;
        StartCoroutine(WinningLightsCoroutine(repeatCount));
    }

    public void GreenLight()
    {
        roseLightOn = false;
        blueLightOn = false;
        yellowLightOn = false;
        greenLightOn = true;
        redLightOn = false;
        noLights = false;
    }

    public void YellowLight()
    {
        roseLightOn = false;
        blueLightOn = false;
        yellowLightOn = true;
        greenLightOn = false;
        redLightOn = false;
        noLights = false;
    }

    public void RedLight()
    {
        roseLightOn = false;
        blueLightOn = false;
        yellowLightOn = false;
        greenLightOn = false;
        redLightOn = true;
        noLights = false;
    }

    public void RoseLight()
    {
        roseLightOn = true;
        blueLightOn = false;
        yellowLightOn = false;
        greenLightOn = false;
        redLightOn = false;
        noLights = false;
    }

    public void BlueLight()
    {
        roseLightOn = false;
        blueLightOn = true;
        yellowLightOn = false;
        greenLightOn = false;
        redLightOn = false;
        noLights = false;
    }

    public void NoLights()
    {
        yellowLightOn = false;
        greenLightOn = false;
        redLightOn = false;
        noLights = true;
    }

    public IEnumerator WinningLightsCoroutine(int repeatCount)
    {
        for (int i = 0; i < repeatCount; i++)
        {
            YellowLight();
            yield return new WaitForSeconds(0.5f);
            RedLight();
            yield return new WaitForSeconds(0.5f);
            GreenLight();
            yield return new WaitForSeconds(0.5f);
            RoseLight();
            yield return new WaitForSeconds(0.5f);
            BlueLight();
        }
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

    public virtual void Start()
    {
        keyTrigger = false;
        YellowLight();
        LightEnemyOff();
    }

    public void Update()
    {
        InitialConfig();
    }

    public void InitialConfig()
    {
        roseLight.SetActive(roseLightOn && !noLights);
        blueLight.SetActive(blueLightOn && !noLights);
        greenLight.SetActive(greenLightOn && !noLights);
        yellowLight.SetActive(yellowLightOn && !noLights);
        redLight.SetActive(redLightOn && !noLights);
    }
}
