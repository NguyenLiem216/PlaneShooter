using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ObjShooting : LiemMonoBehaviour
{
    [SerializeField] protected bool isShooting = false;
    [SerializeField] protected float shootDelay = 1f;
    [SerializeField] protected float shootTimer = 0f;


    void Update()
    {
        this.IsShooting();
    }
    private void FixedUpdate()
    {
        this.Shooting();
    }
    protected virtual void Shooting()
    {
        if (!this.isShooting) return;

        this.shootTimer += Time.fixedDeltaTime;
        if (this.shootTimer < this.shootDelay) return;
        this.shootTimer = 0;

        Vector3 spawnPos = transform.position;
        Quaternion rotation = transform.parent.rotation;

        Transform newbullet = BulletSpawner.Instance.Spawn(BulletSpawner.bulletOne,spawnPos,rotation);
        if (newbullet == null) return;


        newbullet.gameObject.SetActive(true);
        BulletCtrl bulletCtrl = newbullet.GetComponent<BulletCtrl>();
        bulletCtrl.SetShooter(transform.parent);       
    }

    protected abstract bool IsShooting();
}
