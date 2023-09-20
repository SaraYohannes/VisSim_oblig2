using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class ReadTextFile : MonoBehaviour
{
    /*
     * This file should read a text file I add to the resources and print it to the console
     */

    private void Start()
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

    void ReadFiles(string verticies, string indecies)
    {
        StreamReader vertReader = new StreamReader(verticies);
        Debug.Log(vertReader.ReadToEnd());
        vertReader.Close();

        StreamReader inReader = new StreamReader(indecies);
        Debug.Log(inReader.ReadToEnd());
        inReader.Close();
    }
}
