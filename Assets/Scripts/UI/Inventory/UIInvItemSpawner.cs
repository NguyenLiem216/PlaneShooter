using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIInvItemSpawner : Spawner
{

    private static UIInvItemSpawner instance;
    public static UIInvItemSpawner Instance => instance;
    public static string normalItem = "UIInvItem";

    [Header("Inv Item Spawner")]
    [SerializeField] protected UIInventoryCtrl uIInventoryCtrl;
    public UIInventoryCtrl UIInventoryCtrl => uIInventoryCtrl;

    protected override void Awake()
    {
        base.Awake();
        if (UIInvItemSpawner.instance != null) Debug.LogError("Only 1 UIInvItemSpawner allow to exist");
        UIInvItemSpawner.instance = this;
    }
    protected override void LoadHolder()
    {
        this.LoadUIInventoryCtrl();


        if (this.holder != null) return;
        this.holder = this.uIInventoryCtrl.Content;
        Debug.LogWarning(transform.name + ": LoadHodler", gameObject);
    }
    protected virtual void LoadUIInventoryCtrl()
    {
        if (this.uIInventoryCtrl != null) return;
        this.uIInventoryCtrl = transform.parent.GetComponent<UIInventoryCtrl>();
        Debug.LogWarning(transform.name + ": LoadUIInventoryCtrl", gameObject);
    }

    public virtual void ClearItems()
    {
        foreach(Transform item in this.holder)
        {
            this.Despawn(item);
        }
    }
}
