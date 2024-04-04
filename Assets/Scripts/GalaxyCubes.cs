using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GalaxyCubes : MonoBehaviour
{

    public GameObject cubePreFab;
    public int numberOfCubes = 1000;
    public float spawnRadius = 50f;
    public float gravitationalForce = 10f;
    public float initialVelocity = 10f;

    public List<Rigidbody> cubeList;
    
    // Start is called before the first frame update
    private void Start()
    {
        for (int i = 0; i < numberOfCubes; i++)
        {
            Vector3 randomPosition = transform.position + Random.insideUnitSphere * spawnRadius;
            GameObject cube = Instantiate(cubePreFab, randomPosition,Quaternion.identity);

            Rigidbody cubeRB = cube.GetComponent<Rigidbody>();
            cubeRB.mass = Random.Range(0.1f, 0.5f);

            Vector3 directionToCenter = (transform.position - cube.transform.position).normalized;
            Vector3 velocityDirection = Vector3.Cross(directionToCenter, Vector3.up).normalized;

            cubeRB.velocity = velocityDirection * initialVelocity;

            cubeList.Add(cubeRB);
        }
    }
    

    // Update is called once per frame
    private void FixedUpdate()
    {
        foreach (Rigidbody cube in cubeList)
        {
            Vector3 directionToCenter = (transform.position - cube.transform.position).normalized;
            cube.AddForce(directionToCenter * gravitationalForce);
        }
    }
}
