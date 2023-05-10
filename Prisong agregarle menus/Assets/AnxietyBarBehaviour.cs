using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnxietyBarBehaviour : MonoBehaviour
{


    // Update is called once per frame
    void Update()
    {
        PointAnxBar();
    }

    public void PointAnxBar()
    {
        for (int i = 1; i == Config.picksCount; i++)
        {
            TokenEarned();
        }
    }

    public void TokenEarned()
    {
        Config.anxietyBarCount++;
        if (Config.anxietyBarCount >= Config.anxietyBarToken)
        {
            if (Config.anxietyBarTokensEarned <= Config.anxietyBarMaxToken)
            {
                Config.anxietyBarTokensEarned++;
            }
        }
    }
}

