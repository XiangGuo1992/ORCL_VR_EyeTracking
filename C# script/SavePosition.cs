using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using System.Globalization;

public class SavePosition : MonoBehaviour
{
    private string _folder = "Data_Unity";

    string FILE_NAME = "Data_Unity\\" + DateTime.Now.ToString("yyyyMMddTHHmmss") + ".csv";
    
    
    Camera cam;
    //define object
    GameObject cube;
    GameObject sphere;
    GameObject car;
    GameObject pedestrian;





    // Start is called before the first frame update
    void Start()
    {
        
        //find game object by name
        //cube = GameObject.Find("Cube");
        //sphere = GameObject.Find("Sphere");
        pedestrian = GameObject.Find("VRCamera");
        cam = pedestrian.GetComponent<Camera>();

        //car = GameObject.Find("Car_1(Clone)");
        //car = GameObject.Find("Car_2 Variant(Clone)");




        StreamWriter sw = File.AppendText(FILE_NAME);
        sw.WriteLine("date, time, timestamp, data_time," + 
            "screenPospedestrianX,screenPospedestrianY, screenPospedestrianZ," +
            "pedestrianworldpositionX, pedestrianworldpositionY, pedestrianworldpositionZ,"+
            "screenPosCarX,screenPosCarY, screenPosCarZ," +
            "CarworldpositionX, CarworldpositionY, CarworldpositionZ,"
            //"screenPosCubeX,screenPosCubeY, screenPosCubeZ," +
            //"screenPosSphereX,screenPosSphereY, screenPosSphereZ, " +
            //"CubeworldpositionX, CubeworldpositionY, CubeworldpositionZ," +
            //"SphereworldpositionX ,SphereworldpositionY, SphereworldpositionZ"
            );
        sw.Close();
    }

    // Update is called once per frame
    void Update()
    {

        car = findCar();

        var timestamp = DateTime.Now.ToFileTime();
        string data_time = DateTime.Now.ToString("yyyyMMddTHHmmss");

        string time = DateTime.Now.ToString("hh:mm:ss"); // includes leading zeros
        string date = DateTime.Now.ToString("dd/MM/yy"); // includes leading zeros

        Vector3 screenPospedestrian = cam.WorldToScreenPoint(pedestrian.transform.position);
        Vector3 screenPosCar = cam.WorldToScreenPoint(car.transform.position);

        //Vector3 screenPosCube = cam.WorldToScreenPoint(cube.transform.position);

        //Vector3 screenPosSphere = cam.WorldToScreenPoint(sphere.transform.position);




        StreamWriter sw = File.AppendText(FILE_NAME);

        sw.WriteLine(date + "," + time + "," + timestamp + "," + data_time + "," +
            screenPospedestrian.x + "," + screenPospedestrian.y + "," + screenPospedestrian.z + "," +
            pedestrian.transform.position.x + "," + pedestrian.transform.position.y + "," + pedestrian.transform.position.z+ "," +
            screenPosCar.x + "," + screenPosCar.y + "," + screenPosCar.z + "," +
            car.transform.position.x + "," + car.transform.position.y + "," + car.transform.position.z
            //screenPosCube.x + "," + screenPosCube.y + "," + screenPosCube.z + "," +
            //screenPosSphere.x + "," + screenPosSphere.y + "," + screenPosSphere.z + "," +
            //cube.transform.position.x + "," + cube.transform.position.y + "," + cube.transform.position.z + "," +
            //sphere.transform.position.x + "," + sphere.transform.position.y + "," + sphere.transform.position.z
            );

        sw.Close();

        Debug.Log("write to file");
    }

    private GameObject findCar()
    {
        if (GameObject.Find("Car_1(Clone)") != null)
        {
            car = GameObject.Find("Car_1(Clone)");
            
        }
        else if (GameObject.Find("Car_2 Variant(Clone)") != null)
        {
            car = GameObject.Find("Car_2 Variant(Clone)"); 
        }
        else if (GameObject.Find("Car_3 Variant(Clone)") != null)
        {
            car = GameObject.Find("Car_3 Variant(Clone)");
        }
        return car;
    }

}