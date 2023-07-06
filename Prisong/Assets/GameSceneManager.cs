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
    public int TutorialScene;

    void Start()
    {
        GameMenu = Config.GameMenu;
        GameScene = Config.GameScene;
        DeadMenuScene = Config.DeadMenuScene;
        WinMenuScene = Config.WinMenuScene;
        CreditsMenuScene = Config.CreditsMenuScene;
        TutorialScene = Config.TutorialScene;
    }

    public void LoadTutorial()
    {
        Config.tutorial = true;
        LoadGame();
        Cursor.lockState = CursorLockMode.None;
    }

    public void LoadGame()
    {
        SceneManager.LoadScene(GameScene);
        Cursor.lockState = CursorLockMode.Locked;
        Config.Reset();
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