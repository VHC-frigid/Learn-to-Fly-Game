using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBox : Triggerzone, IScoreable
{
    public Powerup powerup;

    public float OnScore()
    {
        GetComponent<AudioSource>().Play(); 
        return 10f;
    }
    public override void Activate(Collider other)
    {
        powerup.UsePowerup(other.attachedRigidbody);
        Debug.Log("power");
    }
}
