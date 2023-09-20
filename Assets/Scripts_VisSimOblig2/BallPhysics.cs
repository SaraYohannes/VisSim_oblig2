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
    void Start()
    {
        GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        
    }
}
