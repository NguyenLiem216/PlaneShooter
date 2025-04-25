using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderHP : BaseSlider
{
    //[Header("SliderHP")]
    [SerializeField] protected float maxHP = 100;
    [SerializeField] protected float currentHP = 70;

    protected virtual void FixedUpdate()
    {
        this.ShowingHP();
    }

    protected virtual void ShowingHP()
    {
        float hpPercent = this.currentHP / this.maxHP;
        this.slider.value = hpPercent;
    }

    protected override void OnValueChanged(float newValue)
    {
        //Debug.Log("newValue: " + newValue);
    }

    public virtual void SetMaxHP(float maxHP)
    {
        this.maxHP = maxHP;
    }
    
    public virtual void SetCurrentHP(float currentHP)
    {
        this.currentHP = currentHP;
    }



}
