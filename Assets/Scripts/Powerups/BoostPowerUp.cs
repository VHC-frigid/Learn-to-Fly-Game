using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Powerup/Powerupboost")]
public class BoostPowerUp : Powerup
{
    public float boost = 1000;

    public override void UsePowerup(Rigidbody rb)
    {
        rb.AddRelativeForce(Vector3.forward * boost, ForceMode.VelocityChange);
    }

}