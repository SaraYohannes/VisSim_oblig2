using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

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


    }

    private void FixedUpdate()
    {
        Vector3 sphere_vec = SphereInfo.transform.position;
        Vector3 currentLocaton = baryCentricPosition(meshinfo, sphere_vec);
        Debug.Log(currentLocaton);
        tester_gizmo.transform.position = currentLocaton;
    }

    Vector3 baryCentricPosition(Vector3[] vertexInformation, Vector3 sphere)
    {
        Vector3 p1 = new Vector3(), p2 = new Vector3(), p3 = new Vector3();
        Vector3 barycentric = new Vector3 (-1.0f, -1.0f, -1.0f);
        Vector2 vec2sphere = new Vector2(sphere.x, sphere.z);

        for (int i = 0; i < vertexInformation.Length / 3; i++)
        {
            p1 = vertexInformation[i * 3];
            p2 = vertexInformation[i * 3 + 1];
            p3 = vertexInformation[i * 3 + 2];

            barycentric = getBaryC(new Vector2(p1.x, p1.z), new Vector2(p2.x, p2.z), new Vector2(p3.x, p3.z), vec2sphere);

            if (barycentric.x >= 0 && barycentric.y >= 0 && barycentric.z >= 0)
            {
                break;
            }
        }

        return barycentric;
        
    }

    Vector3 getBaryC(Vector2 p1, Vector2 p2, Vector2 p3, Vector2 vec2sphere)
    {
        Vector2 v0 = p2 - p1;
        Vector2 v1 = p3 - p1;
        Vector2 v2 = vec2sphere - p1;
        Debug.Log("GetBaryC v0: " + v0 + " v1: " + v1 + " v2: " + v2);
        float d00 = Vector2.Dot(v0, v0);
        float d01 = Vector2.Dot(v0, v1);
        float d11 = Vector2.Dot(v1, v1);
        float d20 = Vector2.Dot(v2, v0);
        float d21 = Vector2.Dot(v2, v1);
        float denom = d00 * d11 - d01 * d01;
        Debug.Log("GetBaryC denom: " + denom);
        float v = (d11 * d20 - d01 * d21) / denom;
        float w = (d00 * d21 - d01 * d20) / denom;
        float u = (1.0f - v - w);

        Vector3 barycentric3D = new Vector3(u, v, w);
        Debug.Log("GetBaryC returns: " + barycentric3D);

        return barycentric3D;

    }

}
