using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialEnd : MonoBehaviour
{
    public static bool tutorialTerminado = false;
    public LifeController LifeController;
    public GameObject paredes;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("ResetTutorial"))
        {
            if (tutorialTerminado == false)
            {
                paredes.SetActive(false);
                LifeController.lives = Config.maxLives;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("ResetTutorial"))
        {
            paredes.SetActive(true);
            tutorialTerminado = true;
        }
    }
}
