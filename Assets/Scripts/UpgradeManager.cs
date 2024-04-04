using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeManager : MonoBehaviour
{
    private int money = 0;

    private PlaneController planeController;
    private BaseUpgrade upgrade;

    
    void Start()
    {
        planeController = FindObjectOfType<PlaneController>();
        upgrade = new SpeedUpgrade(planeController);
    }
    
    public void PurchaseUpgrade()
    {
 
    }
}
