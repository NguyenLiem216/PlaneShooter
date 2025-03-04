using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    private static InputManager instance;
    public static InputManager Instance { get => instance; }

    [SerializeField] private Vector3 mouseWorldPosition;
    public Vector3 MouseWorldPosition { get => mouseWorldPosition; }

    [SerializeField] private float onFiring;
    public float OnFiring { get => onFiring; }


    private void Awake()
    {
        if (InputManager.instance != null) Debug.LogError("Only 1 InputManager allow to exist");
        InputManager.instance = this;
    }
    void Update()
    {
        this.GetMouseDown();
    }   

    void FixedUpdate()
    {
        this.GetMousePos();
    }
    protected virtual void GetMouseDown()
    {
        this.onFiring = Input.GetAxis("Fire1");
    }
    protected virtual void GetMousePos()
    {
        this.mouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
}
