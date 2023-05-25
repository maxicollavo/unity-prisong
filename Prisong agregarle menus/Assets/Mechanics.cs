using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mechanics : MonoBehaviour
{
    public GameObject playerTriggerInv;
    public GameObject playerTriggerFol;
    public GameObject player;
    public AnxietyBarBehaviour anxietyBarBeh;
    public float timeCount;
    CapsuleCollider _cc;
    public bool invisibility;

    public void Start()
    {
        timeCount = 0f;
        invisibility = false;
        _cc = player.GetComponent<CapsuleCollider>();
    }

    public void Invisibility()
    {
        if (anxietyBarBeh.fullPicks == false /*poner true*/ && invisibility == false)
        {
            timeCount += Time.deltaTime;
            invisibility = true;
            playerTriggerInv.SetActive(false);
            playerTriggerFol.SetActive(false);
            _cc.enabled = !_cc.enabled;
        }
    }
}
