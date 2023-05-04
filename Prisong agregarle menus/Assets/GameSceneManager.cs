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
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene(GameMenu);
    }

    public void LoadWinMenu()
    {
        SceneManager.LoadScene(WinMenuScene);
    }

    public void LoadDeadMenu()
    {
        SceneManager.LoadScene(DeadMenuScene);
    }

    public void LoadCreditsMenu()
    {
        SceneManager.LoadScene(CreditsMenuScene);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

}