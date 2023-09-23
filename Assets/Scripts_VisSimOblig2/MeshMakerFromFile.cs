using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Unity.VisualScripting;

public class MeshMakerFromFile : MonoBehaviour
{
    /*
     * This file will 
     * - read .txt files for info
     * - assign info to arrays
     * - use arrays to build a custom mesh
     */

    public Vector3[] mesh_vert;        // vertex
    int[] triangle_index =      // index
        {
        0, 3, 1,
        1, 3, 4,
        1, 4, 5,
        1, 5, 2
        };

    // Dictionary<int, int> nameIndex = new Dictionary<int, int>();
    // Dictionary<int, int> nameNeighbour = new Dictionary<int, int>();

    Vector3[] vertex_norm;      // normals to vertex
    Vector3[] triangles;        // index
    Vector3[] neighb;           // neighbour
    Vector3[] triangle_norm;    // normals to triangles

    private void Awake()
    {
        string verticies_txt = "Assets/Resources/oblig1_vertex.txt";
        string indecies_txt = "Assets/Resources/oblig1_index.txt"; 

        if (File.Exists(verticies_txt) && File.Exists(indecies_txt))
        {
            Debug.Log("The file Exists where we expected them to be! Proceed!");
                        
            ReadFiles(verticies_txt, indecies_txt);
        }
        else
        {
            Debug.Log("There is something wrong with the files...");
        }
    }

    private void Start()
    {
        Mesh mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;
        mesh.vertices = mesh_vert;
        mesh.triangles = triangle_index;
    }

    void ReadFiles(string verticies, string indecies)
    {
        StreamReader vertex_sr = new StreamReader(verticies);
        StreamReader index_sr = new StreamReader(indecies);

        // insert vertex_string into final array
        if (vertex_sr != null)
        {
            int vert_count = int.Parse(vertex_sr.ReadLine());
            mesh_vert = new Vector3[vert_count];
            // vertex_norm = new Vector3[vert_count];

            // Debug.Log("vert count: " + vert_count);
            int counter = 0;
            while (!vertex_sr.EndOfStream)
            {
                string temp_line = vertex_sr.ReadLine();

                string[] temp_split_lines = temp_line.Split(' ');

                Vector3 temp_v = new Vector3();

                temp_v.x = float.Parse(temp_split_lines[0]);
                temp_v.y = float.Parse(temp_split_lines[1]);
                temp_v.z = float.Parse(temp_split_lines[2]);

                mesh_vert[counter] = temp_v;
                counter++;
            }
            // for (int i = 0; i < vert_count; i++)
                // Debug.Log(mesh_vert[i]);
        }
        // insert index_string into final array
        if (index_sr != null)
        {
            /*int index_count = int.Parse(index_sr.ReadLine());

            int counter = 0;
            while (!index_sr.EndOfStream)
            {
                string temp_line = index_sr.ReadLine();

                string[] find_name_temp = temp_line.Split(':');

                string name = find_name_temp[0];

                string[] find_index_neighbours = find_name_temp[1].Split(",");



                counter++;
            }*/

            /*        
            // we read first line to figure out size of triangle indecis arr
            int inde_count = int.Parse(index_sr.ReadLine());
            int counter = inde_count * 3;
            triangle_index = new int[counter];
            // check size
            Debug.Log("index count: " + counter);

            // read the rest of the text and insert in arr
            string temp_string = index_sr.ReadToEnd();

            string[] temp_split_list = temp_string.Split(' ');

            for (int i = 0; i < triangle_index.Length; i++)
            {
                if (int.TryParse(temp_split_list[i], out int successParse))
                {
                    triangle_index[i] = successParse;
                }
                else
                {
                    Debug.Log("index i: " + i + " was not successfully parsed and is a huge buttproblem! :(. Added 6 in place of fail.");
                    triangle_index[i] = 6;
                }
            }
            */
            //for (int i = 0; i < counter; i++)
            //    Debug.Log(triangle_index[i]);
        }
    }
}
