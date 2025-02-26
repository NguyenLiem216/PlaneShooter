using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMoveMent : MonoBehaviour
{
    [SerializeField] protected Vector3 targetPosition;
    [SerializeField] protected float speed = 0.1f;

    void FixedUpdate()
    {
        this.GetTargetPosition();
        this.LookAtTarget();
        this.Moving();
    }

    protected virtual void LookAtTarget()
    {
        Vector3 diff = this.targetPosition - transform.parent.position; // Tính vector hướng đến mục tiêu
        diff.Normalize(); // Chuẩn hóa vector để đảm bảo độ dài là 1

        float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg; // Tính góc xoay theo trục Z (độ)

        transform.parent.rotation = Quaternion.Euler(0f, 0f, rot_z); // Xoay đối tượng
    }


    protected virtual void GetTargetPosition()
    {
        //singleton pattern
        this.targetPosition = InputManager.Instance.MouseWorldPosition;
        this.targetPosition.z = 0;
    }

    protected virtual void Moving()
    {
        Vector3 newPos = Vector3.Lerp(transform.parent.position, targetPosition, this.speed);
        transform.parent.position = newPos;
    }
}
