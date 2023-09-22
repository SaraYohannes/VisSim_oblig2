using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barycentric : MonoBehaviour
{
    /*
     * This is to find the center of the sphere using barycentric coordinates
     */

    public MeshMakerFromFile MeshInfo;
    public GameObject SphereInfo;

    private void Start()
    {

        // Vector3 array with vertex information about the mesh
        Vector3[] meshinfo = MeshInfo.GetComponent<MeshMakerFromFile>().mesh_vert;
        // GameObject with all information about the sphere
        GameObject sphere = SphereInfo.GetComponent<GameObject>();
        
        Vector3 currentLocaton = baryCentricPosition();

    }

    Vector3 baryCentricPosition()
    {
        Vector3 currentLocation = Vector3.zero;
        
        // now we do barycentric findings, where is the sphere?, inside which triangle??
        // do we have a last known location?
        // no? go to first triangle
        // triangle 0 says - is it here?
        // if it isn't it goes to its first neighbour - see meshmakerfromfile's neighbour array
        // if it is - save this for later
        // yes? start looking there
        // check last known triangle
        // if it isn't it goes to its first neighbour - see meshmakerfromfile's neighbour array
        // if it is - save this for later

        return currentLocation;
    }


}
