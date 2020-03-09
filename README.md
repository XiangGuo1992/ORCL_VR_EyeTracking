# ORCL_VR_EyeTracking
## Introduction

This repository comes with the code for Tobii Eye Tracking integrated in [HTC VIVE Eye Pro](https://www.vive.com/us/product/vive-pro/) in Unity, Which is a part of projects from Omni-Reality and Cognition Lab in University of Virginia (https://engineering.virginia.edu/omni-reality-and-cognition-lab).



## Prerequisite

1.  [HTC VIVE Eye Pro](https://www.vive.com/us/product/vive-pro/) with Tobii Eye Tracking system
2.  [Unity](https://unity.com/) version 2018.4.16
3.  [Python](https://www.python.org/) 3.6.3 ([Anaconda](https://www.anaconda.com/) version recommended)
4.  [SteamVR](https://store.steampowered.com/steamvr) 
5.  Finish the [Set up for the HTC VIVE Eye Pro](https://enterprise.vive.com/eu/setup/vive-pro/)
6.  [Tobii Pro SDK](http://developer.tobiipro.com/index.html) for your platform

The HTC VIVE Eye Pro hardware (headset, controller) is from HTC VIVE, the integrated eye tracker is from Tobii, they have provided multiple ways to get access to the eye tracking data:

- [Tobii Pro SDK](http://developer.tobiipro.com/index.html): A general SDK for getting eye tracking data. This repository will use **Python** and **Unity** only.
- [Tobii XR SDK](https://vr.tobii.com/sdk/develop/unity/): SDK for Unity, developed by Tobii too, to get started, follow the steps in this [link](https://vr.tobii.com/sdk/develop/unity/getting-started/vive-pro-eye/). Tobii XR requires a analytical license to get the raw data, otherwise, eye tracking can only be used for interactive use.
- [Vive Eye Tracking SDK](https://developer.vive.com/resources/knowledgebase/vive-sranipal-sdk/) : SDK for eye tracking from HTC. The forum for it can be found [here](https://forum.vive.com/forum/78-vive-eye-tracking-sdk/).

This repository includes sample code and tutorials for Python and Unity  API of **Tobii Pro SDK** only.



## Tobii Pro SDK data collection

Website of Tobii Pro SDK: http://developer.tobiipro.com/index.html

You can either use Python API or Unity API to get the eye tracking data.

### Python API

Set up Python API as http://developer.tobiipro.com/python/python-getting-started.html. 

Then run the [TobiiEyeTracking.py](TobiiEyeTracking.py) in the repository to collect the data externally (not within Unity).

If an eye tracker is successfully found, the data collecting is on going until the key 'q' is pressed (you can also change it to another key in the code). An output .csv data file (name with the start and end time like [sample_output](Data\EyeTrakcing\TobiiProPython\1575497434.5828066-1575497439.7218742.csv)) will be exported into the *out_dir* defined in the code. 

```python
output_dir = 'C:/github/ORCL_VR_EyeTracking/Data/EyeTrakcing/TobiiProPython'
```

 

### Unity SDK

To start with, read the document from Tobii Pro SDK (http://developer.tobiipro.com/unity.html) and download the [Tobii Pro SDK for Unity](https://www.tobiipro.com/product-listing/tobii-pro-sdk/#Download).

1. Create a new project, or open an existing project, in Unity.
2. Select *Assets > Import Package > Custom Package...* from the main menu, or by right-clicking in the Project window.
3. Browse to the downloaded Tobii Pro SDK, named with TobiiPro.SDK.Unity.Windows.
4. In the next dialog, select to import all files.
5. In the project window, Drag and drop the "TobiiPro\VR\Prefabs\[VREyeTracker]" prefab into the scene and in the inspector, select '**Subscribe To Gaze**'. ![prefab](img\prefabs.jpg)
6. (*Not required*) Drag and drop the "TobiiPro\VR\Prefabs\[VRCalibration]" prefab into the scene. Select the [VRCalibration] prefab and in the inspector, select a key to be used to start a calibration.
7. Drag and drop the "TobiiPro\VR\Prefabs\[VRSaveData]" prefab into the scene. Select the [VRSaveData] prefab and in the inspector, select a key to be used to start and stop saving data. 
8. Play the scene, the save data

 
