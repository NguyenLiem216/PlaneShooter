using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCtrl : LiemMonoBehaviour
{
    [SerializeField] protected ItemDespawn itemDespawn;
    public ItemDespawn ItemDespawn => itemDespawn;

    [SerializeField] protected ItemInventory itemInventory;
    public ItemInventory ItemInventory => itemInventory;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadItemDespawn();
        this.LoadInventory();
    }

    protected override void OnEnable()
    {
        base.OnEnable();
        this.ResetItem();
    }

    protected virtual void ResetItem()
    {
        this.itemInventory.itemCount = 1;
        this.itemInventory.upgradeLevel = 0;

    }

    protected virtual void LoadInventory()
    {
        if (this.itemInventory.itemProfile != null) return;
        ItemCode itemCode = ItemCodeParser.FromString(transform.name);
        ItemProfileSO itemProfile = ItemProfileSO.FindByItemCode(itemCode);
        this.itemInventory.itemProfile = itemProfile;
        this.ResetItem();
        Debug.Log(transform.name + ": LoadInventory", gameObject);
    }

    protected virtual void LoadItemDespawn()
    {
        if (this.itemDespawn != null) return;
        this.itemDespawn = transform.GetComponentInChildren<ItemDespawn>();
        Debug.Log(transform.name + ": LoadItemDespawn", gameObject);

    }

    public virtual void SetItemInventory(ItemInventory itemInventory)
    {
        this.itemInventory = itemInventory.Clone(); 
    }

}
