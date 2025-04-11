using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JunkCtrl : LiemMonoBehaviour
{
    [SerializeField] protected Transform model;
    public Transform Model { get => model; }

    [SerializeField] protected JunkDespawn junkDespawn;
    public JunkDespawn JunkDespawn { get => junkDespawn; }

    [SerializeField] protected ShootableObjectSO shootableObject;
    public ShootableObjectSO ShootableObject => shootableObject;


    protected override void Awake()
    {
        if (!gameObject.activeSelf)
        {
            gameObject.SetActive(true);
            Debug.Log(transform.name + " was inactive. Activating now!", gameObject);
        }
    }
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadModel();
        this.LoadJunkDespawn();
        this.LoadJunkSO();
    }

    protected virtual void LoadJunkDespawn()
    {
        if (this.junkDespawn != null) return;

        // Tìm trong chính đối tượng JunkCtrl
        this.junkDespawn = GetComponentInChildren<JunkDespawn>();

        if (this.junkDespawn == null)
        {
            Debug.LogError(transform.name + ": JunkDespawn is NULL! Make sure it exists in the hierarchy.", gameObject);
        }
        else
        {
            Debug.Log(transform.name + ": Successfully loaded JunkDespawn!", gameObject);
        }
    }


    protected virtual void LoadModel()
    {
        if (this.model != null) return;
        this.model = transform.Find("Model");
        Debug.Log(transform.name + ": LoadModel", gameObject);
    }

    protected virtual void LoadJunkSO()
    {
        if (this.shootableObject != null) return;
        string resPath = "ShootableObject/Junk/" + transform.name;
        this.shootableObject = Resources.Load<ShootableObjectSO>(resPath);
        Debug.Log(transform.name + ": LoadJunkSO", gameObject);
    }
}
