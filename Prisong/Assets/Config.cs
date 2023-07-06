using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Config : MonoBehaviour
{
    public PauseManager pauseManager;
    PlayerPickManager playerPickManager;
    public static float sensitivityInGame = .5f;
    public static float sensitivityInPause = 0f;
    public static int playerSpeed = 150;
    public static int playerSpeedCrouched = 50;
    public static int playerRunSpeed = 250;
    public static float maxLives = 4;
    public static int picksCountUsed = 0;
    public static int trepCount = 4;
    public static int diskCount = 0;
    public static int picksRequired = 2;
    public static int pianoCount = 0;
    public static int firstPiano = 1;
    public static int secondPiano = 2;
    public static int escapePicksRequired = 1;
    public static int objectInstantiateCount = 0;
    public static int picksCount = 0;
    public static int buttonCount = 0;
    public static int picksCountInv = 0;
    public static int rockPickCount = 0;
    public static int trepidationBarCount = 0;
    public static float anxietyBarCount = 0f;
    public static float anxietyBarToken = 4f;
    public static float anxietyBarMaxToken = 3f;
    public static float anxietyBarTokensEarned = 0f;
    public static int trepidationBarStunPoints = 1;
    public static int playerSpeedStun = 0;
    public static int GameMenu = 0;
    public static int GameScene = 1;
    public static int DeadMenuScene = 2;
    public static int WinMenuScene = 3;
    public static int CreditsMenuScene = 4;
    public static int LoadingScreenScene = 5;
    public static int TutorialScene = 6;

    public static void Reset()
    {
        picksCountUsed = 0;
        pianoCount = 0;
        objectInstantiateCount = 0;
        picksCount = 0;
        rockPickCount = 0;
        trepidationBarCount = 0;
        anxietyBarCount = 0f;
        anxietyBarTokensEarned = 0f;
        playerSpeedStun = 0;
        picksCountInv = 0;
    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PickMechanic()
    {
        playerPickManager.Picks();
    }

    public void RockPickMechanic()
    {
        //playerPickManager.StoneInteract();
    }

    public void Pause()
    {
        pauseManager.ActivatePause();
    }

    public void Run()
    {
    }
}
