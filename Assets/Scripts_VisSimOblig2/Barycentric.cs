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
        Vector3 barycentric;

        Vector2 t_0;
        t_0.x = vertexInformation[0].x;
        t_0.y = vertexInformation[0].z;
        Vector2 t_1;
        t_1.x = vertexInformation[1].x;
        t_1.y = vertexInformation[1].z;
        Vector2 t_2;
        t_2.x = vertexInformation[2].x;
        t_2.y = vertexInformation[2].z;
        Vector2 t_p;
        t_p.x = sphere.x;
        t_p.y = sphere.z;
        
        Vector2 _0P = t_p - t_0;
        Vector2 _1P = t_p + t_1;
        Vector2 _2P = t_p - t_2;

        float mortal =  Vector2.Dot((t_1-t_0), (t_2-t_0));

        float u = ((_0P.x*_1P.y)-(_0P.y*_1P.x)) / mortal;
        float v = ((_1P.x * _2P.y) - (_1P.y * _2P.x)) / mortal;
        float w = ((_2P.x * _0P.y) - (_2P.y * _0P.x)) / mortal;

        float result = u + v + w;

        barycentric.x = u; barycentric.z = v; barycentric.y = w;    
         
        Debug.Log(result);
       
        
        /*
        Vector3 u = vertexInformation[1] - vertexInformation[0];
        Vector3 v = vertexInformation[2] - vertexInformation[0];
        Vector3 w = sphere - vertexInformation[0];

        // cross products
        Vector3 uw;
        uw.x = (u.z * w.y) - (u.y * w.z);
        uw.z = (u.x * w.y) - (u.z * w.x);
        uw.y = (u.x * w.z) - (u.z * w.x);
        float normal = 

        Vector3 vw;
        uw.x = (v.z * w.y) - (v.y * w.z);
        uw.z = (v.x * w.y) - (v.z * w.x);
        uw.y = (v.x * w.z) - (v.z * w.x);
        */


        /*
        // first define triangle and its normal
        Vector3 A = vertexInformation[0];
        Vector3 B = vertexInformation[1];
        Vector3 C = vertexInformation[2];

        float triangle_normal = Vector3.Dot(C - A, B - A);        

        float d_ABAB = Vector3.Dot(A, B) * Vector3.Dot(A, B);
        float d_ABAC = Vector3.Dot(A, B) * Vector3.Dot(A, C);
        float d_ACAC = Vector3.Dot(A, C) * Vector3.Dot(A, C);
        float d_APAB = Vector3.Dot(A, sphere) * Vector3.Dot(A, B);
        float d_APAC = Vector3.Dot(A, sphere) * Vector3.Dot(A, C);

        float u = (d_ACAC * d_APAB) - (d_ABAC * d_APAC) / triangle_normal;
        float v = (d_ABAB * d_APAC) - (d_ABAC * d_APAB) / triangle_normal;
        float w = 1.0f - u - v;

        Debug.Log("Barycentric Coordinates: " + "( " + u + ", " + v + ", " + w + " )");
        float result = u + v + w;

        Debug.Log("BaryCentric result: " + result);
        */

        return barycentric;
        
    }


}
