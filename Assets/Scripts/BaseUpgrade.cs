using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseUpgrade
{
    protected int cost = 1;

    public abstract void ApplyUpgrade();

    public abstract string UpgradeName();

    public bool PayForUpgrade(ref int money)
    {
        if (money >= cost)
        {
            money -= cost;
            return true;
        }
        return false;
    }

}
