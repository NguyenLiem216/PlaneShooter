using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjMoveForward : ObjMoveMent
{
    [Header("Move Target")]
    [SerializeField] protected Transform moveTarget;
    protected override void FixedUpdate()
    {
        this.GetMousePosition();
        base.FixedUpdate();

    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadMoveTarget();
    }

    protected virtual void LoadMoveTarget()
    {
        if (this.moveTarget != null) return;
        this.moveTarget = transform.Find("MoveTarget");
        Debug.Log(transform.name + ": LoadMoveTarget", gameObject);
    }

    protected virtual void GetMousePosition()
    {
        //singleton pattern
        this.targetPosition = this.moveTarget.position;
        this.targetPosition.z = 0;
    }
}
