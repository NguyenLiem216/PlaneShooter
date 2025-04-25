using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class BaseSlider : LiemMonoBehaviour
{
    [Header("Base Slider")]
    [SerializeField] protected Slider slider;

    protected override void Start()
    {
        base.Start();
        this.AddOnClickEvent();
    }

    protected virtual void AddOnClickEvent()
    {
        this.slider.onValueChanged.AddListener(this.OnValueChanged);
    }

    protected abstract void OnValueChanged(float newValue);


    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadSlider();
    }

    protected virtual void LoadSlider()
    {
        if (this.slider != null) return;
        this.slider = GetComponent<Slider>();
        Debug.LogWarning(transform.name + ": LoadSlider", gameObject);
    }
}
