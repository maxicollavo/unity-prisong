using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mechanics : MonoBehaviour
{
    public GameObject playerTriggerInv;
    public AnxietyBarBehaviour anxietyBarBeh;
    public float timeCount;

    public void Start()
    {
        timeCount = 0f;
    }

    public void Invisibility()
    {
        timeCount += Time.deltaTime;
        while (anxietyBarBeh.fullPicks == false && timeCount <= 5)
        {
            playerTriggerInv.SetActive(false);
        }
        timeCount = 0f;
    }
}
