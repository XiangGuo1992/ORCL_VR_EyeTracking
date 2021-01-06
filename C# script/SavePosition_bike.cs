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
    public SteamVR_Action_Boolean Trigger_press_left; //Grab Pinch is the trigger, select from inspecter
    // a reference to the hand
    public SteamVR_Input_Sources TriggerHandLeft;
    public SteamVR_Action_Boolean Trigger_press_right; //Grab Pinch is the trigger, select from inspecter
    // a reference to the hand
    public SteamVR_Input_Sources TriggerHandRight;

    //for the trigger squeeze
    public SteamVR_Action_Single Trigger_squeeze_left;
    public SteamVR_Input_Sources Trigger_squeeze_HandLeft;
    //for the trigger squeeze
    public SteamVR_Action_Single Trigger_squeeze_right;
    public SteamVR_Input_Sources Trigger_squeeze_HandRight;

    //for the grip
    public SteamVR_Action_Boolean Grip_press_left;
    public SteamVR_Input_Sources GripHandLeft;
    //for the grip
    public SteamVR_Action_Boolean Grip_press_right;
    public SteamVR_Input_Sources GripHandRight;

    //for the touchpad
    public SteamVR_Action_Boolean Touchpad_press_left;
    public SteamVR_Input_Sources Touchpadpress_HandLeft;
    //for the touchpad
    public SteamVR_Action_Boolean Touchpad_press_right;
    public SteamVR_Input_Sources Touchpadpress_HandRight;

    //for the touchpad
    public SteamVR_Action_Boolean Touchpad_touch_left;
    public SteamVR_Input_Sources Touchpadtouch_HandLeft;
    //for the touchpad
    public SteamVR_Action_Boolean Touchpad_touch_right;
    public SteamVR_Input_Sources Touchpadtouch_HandRight;

    //for the touchpad
    public SteamVR_Action_Vector2 Touchpad_position_left;
    public SteamVR_Input_Sources Touchpadposition_HandLeft;
    //for the touchpad
    public SteamVR_Action_Vector2 Touchpad_position_right;
    public SteamVR_Input_Sources Touchpadposition_HandRight;






    Camera cam;
    //define object
    //GameObject cube;
    //GameObject sphere;
    GameObject car;
    GameObject VRU;

    int Trigger_press_controller_state_left;
    int Grip_press_controller_state_left;
    int TouchPad_press_controller_state_left;
    int TouchPad_touch_controller_state_left;
    private Vector2 TouchPad_axis_left;
    private float Trigger_squeeze_value_left;

    int Trigger_press_controller_state_right;
    int Grip_press_controller_state_right;
    int TouchPad_press_controller_state_right;
    int TouchPad_touch_controller_state_right;
    private Vector2 TouchPad_axis_right;
    private float Trigger_squeeze_value_right;


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

        Trigger_press_controller_state_left = 0;
        Grip_press_controller_state_left = 0;
        TouchPad_press_controller_state_left = 0;
        TouchPad_touch_controller_state_left = 0;
        TouchPad_axis_left = new Vector2(0.0f, 0.0f);

        Trigger_press_controller_state_right = 0;
        Grip_press_controller_state_right = 0;
        TouchPad_press_controller_state_right = 0;
        TouchPad_touch_controller_state_right = 0;
        TouchPad_axis_right = new Vector2(0.0f, 0.0f);




        Trigger_press_left.AddOnStateDownListener(TriggerDownLeft, TriggerHandLeft);
        Trigger_press_left.AddOnStateUpListener(TriggerUpLeft, TriggerHandLeft);

        Trigger_press_right.AddOnStateDownListener(TriggerDownRight, TriggerHandRight);
        Trigger_press_right.AddOnStateUpListener(TriggerUpRight, TriggerHandRight);


        Grip_press_left.AddOnStateDownListener(GripDownLeft, GripHandLeft);
        Grip_press_left.AddOnStateUpListener(GripUpLeft, GripHandLeft);
        Grip_press_right.AddOnStateDownListener(GripDownRight, GripHandRight);
        Grip_press_right.AddOnStateUpListener(GripUpRight, GripHandRight);

        Touchpad_press_left.AddOnStateDownListener(TouchpadDownLeft, Touchpadpress_HandLeft);
        Touchpad_press_left.AddOnStateUpListener(TouchpadUpLeft, Touchpadpress_HandLeft);
        Touchpad_press_right.AddOnStateDownListener(TouchpadDownRight, Touchpadpress_HandRight);
        Touchpad_press_right.AddOnStateUpListener(TouchpadUpRight, Touchpadpress_HandRight);

        Touchpad_touch_left.AddOnStateDownListener(TouchpadTouchDownLeft, Touchpadtouch_HandLeft);
        Touchpad_touch_left.AddOnStateUpListener(TouchpadTouchUpLeft, Touchpadtouch_HandLeft);
        Touchpad_touch_right.AddOnStateDownListener(TouchpadTouchDownRight, Touchpadtouch_HandRight);
        Touchpad_touch_right.AddOnStateUpListener(TouchpadTouchUpRight, Touchpadtouch_HandRight);





        //Touchpad_position.AddOnAxisListener(TouchpadValue, Touchpadposition_HandType);





        StreamWriter sw = File.AppendText(FILE_NAME);
        sw.WriteLine("date, time, timestamp, data_time," + "camposition.x , camposition.y, camposition.z," + "Camera.facing.x," + "Camera.facing.y," + "Camera.facing.z," 
            + "Trigger_press_controller_state_left, Trigger_squeeze_value_left," + "Trigger_press_controller_state_right, Trigger_squeeze_value_right,"
            + "Grip_press_controller_state_left, Grip_press_controller_state_right," + "TouchPad_press_controller_state_left,TouchPad_press_controller_state_right," 
            + "TouchPad_touch_controller_state_left,TouchPad_touch_controller_state_right,"
            + "TouchPad_axis_left.x , TouchPad_axis_left.y," + "TouchPad_axis_right.x , TouchPad_axis_right.y,"
            + "left_controller.x , left_controller.y, left_controller.z," + "right_controller.x , right_controller.y, right_controller.z,"
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


    public void TriggerUpLeft(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource)
    {
        Trigger_press_controller_state_left = 0;
    }
    public void TriggerDownLeft(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource)
    {
        Trigger_press_controller_state_left = 1;

    }

    public void TriggerUpRight(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource)
    {
        Trigger_press_controller_state_right = 0;
    }
    public void TriggerDownRight(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource)
    {
        Trigger_press_controller_state_right = 1;

    }



 


    public void GripUpLeft(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource)
    {
        Grip_press_controller_state_left = 0;

    }
    public void GripDownLeft(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource)
    {
        Grip_press_controller_state_left = 1;

    }

    public void GripUpRight(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource)
    {
        Grip_press_controller_state_right = 0;

    }
    public void GripDownRight(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource)
    {
        Grip_press_controller_state_right = 1;

    }



    public void TouchpadUpLeft(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource)
    {
        TouchPad_press_controller_state_left = 0;

    }
    public void TouchpadDownLeft(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource)
    {
        TouchPad_press_controller_state_left = 1;

    }

    public void TouchpadUpRight(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource)
    {
        TouchPad_press_controller_state_right = 0;

    }
    public void TouchpadDownRight(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource)
    {
        TouchPad_press_controller_state_right = 1;

    }



    public void TouchpadTouchUpLeft(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource)
    {
        TouchPad_touch_controller_state_left = 0;

    }
    public void TouchpadTouchDownLeft(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource)
    {
        TouchPad_touch_controller_state_left = 1;

    }

    public void TouchpadTouchUpRight(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource)
    {
        TouchPad_touch_controller_state_right = 0;

    }
    public void TouchpadTouchDownRight(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource)
    {
        TouchPad_touch_controller_state_right = 1;

    }



    /*
      public void TouchpadValue()
      {
          TouchPad_axis = Touchpad_position.GetAxis();

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

        TouchPad_axis_left = Touchpad_position_left.GetAxis(Touchpadposition_HandLeft);
        TouchPad_axis_right = Touchpad_position_right.GetAxis(Touchpadposition_HandRight);
        //Trigger_squeeze_value = Trigger_squeeze.GetAxis(Trigger_squeeze_HandType);
        Trigger_squeeze_value_left = Trigger_squeeze_left.GetAxis(Trigger_squeeze_HandLeft);
        Trigger_squeeze_value_right = Trigger_squeeze_right.GetAxis(Trigger_squeeze_HandRight);


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
             + camfacing.x + "," + camfacing.y + "," + camfacing.z + ","             
             + Trigger_press_controller_state_left + "," + Trigger_squeeze_value_left + "," + Trigger_press_controller_state_right + "," + Trigger_squeeze_value_right + ","
             + Grip_press_controller_state_left + "," + Grip_press_controller_state_right + ","               
             + TouchPad_press_controller_state_left + "," + TouchPad_press_controller_state_right + ","              
             + TouchPad_touch_controller_state_left + "," + TouchPad_touch_controller_state_right + ","
             + TouchPad_axis_left.x + "," + TouchPad_axis_left.y + "," + TouchPad_axis_right.x + "," + TouchPad_axis_right.y + ","
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

        //Debug.Log("trigger_press_state:" + Trigger_press_controller_state + "trigger_press_value:" + Trigger_squeeze_value.ToString("F"));
    }
}