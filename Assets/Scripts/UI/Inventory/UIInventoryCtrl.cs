using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class UIInventoryCtrl : LiemMonoBehaviour
{
    [Header("Inv Item Spawner")]

    [SerializeField] protected Transform content;
    public Transform Content => content;

    [SerializeField] protected UIInvItemSpawner uIInvItemSpawner;
    public UIInvItemSpawner UIInvItemSpawner => uIInvItemSpawner;


    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadContent();
        this.LoadUIInvItemSpawner();
    }

    protected virtual void LoadContent()
    {
        if (this.content != null) return;
        this.content = transform.Find("Scroll View").Find("Viewport").Find("Content");
        Debug.LogWarning(transform.name + ": LoadContent", gameObject);
    }
    protected virtual void LoadUIInvItemSpawner()
    {
        if (this.uIInvItemSpawner != null) return;
        this.uIInvItemSpawner = transform.GetComponentInChildren<UIInvItemSpawner>();
        Debug.LogWarning(transform.name + ": LoadUIInvItemSpawner", gameObject);
    }

}
