using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public abstract class UIHotKeyAbstract : LiemMonoBehaviour
{
    [SerializeField] protected UIHotKeyCtrl uIHotKeyCtrl;


    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadUIHotKeyCtrl();
    }

    protected virtual void LoadUIHotKeyCtrl()
    {
        if (this.uIHotKeyCtrl != null) return;
        this.uIHotKeyCtrl = transform.parent.GetComponent<UIHotKeyCtrl>();
        Debug.LogWarning(transform.name + ": LoadUIHotKeyCtrl", gameObject);
    }
}
