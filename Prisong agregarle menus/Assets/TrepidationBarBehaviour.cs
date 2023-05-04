using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrepidationBarBehaviour : MonoBehaviour
{
    Config config;
    PlayerInputManager playerInputManager;
    EnemyMovement enemyMovement;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        playerTrepidationBarIncrement();
        playerStunTrepidationBar();
    }

    void playerStunTrepidationBar()
    {
        if (Config.trepidationBarCount >= Config.trepidationBarStunPoints)
        {
            playerInputManager.speed = Config.playerSpeedStun;
        }
    }

    void playerTrepidationBarIncrement()
    {
        if (enemyMovement.stayAlert == true)
        {
            Config.trepidationBarCount++;
        }
    }
}
