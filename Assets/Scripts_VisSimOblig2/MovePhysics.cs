using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePhysics : MonoBehaviour
{
    /*
     * 
     * Identify current triangle (barycentricC)
     * Find normal for triangle
     * find aceleration
     * find velocity, update new velocity
     * find position, update new position
     * 
     */

    [SerializeField] public Barycentric barycentricInformation;
    public Barycentric bary_Access;
    public Vector3 currentAcceleration;
    Vector3 newAcceleration;
    public Vector3 currentVelocity;
    Vector3 newVelocity;
    public Vector3 currentPosition;
    
    private void Start()
    {
        bary_Access = barycentricInformation.GetComponent<Barycentric>();
    }

    private void FixedUpdate()
    {
        Vector3 triangleNormal = Normal();
        Debug.Log("triangleNormal: " +  triangleNormal);

        //newAcceleration = Acceleration(triangleNormal);
        
        newVelocity = Velocity();
        transform.position = transform.position + newVelocity * Time.fixedDeltaTime;

    }

    Vector3 Velocity()
    {
        float gravity = -9.81f;

        //newVelocity = currentVelocity + (new Vector3(-2.0f, 0.0f, -2.0f) * Time.deltaTime * gravity);
        newVelocity = currentVelocity + (currentAcceleration * Time.deltaTime * gravity);

        return newVelocity;
    }


    Vector3 Acceleration(Vector3 triangleNormal)
    {
        float gravity = 9.81f;
        Vector3 gravVec = new Vector3(0.0f, gravity, 0.0f);
        currentAcceleration = gravity * new Vector3(triangleNormal.x * triangleNormal.y, (triangleNormal.y * triangleNormal.y) - 1, triangleNormal.z * triangleNormal.y);
        Debug.Log("numnum: " + currentAcceleration);
        //currentAcceleration = gravVec * 2.0f;
        return currentAcceleration;
    }

    Vector3 Normal()
    {

        Vector3 normal = bary_Access.AB;
        Vector3 normal2 = bary_Access.AC;

        Vector3 n = Vector3.Cross(normal, normal2).normalized;

        return n;
    }
}
