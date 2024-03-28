using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBox : Triggerzone
{
    public Powerup powerup;
    public override void Activate(Collider other)
    {
        powerup.UsePowerup(other.attachedRigidbody);
        Debug.Log("power");
    }
}
