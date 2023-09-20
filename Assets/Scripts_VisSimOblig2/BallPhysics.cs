using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallPhysics : MonoBehaviour
{
    /*
     * This file will 
     * - set a sphere primitive above the first vertex (vert[0]) of the mesh
     * - add values to the primitive
     * - calculate the sphere primitive's movement
     */

    private void Awake()
    {
 
    }
    void Start()
    {
        transform.position = Vector3.zero;
    }

    private void FixedUpdate()
    {
        bool hei = barycentric(transform.position);
        if (!hei)
        {
            //return error, out of bounds
        }
        else
        {
            //check projection on normal to find collition
        }
    }

    bool barycentric(Vector3 pos)
    {
        return true;
    }
}
