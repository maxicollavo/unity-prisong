using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrepidationBarBehaviour : MonoBehaviour
{
    public PlayerInputManager playerInputManager;
    public GameObject trepBar1;
    public GameObject trepBar2;
    public GameObject trepBar3;
    public GameObject trepBar4;

    // Update is called once per frame
    void Update()
    {
        PlayerStunTrepidationBar();
    }

    public void TrepBarHit()
    {
        Config.trepCount--;
        Debug.Log(Config.trepCount);
    }

    public IEnumerator StunTime()
    {
        if (Config.trepCount == 0)
        {
            playerInputManager.speed = 0;
            yield return new WaitForSeconds(2);
            playerInputManager.speed = Config.playerSpeed;
        }
    }

    public void PlayerStunTrepidationBar()
    {
        StartCoroutine(StunTime());
    }
}
