using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JunkFly : ParentFly
{
    [SerializeField] protected float minCamPos = -16f;
    [SerializeField] protected float maxCamPos = 16f;
    protected override void ResetValue()
    {
        base.ResetValue();
        this.moveSpeed = 0.5f;
    }

    protected override void OnEnable()
    {
        base.OnEnable();
        this.GetFlyDirection();
    }

    protected virtual void GetFlyDirection()
    {
        Vector3 camPos = this.GetCamPos();
        Vector3 objPos = transform.parent.position;

        camPos.x += UnityEngine.Random.Range(this.minCamPos, this.maxCamPos);
        camPos.z += UnityEngine.Random.Range(this.minCamPos, this.maxCamPos);

        Vector3 diff = camPos - objPos;
        diff.Normalize(); // Chuẩn hóa vector để đảm bảo độ dài là 1

        float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg; // Tính góc xoay theo trục Z (độ)

        transform.parent.rotation = Quaternion.Euler(0f, 0f, rot_z); // Xoay đối tượng

        Debug.DrawLine(objPos, objPos + diff * 7, Color.red, Mathf.Infinity);

    }

    protected virtual Vector3 GetCamPos()
    {
        if (GameCtrl.Instance == null) return Vector3.zero;

        Vector3 camPos = GameCtrl.Instance.MainCamera.transform.position;
        return camPos;
    }
}
