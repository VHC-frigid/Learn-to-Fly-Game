using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class BaseUpgrade
{
    public Button UpgradeButton;

    protected int cost = 1;

    public abstract void ApplyUpgrade();

    public abstract string UpgradeName();

    public void SetButton(Button btn)
    {
        UpgradeButton = btn;
    }

    public void CheckButtonCost(int money)
    {
        if (UpgradeButton == null)
        {
            return;
        }
        
        if (money < cost)
        {
            UpgradeButton.interactable = false;
        }
        else
        {
            UpgradeButton.interactable = true;
        }
    }

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
