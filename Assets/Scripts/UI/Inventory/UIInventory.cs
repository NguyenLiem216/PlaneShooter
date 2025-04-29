using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIInventory : UIInventoryAbstract
{
    [Header("UI Inventory")]

    private static UIInventory instance;
    public static UIInventory Instance => instance;
    protected bool isOpen = true;

    protected override void Awake()
    {
        base.Awake();
        if (UIInventory.instance != null) Debug.LogError("Only 1 UIInventory allow to exist");
        UIInventory.instance = this;
    }

    
    protected override void Start()
    {
        base.Start();
        //this.Close();

        InvokeRepeating(nameof(this.ShowItem),1,1);
    }
    protected virtual void FixedUpdate()
    {
        //this.ShowItem();
    }

    protected virtual void ShowItem()
    {
        if (!this.isOpen) return;

        this.ClearItems();

        float itemCount = PlayerCtrl.Instance.CurrentShip.Inventory.Items.Count;
        for (int i = 1; i <= itemCount; i++)
        {
            this.SpawnTest(i);
        }
        Debug.Log("itemCount: " + itemCount);

    }

    protected virtual void ClearItems()
    {
        this.uIInventoryCtrl.UIInvItemSpawner.ClearItems();
    }

    protected virtual void SpawnTest(int i)
    {
        Transform uiItem = this.uIInventoryCtrl.UIInvItemSpawner.Spawn(UIInvItemSpawner.normalItem, Vector3.zero, Quaternion.identity);
        uiItem.transform.localScale = new Vector3(1, 1, 1);
        uiItem.gameObject.SetActive(true);
    }
    public virtual void Toggle()
    {
        this.isOpen = !this.isOpen;
        if (this.isOpen) this.Open();
        else this.Close();
    }

    public virtual void Open()
    {
        this.uIInventoryCtrl.gameObject.SetActive(true);
        this.isOpen = true;
    }  
    public virtual void Close()
    {
        this.uIInventoryCtrl.gameObject.SetActive(false);
        this.isOpen = false;
    }  
}
