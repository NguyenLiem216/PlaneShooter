using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public abstract class UIInventoryAbstract : LiemMonoBehaviour
{
    [Header("UI Inventory Abstract")]
    [SerializeField] protected UIInventoryCtrl uIInventoryCtrl;
    public UIInventoryCtrl UIInventoryCtrl => uIInventoryCtrl;


    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadUIInventoryCtrl();
    }

    protected virtual void LoadUIInventoryCtrl()
    {
        if (this.uIInventoryCtrl != null) return;
        this.uIInventoryCtrl = transform.parent.GetComponent<UIInventoryCtrl>();
        Debug.LogWarning(transform.name + ": LoadUIInventoryCtrl", gameObject);
    }
}
