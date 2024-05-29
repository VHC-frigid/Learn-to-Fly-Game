using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedUpgrade : BaseUpgrade
{

    protected PlaneController planeController;
    private float upgradeSpeed;
    public SpeedUpgrade(PlaneController plane)
    {
        planeController = plane;
    }

    public SpeedUpgrade(PlaneController plane, int upgradeCost)
    {
        planeController = plane;
        cost = upgradeCost;
    }

    public SpeedUpgrade(PlaneController plane, int upgradeCost, float newSpeed)
    {
        planeController = plane;
        cost = upgradeCost;
        upgradeSpeed = newSpeed;
    }

    public override void ApplyUpgrade()
    {
        planeController.speed += upgradeSpeed;
    }

    public override string UpgradeName()
    {
        return "Speed " + upgradeSpeed;
    }

}
