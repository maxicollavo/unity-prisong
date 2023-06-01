using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mechanics : MonoBehaviour
{
    public GameObject enemyTrigger;
    public GameObject enemyTrepTrigger;
    public GameObject playerTriggerInv;
    public GameObject playerTriggerFol;
    public GameObject player;
    public GameObject enemy;
    public AnxietyBarBehaviour anxietyBarBeh;
    public float timeCount;
    CapsuleCollider _cc;
    CapsuleCollider _enemyCc;
    public bool invisibility;

    public void Start()
    {
        timeCount = 0f;
        invisibility = false;
        _cc = player.GetComponent<CapsuleCollider>();
        _enemyCc = enemy.GetComponent<CapsuleCollider>();
    }

    public void Invisibility()
    {
        if (anxietyBarBeh.fullPicks == false /*poner true*/ && invisibility == false)
        {
            StartCoroutine(ActivateInvisibility());
        }
    }

    public void InvisibilityOff()
    {
        enemyTrigger.SetActive(true);
        enemyTrepTrigger.SetActive(true);
        Physics.IgnoreCollision(_cc, _enemyCc, false);
        invisibility = false;
        playerTriggerInv.SetActive(true);
        playerTriggerFol.SetActive(true);
        _cc.enabled = true;
    }

    public IEnumerator ActivateInvisibility()
    {
        enemyTrigger.SetActive(false);
        enemyTrepTrigger.SetActive(false);
        Physics.IgnoreCollision(_cc, _enemyCc, true);
        invisibility = true;
        playerTriggerInv.SetActive(false);
        playerTriggerFol.SetActive(false);
        //_cc.enabled = false;
        yield return new WaitForSeconds(5);
        InvisibilityOff();
    }
}
