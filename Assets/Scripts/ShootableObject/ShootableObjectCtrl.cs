using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ShootableObjectCtrl : LiemMonoBehaviour
{
    [SerializeField] protected Transform model;
    public Transform Model => model;

    [SerializeField] protected Despawn despawn;
    public Despawn Despawn => despawn;

    [SerializeField] protected ShootableObjectSO shootableObject;
    public ShootableObjectSO ShootableObject => shootableObject;

    [SerializeField] protected ObjShooting objShooting;
    public ObjShooting ObjShooting => objShooting;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadModel();
        this.LoadDespawn();
        this.LoadSO();
        this.LoadObjShooting();
    }

    protected virtual void LoadObjShooting()
    {
        if (this.objShooting != null) return;
        this.objShooting = GetComponentInChildren<ObjShooting>();
        Debug.Log(transform.name + ": LoadObjShooting", gameObject);
    }

    protected virtual void LoadDespawn()
    {
        if (this.despawn != null) return;

        // Tìm trong chính đối tượng JunkCtrl
        this.despawn = GetComponentInChildren<Despawn>();

        if (this.despawn == null)
        {
            Debug.LogError(transform.name + ": Despawn is NULL! Make sure it exists in the hierarchy.", gameObject);
        }
        else
        {
            Debug.Log(transform.name + ": Successfully loaded Despawn!", gameObject);
        }
    }


    protected virtual void LoadModel()
    {
        if (this.model != null) return;
        this.model = transform.Find("Model");
        Debug.Log(transform.name + ": LoadModel", gameObject);
    }

    protected virtual void LoadSO()
    {
        if (this.shootableObject != null) return;
        string resPath = "ShootableObject/" + this.GetObjectTypeString() + "/" + transform.name;
        this.shootableObject = Resources.Load<ShootableObjectSO>(resPath);
        Debug.Log(transform.name + ": LoadJunkSO", gameObject);
    }

    protected abstract string GetObjectTypeString();
}
