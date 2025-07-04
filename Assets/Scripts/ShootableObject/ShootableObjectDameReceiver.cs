using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootableObjectDameReceiver : DamageReceiver
{
    [Header("Shootable Object")]
    [SerializeField] protected ShootableObjectCtrl shootableObjectCtrl;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadCtrl();
    }

    protected virtual void LoadCtrl()
    {
        if (this.shootableObjectCtrl != null) return;
        this.shootableObjectCtrl = transform.parent.GetComponent<ShootableObjectCtrl>();
        Debug.Log(transform.name + ": LoadCtrl", gameObject);
    }

    protected override void OnDead()
    {
        this.OnDeadFX();
        this.OnDeadDrop();
        if (this.shootableObjectCtrl == null)
        {
            Debug.LogError("shootableObjectCtrl is NULL!", gameObject);
            return;
        }

        if (this.shootableObjectCtrl.Despawn == null)
        {
            Debug.LogError("Despawn is NULL!", gameObject);
            return;
        }

        this.shootableObjectCtrl.Despawn.DespawnObject();


    }

    protected virtual void OnDeadDrop()
    {
        Vector3 dropPos = transform.position;
        Quaternion dropRot = transform.rotation;
        ItemDropSpawner.Instance.Drop(this.shootableObjectCtrl.ShootableObject.dropList, dropPos, dropRot);
    }


    protected virtual void OnDeadFX()
    {
        string fxName = this.GetOnDeadFXName();
        Transform fxOnDead = FXSpawner.Instance.Spawn(fxName, transform.position, transform.rotation);
        fxOnDead.gameObject.SetActive(true);
    }

    protected virtual string GetOnDeadFXName()
    {
        return FXSpawner.smoke1a;
    }

    public override void Reborn()
    {
        this.hpMax = this.shootableObjectCtrl.ShootableObject.hpMax;
        base.Reborn();
    }
}
