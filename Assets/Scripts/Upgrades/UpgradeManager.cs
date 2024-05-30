using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeManager : MonoBehaviour
{
    //Field
    [SerializeField] private int money = 0;
    [SerializeField] private Button buttonPrefab;
    [SerializeField] private Transform buttonParent;

    private PlaneController planeController;
    private List<BaseUpgrade> upgrades;

    //property
    public int Money
    {
        get
        {
            return money;
        }
        set
        {
            money = value;
            foreach (var upgrade in upgrades)
            {
                upgrade.CheckButtonCost(value);
            }
        }
    }


    
    void Start()
    {
        planeController = FindObjectOfType<PlaneController>();

        upgrades = new List<BaseUpgrade>();
        upgrades.Add(new SpeedUpgrade(planeController, 5, 500f));
        upgrades.Add(new SpeedUpgrade(planeController, 8, 1000f));
        upgrades.Add(new SpeedUpgrade(planeController, 12, 1500f));
        upgrades.Add(new SpeedUpgrade(planeController, 15, 2000f));
        upgrades.Add(new GravityUprade(planeController, 5, 0.5f));
        upgrades.Add(new GravityUprade(planeController, 8, 1f));
        upgrades.Add(new GravityUprade(planeController, 12, 1.5f));
        upgrades.Add(new GravityUprade(planeController, 15, 2f));

        int x = 0;
        foreach(var upgrade in upgrades)
        {
            Button go = Instantiate(buttonPrefab, buttonParent);
            TMP_Text text = go.GetComponentInChildren<TMP_Text>();
            text.text = upgrade.UpgradeName();
            upgrade.SetButton(go);
            upgrade.CheckButtonCost(Money);

            int y = x;
            go.onClick.AddListener(() => PurchaseUpgrade(y));
            x++;
        }
    }
    
    public void PurchaseUpgrade(int index)
    {
        int tempMoney = Money;
        if (upgrades[index].PayForUpgrade(ref tempMoney))
        {
            upgrades[index].ApplyUpgrade();
        }
        Money = tempMoney;
    }

    public void EarnMoney(int amount)
    {
        Money += amount;
    }
}
