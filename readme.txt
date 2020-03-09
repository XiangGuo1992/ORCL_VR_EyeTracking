------------------------------------------------------------------------------
 Copyright © 2017, 2019 Tobii Pro AB. All rights reserved.
------------------------------------------------------------------------------

The following describes how to create a simple VR scene with calibration, gaze
trail rendering, positioning guide, and data saving.

The Vive can use either the Unity built in OpenVR support or the SteamVR
package from the Unity asset store. The <Num>.a [SteamVR] choices below are for
creating a scene using SteamVR, the <Num>.b [UnityVR] choices are for using the
Unity built in support. Use one or the other, not both.

1. Create a new scene.

Points 2 - 3 are needed to enable virtual reality support and Tobii eye tracking
in a project.

2.a [SteamVR] Import the SteamVR package from the asset store.
2.b [UnityVR] Enable VR support under the menu option:
              "Edit -> Project Settings... -> Player -> XR Settings -> Virtual
              Reality Supported". Also make sure the OpenVR package is added to
			  the project. The package manager is found under "Window ->
			  Package Manager".
3. Import the TobiiPro.SDK.Unity.Windows package.

Points 4 - 12 show how to create a scene with calibration, gaze trail, data
saving, and a positioning guide.

4.a [SteamVR] Remove any camera in the scene (the default camera is called
              "Main Camera"). When creating a scene from scratch and importing
              Steam VR, there will be a conflict with the default camera in the
              scene.
4.b [UnityVR] Set the camera position to (0, 0, 0).
5.a [SteamVR] Drag and drop the "SteamVR\Prefabs\[CameraRig]" prefab into the
              scene.
6. Drag and drop the "TobiiPro\VR\Prefabs\[VREyeTracker]" prefab into the scene.
7. Drag and drop the "TobiiPro\VR\Prefabs\[VRCalibration]" prefab into the
   scene. Select the [VRCalibration] prefab and in the inspector, select a key
   to be used to start a calibration.
8. Drag and drop the "TobiiPro\VR\Prefabs\[VRSaveData]" prefab into the scene.
   Select the [VRSaveData] prefab and in the inspector, select a key to be used
   to start and stop saving data.
9. Drag and drop the "TobiiPro\VR\Prefabs\[VRPositioningGuide]" prefab into the
   scene. Select the [VRPositioningGuide] prefab and in the inspector, select a
   key to be used to show and hide the positioning guide.  
10. Drag and drop the "TobiiPro\VR\Prefabs\[VRGazeTrail]" prefab into the scene.
11. Right click in the hierarchy and select "3D Object -> Cube". Place the cube
    at position (0, 1, 3) in the scene. Optionally, adjust the light in the
    scene so that the cube is clearly visible from the camera.
12.a [SteamVR] Generating default actions for SteamVR
               * A dialog may be shown stating that it is necessary to generate
                 actions for SteamVR, if so, click "Yes" to open the SteamVR
                 Input window. Note, the dialog may appear more than once.
               * A dialog may be shown stating that the project is missing an
                 "actions.json" file. Click "Yes" to use the example file.
               * In the SteamVR Input window, click "Save and generate".
                 The necessary files should now be generated. It may take a
                 little while.
               * There may be a dialog asking to save the scene, if so, save the
                 scene with a suitable name.
               * After the file generation has finished, the scene that was just
                 saved may have to be opened again.
               * Continue where you left off in the flow above.
13. Play the scene.
    * Press the positioning guide key selected earlier to show and hide the
      positioning guide. Adjust the HMD until the eyes are placed as centered as
      possible.
    * Press the calibration key selected earlier to perform a calibration.
    * Look at the cube. A gaze trail should be rendered on it.
    * Press the save data key selected earlier to start saving data. Press it
      again to stop saving. The saved XML data can be found in the "Data" folder
      in the project root.
