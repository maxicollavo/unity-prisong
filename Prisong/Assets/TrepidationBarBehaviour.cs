using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrepidationBarBehaviour : MonoBehaviour
{
    public bool followTrigger = false;
    public PlayerInputManager playerInputManager;
    public GameObject trepBar1;
    public GameObject trepBar2;
    public GameObject trepBar3;
    public GameObject trepBar4;
    public GameObject enemyTriggerMap;

    // Update is called once per frame
    void Update()
    {
        PlayerStunTrepidationBar();
        if (Config.trepCount <= 0)
        {
            enemyTriggerMap.SetActive(true);
        }
    }

    public IEnumerator TrepBar()
    {
        while (followTrigger == true)
        {
            TrepBarHit();
            if (Config.trepCount == 3)
            {
                trepBar1.SetActive(false);
            }
            if (Config.trepCount == 2)
            {
                trepBar2.SetActive(false);
            }
            if (Config.trepCount == 1)
            {
                trepBar3.SetActive(false);
            }
            if (Config.trepCount == 0)
            {
                trepBar4.SetActive(false);
            }
            yield return new WaitForSeconds(2);
        }
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.transform.tag == "FollowTrigger")
        {
            followTrigger = true;
            StartCoroutine(TrepBar());
        }
    }

    private void OnTriggerExit(Collider collider)
    {
        if (collider.transform.tag == "FollowTrigger")
        {
            followTrigger = false;
        }
    }

    public void TrepBarHit()
    {
        Config.trepCount--;
    }

    public IEnumerator StunTime()
    {
        if (Config.trepCount == 0)
        {
            playerInputManager.speed = 0;
            yield return new WaitForSeconds(2);
            playerInputManager.speed = Config.playerSpeed;
            yield break;
        }
    }

    public void PlayerStunTrepidationBar()
    {
        StartCoroutine(StunTime());
    }
}
