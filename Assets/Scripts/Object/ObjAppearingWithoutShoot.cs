using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjAppearingWithoutShoot : ShootableObjectAbstract, IObjAppearObserver
{
    [Header("Without Shoot")]
    [SerializeField] protected ObjAppearing objAppearing;
    public ObjAppearing ObjAppearing => objAppearing;

    protected override void OnEnable()
    {
        base.OnEnable();
        this.RegisterAppearEvent();
    }

    protected virtual void RegisterAppearEvent()
    {
        this.objAppearing.AddObserver(this);
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadObjAppearing();
    }

    protected virtual void LoadObjAppearing()
    {
        if (this.objAppearing != null) return;
        this.objAppearing = GetComponent<ObjAppearing>();
        Debug.Log(transform.name + ": LoadObjAppearing", gameObject);
    }

    public void OnAppearStart()
    {
        this.shootableObjectCtrl.ObjShooting.gameObject.SetActive(false);
        this.shootableObjectCtrl.ObjLookAtTarget.gameObject.SetActive(false);
    }

    public void OnAppearFinish()
    {
        this.shootableObjectCtrl.ObjShooting.gameObject.SetActive(true);
        this.shootableObjectCtrl.ObjLookAtTarget.gameObject.SetActive(true);

        this.shootableObjectCtrl.Spawner.Hold(transform.parent);
    }
}
