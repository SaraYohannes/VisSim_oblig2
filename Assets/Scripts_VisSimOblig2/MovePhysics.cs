using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePhysics : MonoBehaviour
{
    /*
     * 
     * Identify current triangle (barycentricC)
     * Find normal for triangle
     * find aceleration as dif in v/ in dif in t
     * find velocity, update new velocity as dif in pos/ in dif in t
     * find position, update new position
     * 
     */

    [SerializeField] public Barycentric barycentricInformation;
    [SerializeField] public float mass;
    [SerializeField] public MeshMakerFromFile meshInfo;
    public Vector3[] vertex;
    public float gravity = 9.81f;

    public Vector3 acceleration;
    public Vector3 currentVelocity;
    public Vector3 newVelocity;
    public Vector3 currentPosition;
    public Vector3 newPosition;


    public Barycentric bary_Access;
    Vector3 newAcceleration;
    
    private void Start()
    {
        bary_Access = barycentricInformation.GetComponent<Barycentric>();
        vertex = meshInfo.GetComponent<MeshMakerFromFile>().mesh_vert;
        mass = 0.1f;
        currentPosition = vertex[0];
        newVelocity = Vector3.zero;
    
    }

    private void FixedUpdate()
    {        
        Acceleration();

        Velocity();

        Position();

        this.transform.position = newPosition;
    }

    void Acceleration()
    {
        Vector3 Gvec = new Vector3(0.0f, -gravity, 0.0f);

        Vector3 edge1 = bary_Access.AB;
        Vector3 edge2 = bary_Access.AC;
        Vector3 norm = Vector3.Cross(edge1, edge2);
        Debug.Log("Norm for Acceleration: " + norm);

        Vector3 surfaceN = Vector3.Cross(Gvec, norm.normalized);
        
        Vector3 netForce = surfaceN + Gvec;
        Debug.Log("netForce for Acceleration: " + netForce);

        acceleration = netForce / mass;
        Debug.Log("Acceleration: " +  acceleration);

    }

    void Velocity()
    {
        newVelocity = currentVelocity + (acceleration * Time.fixedDeltaTime);
        Debug.Log("newVelocity: " +  newVelocity);
    }

    void Position()
    {
        newPosition = currentPosition + (newVelocity * Time.fixedDeltaTime) + (0.5f * acceleration) * (Time.fixedDeltaTime * Time.fixedDeltaTime);
        Debug.Log("newPosition: " + newPosition);
    }

    Vector3 Acceleration(Vector3 triangleNormal)
    {
        float gravity = 9.81f;
        Vector3 gravVec = new Vector3(0.0f, gravity, 0.0f);
        
        return Vector3.zero;
    }

    Vector3 Normal()
    {

        Vector3 normal = bary_Access.AB;
        Vector3 normal2 = bary_Access.AC;
        
        Vector3 n = Vector3.Cross(normal, normal2).normalized;
        
        return n;
    }
}
