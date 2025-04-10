using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapLevel : LevelByDistance
{
    //[Header("Map")]

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
        this.MapSetTarget();
    }

    protected virtual void MapSetTarget()
    {
        ShipCtrl currentShip = PlayerCtrl.Instance.CurrentShip;
        this.SetTarget(currentShip.transform);
    }
}
