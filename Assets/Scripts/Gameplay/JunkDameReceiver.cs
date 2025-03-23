using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JunkDameReceiver : DamageReceiver
{
    [Header("Junk")]
    [SerializeField] protected JunkCtrl junkCtrl;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadJunkCtrl();
    }

    protected virtual void LoadJunkCtrl()
    {
        if (this.junkCtrl != null) return;
        this.junkCtrl = transform.parent.GetComponent<JunkCtrl>();
        Debug.Log(transform.name + ": LoadJunkCtrl", gameObject);
    }

    protected override void OnDead()
    {
        this.OnDeadFX();
        if (this.junkCtrl == null)
        {
            Debug.LogError("JunkCtrl is NULL!", gameObject);
            return;
        }

        if (this.junkCtrl.JunkDespawn == null)
        {
            Debug.LogError("JunkDespawn is NULL!", gameObject);
            return;
        }

        this.junkCtrl.JunkDespawn.DespawnObject();
    }

    protected virtual void OnDeadFX()
    {
        string fxName = this.GetOnDeadFXName();
        Transform fxOnDead = FXSpawner.Instance.Spawn(fxName,transform.position,transform.rotation);
        fxOnDead.gameObject.SetActive(true);
    }

    protected virtual string GetOnDeadFXName()
    {
        return FXSpawner.smoke1a;
    }

    public override void Reborn()
    {
        this.hpMax = this.junkCtrl.JunkSO.hpMax;
        base.Reborn(); 
    }
}
