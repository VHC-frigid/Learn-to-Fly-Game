using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneController : MonoBehaviour
{
    Rigidbody rb;

    public float lift;
    public float speed;
    public float gravity = 9.81f;
    public float rotationSpeed;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        rb.AddForce(transform.forward * speed, ForceMode.Acceleration);
    }

    // -MAFS-  
    // Abs           - makes number positive
    // Clamp         - Ensures a value is between two other values
    // Clamp01       - Clamps between 0 and 1
    
    // if N is between 0 - 1
    // 1 - N 
    // Invert a number 
    // 0.3 = 0.7
    // 0.1 = 0.9
    
    // Lerp          - Linear Interpolation
    //                      5  10
    //                       0.1
    //                        5.5
    // Sin/Cos       - waves
    // Dot product   - How much do vectors point in the same direction
    //               - from 1 to -1
    // Cross product - 

    // Update is called once per frame
    void FixedUpdate()
    {
        //Input
        float input = Input.GetAxisRaw("Vertical");
        rb.AddTorque(transform.right * rotationSpeed * input);

        // Lift        
        // float dot = Vector3.Dot(transform.forward, Vector3.up);       
        // dot = 1 - Mathf.Abs(dot);
        // float liftResult = lift * dot;
        rb.AddForce(transform.up * lift * SpeedMultiplier(), ForceMode.Acceleration);

        //Gravity
        rb.AddForce(Vector3.down * gravity, ForceMode.Acceleration);

        //Drag
        rb.AddForce(-transform.forward * 1f * SpeedMultiplier(), ForceMode.Acceleration);

        //Turn Drag
        float result = 1 - Vector3.Dot(rb.velocity.normalized, transform.forward);
        rb.AddForce(-transform.forward * result, ForceMode.Acceleration);

        //Velocity direction slowly turn forward
        rb.velocity = Vector3.Lerp(rb.velocity.normalized, transform.forward, Time.deltaTime).normalized * rb.velocity.magnitude * 1f;
    }

    float SpeedMultiplier()
    {
        return Mathf.InverseLerp(0, 10, rb.velocity.magnitude);
    }

    private void OnTriggerEnter(Collider other)
    {
        IScoreable scoreable = other.GetComponent<IScoreable>();
        if (scoreable != null)
        {
            Debug.Log(scoreable.OnScore());
        }
    }

    public void OnCollisionEnter(Collision other)
    {
        IScoreable scoreable = other.gameObject.GetComponent<IScoreable>();
        if (scoreable != null)
        {
            Debug.Log(scoreable.OnScore());
        }
    }

}
