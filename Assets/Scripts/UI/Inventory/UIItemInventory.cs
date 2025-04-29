using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIItemInventory : LiemMonoBehaviour
{
    [Header("UI Item Inventory")]

    [SerializeField] protected ItemInventory itemInventory;
    public ItemInventory ItemInventory => itemInventory;

    [SerializeField] protected Text itemName;
    public Text ItemName => itemName;

    [SerializeField] protected Text itemNumber;
    public Text ItemNumber => itemNumber;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadItemName();
        this.LoadItemNumber();
    }

    protected virtual void LoadItemName()
    {
        if (this.itemName != null) return;
        this.itemName = transform.Find("ItemName").GetComponent<Text>();
        Debug.LogWarning(transform.name + ": LoadItemName", gameObject);
    }

    protected virtual void LoadItemNumber()
    {
        if (this.itemNumber != null) return;
        this.itemNumber = transform.Find("ItemNumber").GetComponent<Text>();
        Debug.LogWarning(transform.name + ": LoadItemNumber", gameObject);
    }

    public virtual void ShowItem(ItemInventory item)
    {
        this.itemInventory = item;
        this.itemName.text = this.itemInventory.itemProfile.itemName;
        this.ItemNumber.text = this.itemInventory.itemCount.ToString();
    }
}
