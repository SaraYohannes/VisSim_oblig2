using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Barycentric : MonoBehaviour
{
    /*
     * This is to find the center of the sphere using barycentric coordinates
     */

    [SerializeField] public MeshMakerFromFile MeshInfo;
    [SerializeField] public Transform SphereInfo;
    [SerializeField] public Transform tester_gizmo;
    Vector3[] meshinfo;

    private void Start()
    {
        // Vector3 array with vertex information about the mesh
        meshinfo = MeshInfo.GetComponent<MeshMakerFromFile>().mesh_vert;
        // GameObject with all information about the sphere
        SphereInfo = SphereInfo.GetComponent<Transform>();        
        // Gizmo to track barycooridinates
        tester_gizmo = tester_gizmo.GetComponent<Transform>();


        Vector3 sphere_vec = SphereInfo.transform.position;
        Vector3 currentLocaton = baryCentricPosition(meshinfo, sphere_vec);
        tester_gizmo.transform.position = currentLocaton;
    }

    private void Update()
    {
    }

    Vector3 baryCentricPosition(Vector3[] vertexInformation, Vector3 sphere)
    {
        // barycentric calculations
        // first define triangle and its normal
        float triangle_normal = Vector3.Dot(vertexInformation[3] - vertexInformation[0], vertexInformation[1] - vertexInformation[0]);
        
        Vector3 A = vertexInformation[0];
        Vector3 B = vertexInformation[1];
        Vector3 C = vertexInformation[2];

        Vector3 AP = A - sphere;
        Vector3 BP = B - sphere;
        Vector3 CP = C - sphere;

        float u = Vector3.Dot(AP, BP) / triangle_normal;
        float v = Vector3.Dot(BP, CP) / triangle_normal;
        float w = Vector3.Dot(CP, AP) / triangle_normal;

        Debug.Log("Barycentric Coordinates: " + "( " + u + ", " + v + ", " + w + " )");
        float result = u + v + w;

        Debug.Log("BaryCentric result: " + result);
        
        return new Vector3(u, v, w);
        
    }


}
