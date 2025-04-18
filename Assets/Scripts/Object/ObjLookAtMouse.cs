using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjLookAtMouse : ObjLookAtTarget
{
    protected override void FixedUpdate()
    {
        this.GetMousePosition();
        base.FixedUpdate();

    }
    protected virtual void GetMousePosition()
    {
        //singleton pattern
        this.targetPosition = InputManager.Instance.MouseWorldPosition;
        this.targetPosition.z = 0;
    }
}
