using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using System.Globalization;

public class SavePosition : MonoBehaviour
{
    DateTime now = DateTime.Now;

    string FILE_NAME = "C:\\research\\VR-EyeTracking\\Unity_output\\" + DateTime.Now.ToString("yyyy - MM - dd HH - mm - ss") + ".csv";

    Camera cam;
    //define object
    GameObject cube;
    GameObject sphere;

    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponent<Camera>();
        //find game object by name
        cube = GameObject.Find("Cube");
        sphere = GameObject.Find("Sphere");

        StreamWriter sw = File.AppendText(FILE_NAME);
        sw.WriteLine("date, time, timestamp," +
            "screenPosCubeX,screenPosCubeY, screenPosCubeZ," +
            "screenPosSphereX,screenPosSphereY, screenPosSphereZ, " +
            "CubeworldpositionX, CubeworldpositionY, CubeworldpositionZ," +
            "SphereworldpositionX ,SphereworldpositionY, SphereworldpositionZ");
        sw.Close();
    }

    // Update is called once per frame
    void Update()
    {
        var timestamp = DateTime.Now.ToFileTime();

        string time = DateTime.Now.ToString("hh:mm:ss"); // includes leading zeros
        string date = DateTime.Now.ToString("dd/MM/yy"); // includes leading zeros

        Vector3 screenPosCube = cam.WorldToScreenPoint(cube.transform.position);
        
        Vector3 screenPosSphere = cam.WorldToScreenPoint(sphere.transform.position);

        


        StreamWriter sw = File.AppendText(FILE_NAME);

        sw.WriteLine(date + "," + time + "," + timestamp + "," +
            screenPosCube.x + "," + screenPosCube.y + "," + screenPosCube.z + "," +
            screenPosSphere.x + "," + screenPosSphere.y + "," + screenPosSphere.z + "," +
            cube.transform.position.x + "," + cube.transform.position.y + "," + cube.transform.position.z + "," +
            sphere.transform.position.x + "," + sphere.transform.position.y + "," + sphere.transform.position.z);

        sw.Close();

        Debug.Log("write to file");
    }
}
