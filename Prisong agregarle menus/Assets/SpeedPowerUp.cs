using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedPowerUp : PowerUp
{
    public override void Active(PlayerInputManager playerInputManager)
    {
        playerInputManager.speed += 100;
    }
}
