using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Config : MonoBehaviour
{
    public PauseManager pauseManager;
    PlayerPickManager playerPickManager;
    PlayerInputManager playerInputManager;
    public static float sensitivityInGame = .5f;
    public static float sensitivityInPause = 0f;
    public static float maxLives = 4;
    public static int picksRequired = 2;
    public static int escapePicksRequired = 1;
    public static int objectInstantiateCount = 0;
    public static int picksCount = 0;
    public static int partiturePickCount = 0;
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

    // Start is called before the first frame update
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

    public void PartiturePickMechanic()
    {
        playerPickManager.PartiturePick();
    }

    public void Pause()
    {
        pauseManager.ActivatePause();
    }

    public void Run()
    {
        playerInputManager.speed += playerInputManager.speedRun; //Sumarle al speed del Move playerInputManager.speedRun;
    }
}
