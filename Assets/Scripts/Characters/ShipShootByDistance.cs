using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipShootByDistance : ShipShooting
{
    protected override bool IsShooting()
    {
        this.isShooting = InputManager.Instance.OnFiring == 1;
        return isShooting;
    }
}
