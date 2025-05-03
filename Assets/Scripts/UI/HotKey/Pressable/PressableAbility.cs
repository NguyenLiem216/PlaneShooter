using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressableAbility : Pressable
{
    [SerializeField] protected AbilitiesCode abilitiesCode;
    public override void Pressed()
    {
        PlayerCtrl.Instance.PlayerAbility.Active(abilitiesCode);

    }
}
