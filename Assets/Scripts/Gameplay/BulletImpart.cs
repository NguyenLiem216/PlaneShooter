using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
[RequireComponent(typeof(Rigidbody))]
public class BulletImpart : BulletAbstract
{
    [Header("Bullet Impart")]
    [SerializeField] protected SphereCollider sphereCollider;
    [SerializeField] protected Rigidbody _rigidbody;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadCollider();
        this.LoadRigidbody();
    }

    protected virtual void LoadRigidbody()
    {
        if (this._rigidbody != null) return;
        this._rigidbody = GetComponent<Rigidbody>();
        this._rigidbody.isKinematic = true;
        Debug.Log(transform.name + ": LoadRigidbody", gameObject);
    }

    protected virtual void LoadCollider()
    {
        if (this.sphereCollider != null) return;
        this.sphereCollider = GetComponent<SphereCollider>();
        this.sphereCollider.isTrigger = true;
        this.sphereCollider.radius = 0.05f;
        Debug.Log(transform.name + ": LoadCollider", gameObject);
    }
    protected virtual void OnTriggerEnter(Collider other)
    {       
        if (other.transform.parent == bulletCtrl.Shooter) return;

        this.bulletCtrl.DamageSender.Send(other.transform);
        //this.CreateFXImpact(other);
    }

    //protected virtual void CreateFXImpact(Collider other)
    //{
    //    string fxName = this.GetImpactFX();


    //    //Vector3 hitPos = transform.position;
    //    //Quaternion hitRot = transform.rotation;
    //    //Quaternion rotationEffect = Quaternion.Euler(0, 0, 90);
    //    //Transform fxImpact = FXSpawner.Instance.Spawn(fxName, hitPos, hitRot * rotationEffect);
    //    //fxImpact.gameObject.SetActive(true);

    //    Vector3 hitPos = transform.position;
    //    Quaternion hitRot = transform.rotation;
    //    Transform fxImpact = FXSpawner.Instance.Spawn(fxName, hitPos, hitRot);
    //    fxImpact.gameObject.SetActive(true);



    //}

    //protected virtual string GetImpactFX()
    //{
    //    return FXSpawner.impact1;
    //}
}
