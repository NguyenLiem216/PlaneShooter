using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AbilitiesCode
{ 
    NoAbility = 0,
    
    Missle = 1,
    Lazer = 2,

}

public class AbilitieParser
{
    public static AbilitiesCode FromString(string itemName)
    {
        try
        {
            return (AbilitiesCode)System.Enum.Parse(typeof(AbilitiesCode), itemName);
        }
        catch (ArgumentException e)
        {
            Debug.LogError(e.ToString());
            return AbilitiesCode.NoAbility;
        }
    }
}
