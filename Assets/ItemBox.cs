using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBox : Triggerzone
{
    public Powerup powerup;
    public override void Activate(Collider other)
    {
        Debug.Log("Item picked up");
    }
}