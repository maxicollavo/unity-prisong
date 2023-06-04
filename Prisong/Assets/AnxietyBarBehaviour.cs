using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnxietyBarBehaviour : MonoBehaviour
{
    public PlayerInputManager playerInputManager;
    public GameObject anxBar1;
    public GameObject anxBar2;
    public GameObject anxBar3;
    public GameObject anxBar4;
    public bool fullPicks;

    private void Start()
    {
        fullPicks = false;
    }

    void Update()
    {
        PointAnxBar();
        TokenEarned();
    }

    public void PointAnxBar()
    {
        if (Config.picksCount == 1)
        {
            anxBar1.SetActive(true);
            anxBar2.SetActive(true);
        }
        if (Config.picksCount == 2)
        {
            anxBar3.SetActive(true);
            anxBar4.SetActive(true);
            fullPicks = true;
        }
    }

    public void TokenEarned()
    {
        if (Config.picksCount == 2)
        {
            Config.anxietyBarCount++;
            if (Config.anxietyBarCount >= 1)
            {
            }
        }
    }
}

