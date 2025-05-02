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
    [SerializeField] protected UIInventorySort uIInventorySort = UIInventorySort.ByName;

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

        InvokeRepeating(nameof(this.ShowItems),1,1);
    }
    protected virtual void FixedUpdate()
    {
        //this.ShowItem();
    }

    protected virtual void ShowItems()
    {
        if (!this.isOpen) return;

        this.ClearItems();


        List<ItemInventory> items = PlayerCtrl.Instance.CurrentShip.Inventory.Items;
        UIInvItemSpawner spawner = this.uIInventoryCtrl.UIInvItemSpawner;
        foreach (ItemInventory item in items)
        {
            spawner.SpawnItem(item);
        }

        this.SortItems();
    }

    protected virtual void SortItems()
    {
        if (this.uIInventorySort == UIInventorySort.NoSort) return;

        Debug.Log("== InventorySort.ByName ====");

        int itemCount = this.uIInventoryCtrl.Content.childCount;
        Transform currentItem, nextItem;
        UIItemInventory currentUIItem, nextUIItem;
        ItemProfileSO currentProfile, nextProfile;
        string currentName, nextName;
        int currentCount, nextCount;

        bool isSorting = false;
        for (int i = 0; i < itemCount - 1; i++)
        {
            currentItem = this.uIInventoryCtrl.Content.GetChild(i);
            nextItem = this.uIInventoryCtrl.Content.GetChild(i + 1);

            currentUIItem = currentItem.GetComponent<UIItemInventory>();
            nextUIItem = nextItem.GetComponent<UIItemInventory>();

            currentProfile = currentUIItem.ItemInventory.itemProfile;
            nextProfile = nextUIItem.ItemInventory.itemProfile;

            bool isSwap = false;

            switch (this.uIInventorySort)
            {
                case UIInventorySort.ByName:
                    currentName = currentProfile.itemName;
                    nextName = nextProfile.itemName;
                    isSwap = string.Compare(currentName, nextName) == -1;
                    break;
                case UIInventorySort.ByCount:
                    currentCount = currentUIItem.ItemInventory.itemCount;
                    nextCount = nextUIItem.ItemInventory.itemCount;
                    isSwap = currentCount > nextCount;
                    break;
            }

            if (isSwap)
            {
                this.SwapItems(currentItem, nextItem);
                isSorting = true;
            }
        }

        if (isSorting) this.SortItems();
    }

    protected virtual void SwapItems(Transform currentItem, Transform nextItem)
    {
        int currentIndex = currentItem.GetSiblingIndex();
        int nextIndex = nextItem.GetSiblingIndex();

        currentItem.SetSiblingIndex(nextIndex);
        nextItem.SetSiblingIndex(currentIndex);
    }


    protected virtual void ClearItems()
    {
        this.uIInventoryCtrl.UIInvItemSpawner.ClearItems();
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
