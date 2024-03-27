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
    }

    // -MAFS-  
    // Abs           - makes number positive
    // Clamp         - Ensures a value is between two other values
    // Clamp01       - Clamps between 0 and 1
    // Lerp          - Linear Interpolation
    //                      5  10
    //                       0.1
    //                        5.5
    // Sin/Cos       - waves
    // Dot product   - How much do vectors point in the same direction
    //               - from 1 to -1
    // Cross product - 

    // Update is called once per frame
    void Update()
    {
        //Input
        float input = Input.GetAxis("Vertical");

        rb.AddTorque(transform.right * rotationSpeed * input * Time.deltaTime);

        //Move forward
        rb.AddForce(transform.forward * speed * Time.deltaTime, ForceMode.Acceleration);

        //Lift
        float dot = Vector3.Dot(transform.forward, Vector3.up);
        
        dot = 1 - Mathf.Abs(dot);
        lift = lift * dot;
        rb.AddForce(transform.up * lift * Time.deltaTime, ForceMode.Acceleration);

        //Gravity
        rb.AddForce(Vector3.down * gravity * Time.deltaTime, ForceMode.Acceleration);
    }
}
