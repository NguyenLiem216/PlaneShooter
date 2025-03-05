using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiemMonoBehavior : MonoBehaviour
{
    protected virtual void Reset()
    {
        this.LoadComponents();
    }
    protected virtual void LoadComponents()
    {
        //For override
    }
    protected virtual void Awake()
    {
        this.LoadComponents();
    }
}
