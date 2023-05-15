using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSceneManager : MonoBehaviour
{
    public int GameMenu;
    public int GameScene;
    public int WinMenuScene;
    public int DeadMenuScene;
    public int CreditsMenuScene;

    // Start is called before the first frame update
    void Start()
    {
        GameMenu = Config.GameMenu;
        GameScene = Config.GameScene;
        DeadMenuScene = Config.DeadMenuScene;
        WinMenuScene = Config.WinMenuScene;
        CreditsMenuScene = Config.CreditsMenuScene;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void LoadGame()
    {
        SceneManager.LoadScene(GameScene);
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene(GameMenu);
        Cursor.lockState = CursorLockMode.None;
    }

    public void LoadWinMenu()
    {
        SceneManager.LoadScene(WinMenuScene);
        Cursor.lockState = CursorLockMode.None;
    }

    public void LoadDeadMenu()
    {
        SceneManager.LoadScene(DeadMenuScene);
        Cursor.lockState = CursorLockMode.None;
    }

    public void LoadCreditsMenu()
    {
        SceneManager.LoadScene(CreditsMenuScene);
        Cursor.lockState = CursorLockMode.None;
    }

    public void ExitGame()
        {
            Application.Quit();
        }

}