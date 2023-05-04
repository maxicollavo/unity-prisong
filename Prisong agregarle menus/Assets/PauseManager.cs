using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManager : MonoBehaviour
{
    static bool isPaused;
    public GameObject pauseMenu;
    public MouseLookAround mouseLookAround;

    public void ActivatePause()
    {
        if (isPaused)
        {
            isPaused = false;
            Time.timeScale = 1f;
            pauseMenu.SetActive(false);
            mouseLookAround.sensitivity = Config.sensitivityInGame;
        }
        else
        {
            isPaused = true;
            Time.timeScale = 0f;
            pauseMenu.SetActive(true);
            mouseLookAround.sensitivity = Config.sensitivityInPause;
        }
    }
}
