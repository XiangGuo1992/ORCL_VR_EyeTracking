using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using System.Globalization;
using Valve.VR;
using UnityEngine.SceneManagement;
using ANT_Managed_Library;

public class SavePosition_bike : MonoBehaviour
{
    private string _folder = "Data_Unity";

    string sceneName;
    Scene m_Scene;
    string FILE_NAME;

    //for bike data
    float speed; //Instantaneous speed
    float elapsedTime; //Accumulated value of the elapsed time since start of workout in seconds
    int heartRate; //0xFF indicates invalid
    int distanceTraveled; //Accumulated value of the distance traveled since start of workout in meters
    int instantaneousPower; //Stationary Bike specific
    int cadence; //Specific Trainer Data



    //string FILE_NAME = "Data_Unity\\" + DateTime.Now.ToString("yyyyMMddTHHmmss") + ".csv";

    //STEAMVR INPUT binding UI http://localhost:27062/dashboard/controllerbinding.html?app=application.generated.unity.testproj.exe

    // https://sarthakghosh.medium.com/a-complete-guide-to-the-steamvr-2-0-input-system-in-unity-380e3b1b3311

    // For the trigger
    // // a reference to the action
    public SteamVR_Action_Boolean Trigger_press; //Grab Pinch is the trigger, select from inspecter
    // a reference to the hand
    public SteamVR_Input_Sources TriggerHandType;

    //for the grip
    public SteamVR_Action_Boolean Grip_press;
    public SteamVR_Input_Sources GripHandType;

    //for the touchpad
    public SteamVR_Action_Boolean Touchpad_press;
    public SteamVR_Input_Sources TouchpadHandType;






    Camera cam;
    //define object
    //GameObject cube;
    //GameObject sphere;
    GameObject car;
    GameObject VRU;

    int Trigger_press_controller_state;
    int Grip_press_controller_state;
    int TouchPad_press_controller_state;
    private Vector2 TouchPad_axis;

    // Start is called before the first frame update
    void Start()
    {

        m_Scene = SceneManager.GetActiveScene();
        sceneName = m_Scene.name;

        FILE_NAME = "Data_Unity\\"  + DateTime.Now.ToString("yyyyMMddTHHmmss") + "_" + sceneName.ToString() + ".csv";

        //find game object by name
        //cube = GameObject.Find("Cube");
        //sphere = GameObject.Find("Sphere");
        VRU = GameObject.Find("VRCamera");
        cam = VRU.GetComponent<Camera>();
        car = GameObject.Find("------Car Spawner");

        Trigger_press_controller_state = 0;
        Grip_press_controller_state = 0;
        TouchPad_press_controller_state = 0;
        TouchPad_axis = new Vector2(0.0f, 0.0f);



        Trigger_press.AddOnStateDownListener(TriggerDown, TriggerHandType);
        Trigger_press.AddOnStateUpListener(TriggerUp, TriggerHandType);

        Grip_press.AddOnStateDownListener(GripDown,GripHandType);
        Grip_press.AddOnStateUpListener(GripUp, GripHandType);

        Touchpad_press.AddOnStateDownListener(TouchpadDown, TouchpadHandType);
        Touchpad_press.AddOnStateUpListener(TouchpadUp, TouchpadHandType);

        //TouchPad.AddOnAxisListener(TouchpadValue, TouchpadHandType);





        StreamWriter sw = File.AppendText(FILE_NAME);
        sw.WriteLine("date, time, timestamp, data_time," + "camposition.x , camposition.y, camposition.z," + "Camera.facing.x," + "Camera.facing.y," + "Camera.facing.z," + "Trigger_press_controller_state,"
            + "Grip_press_controller_state," + "TouchPad_press_controller_state," + "left_controller.x , left_controller.y, left_controller.z," + "right_controller.x , right_controller.y, right_controller.z,"
            + "speed," + "elapsedTime," + "heartRate," + "distanceTraveled," + "instantaneousPower," + "cadence" 

            //"screenPospedestrianX,screenPospedestrianY, screenPospedestrianZ," +
            //"pedestrianworldpositionX, pedestrianworldpositionY, pedestrianworldpositionZ,"+
            //"screenPosCubeX,screenPosCubeY, screenPosCubeZ," +
            //"CubeworldpositionX, CubeworldpositionY, CubeworldpositionZ,"
            //"screenPosCubeX,screenPosCubeY, screenPosCubeZ," +
            //"screenPosSphereX,screenPosSphereY, screenPosSphereZ, " +
            //"CubeworldpositionX, CubeworldpositionY, CubeworldpositionZ," +
            //"SphereworldpositionX ,SphereworldpositionY, SphereworldpositionZ"
            );
        sw.Close();
    }


    public void TriggerUp(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource)
    {
        Trigger_press_controller_state = 0;

    }
    public void TriggerDown(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource)
    {
        Trigger_press_controller_state = 1;

    }

    public void GripUp(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource)
    {
        Grip_press_controller_state = 0;

    }
    public void GripDown(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource)
    {
        Grip_press_controller_state = 1;

    }

    public void TouchpadUp(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource)
    {
        TouchPad_press_controller_state = 0;

    }
    public void TouchpadDown(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource)
    {
        TouchPad_press_controller_state = 1;

    }

    /*
    public void TouchpadValue()
    {
        TouchPad_axis = TouchPad_axis.GetAxis();

    }
    */


    // Update is called once per frame
    void Update()
    {
        var timestamp = DateTime.Now.ToFileTime();
        string data_time = DateTime.Now.ToString("yyyyMMddTHHmmss");

        string time = DateTime.Now.ToString("hh:mm:ss"); // includes leading zeros
        string date = DateTime.Now.ToString("dd/MM/yy"); // includes leading zeros

        Vector3 camposition =cam.transform.position;
        Vector3 camfacing = cam.transform.forward;

        Vector3 left_controller = GameObject.Find("-----Bicycle/Indicator/Player/SteamVRObjects/LeftHand").transform.position;
        Vector3 right_controller = GameObject.Find("-----Bicycle/Indicator/Player/SteamVRObjects/RightHand").transform.position;


        speed = GameObject.Find("-----Bicycle/Indicator/FitnessEquipmentDisplay").GetComponent<FitnessEquipmentDisplay>().speed;
        elapsedTime = GameObject.Find("-----Bicycle/Indicator/FitnessEquipmentDisplay").GetComponent<FitnessEquipmentDisplay>().elapsedTime;
        heartRate = GameObject.Find("-----Bicycle/Indicator/FitnessEquipmentDisplay").GetComponent<FitnessEquipmentDisplay>().heartRate;
        distanceTraveled = GameObject.Find("-----Bicycle/Indicator/FitnessEquipmentDisplay").GetComponent<FitnessEquipmentDisplay>().distanceTraveled;
        instantaneousPower = GameObject.Find("-----Bicycle/Indicator/FitnessEquipmentDisplay").GetComponent<FitnessEquipmentDisplay>().instantaneousPower;
        cadence = GameObject.Find("-----Bicycle/Indicator/FitnessEquipmentDisplay").GetComponent<FitnessEquipmentDisplay>().cadence;



        //Vector3 screenPospedestrian = cam.WorldToScreenPoint(pedestrian.transform.position);
        //Vector3 screenPosCube = cam.WorldToScreenPoint(cube.transform.position);

        //Vector3 screenPosCube = cam.WorldToScreenPoint(cube.transform.position);

        //Vector3 screenPosSphere = cam.WorldToScreenPoint(sphere.transform.position);




        StreamWriter sw = File.AppendText(FILE_NAME);

        sw.WriteLine(date + "," + time + "," + timestamp + "," + data_time + "," + camposition.x + "," + camposition.y + "," + camposition.z + ","
             + camfacing.x + "," + camfacing.y + "," + camfacing.z + "," + Trigger_press_controller_state + "," + Grip_press_controller_state + "," + TouchPad_press_controller_state + ","
             + left_controller.x + "," + left_controller.y + "," + left_controller.z + "," + right_controller.x + "," + right_controller.y + "," + right_controller.z + ","

              + speed + "," + elapsedTime + "," + heartRate + "," + distanceTraveled + "," + instantaneousPower + "," + cadence 
            //screenPospedestrian.x + "," + screenPospedestrian.y + "," + screenPospedestrian.z + "," +
            //pedestrian.transform.position.x + "," + pedestrian.transform.position.y + "," + pedestrian.transform.position.z+ "," +
            //screenPosCube.x + "," + screenPosCube.y + "," + screenPosCube.z + "," +
            //cube.transform.position.x + "," + cube.transform.position.y + "," + cube.transform.position.z
            //screenPosCube.x + "," + screenPosCube.y + "," + screenPosCube.z + "," +
            //screenPosSphere.x + "," + screenPosSphere.y + "," + screenPosSphere.z + "," +
            //cube.transform.position.x + "," + cube.transform.position.y + "," + cube.transform.position.z + "," +
            //sphere.transform.position.x + "," + sphere.transform.position.y + "," + sphere.transform.position.z 
            );

        sw.Close();

        //Debug.Log("write to file");
    }
}