using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Powerup/Powerupjump")]
public class JumpPowerUp : Powerup
{
    public float boost = 1000;

    public override void UsePowerup(Rigidbody rb)
    {
        rb.AddForce(Vector3.up * boost, ForceMode.VelocityChange);
    }
}
