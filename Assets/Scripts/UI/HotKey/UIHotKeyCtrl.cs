using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class UIHotKeyCtrl : LiemMonoBehaviour
{
    private static UIHotKeyCtrl instance;
    public static UIHotKeyCtrl Instance => instance;

    public List<UIItemSlot> itemSlots;

    protected override void Awake()
    {
        if (UIHotKeyCtrl.instance != null) Debug.LogError("Only 1 UIHotKeyCtrl allow to exist");
        UIHotKeyCtrl.instance = this;
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadItemSlots();
    }

    protected virtual void LoadItemSlots()
    {
        if (this.itemSlots.Count > 0) return;
        UIItemSlot[] arraySlots = GetComponentsInChildren<UIItemSlot>();

        this.itemSlots.AddRange(arraySlots);

        Debug.Log(transform.name + ": LoadItemSlots", gameObject);
    }
}
