# ORCL_VR_EyeTracking
## Introduction

This repository comes with the code for Tobii Eye Tracking integrated in [HTC VIVE Eye Pro](https://www.vive.com/us/product/vive-pro/) in Unity, Which is a part of projects from Omni-Reality and Cognition Lab in University of Virginia (https://engineering.virginia.edu/omni-reality-and-cognition-lab).



## Prerequisite

1.  [HTC VIVE Eye Pro](https://www.vive.com/us/product/vive-pro/) with Tobii Eye Tracking system
2. [Python](https://www.python.org/) 3.6.3 ([Anaconda](https://www.anaconda.com/) version recommended)
3. [SteamVR](https://store.steampowered.com/steamvr) 
4. Finish the [Set up for the HTC VIVE Eye Pro](https://enterprise.vive.com/eu/setup/vive-pro/)

The HTC VIVE Eye Pro hardware (headset, controller) is from HTC VIVE, the integrated eye tracker is from Tobii, they have provided multiple accesses to the eye tracking data:

- [Tobii Pro SDK](http://developer.tobiipro.com/index.html): A general SDK for getting eye tracking data. This repository will use **Python** and **Unity** only.
- [Tobii XR SDK](https://vr.tobii.com/sdk/develop/unity/): SDK for Unity, developed by Tobii too 
- [Vive Eye Tracking SDK](https://developer.vive.com/resources/knowledgebase/vive-sranipal-sdk/) : SDK for eye tracking from HTC

All the three methods will be introduced in this document, sample code for both Python and Unity of Tobii Pro SDK is provided in the repository.



## Tobii Pro SDK

Website of Tobii Pro SDK: http://developer.tobiipro.com/index.html

### Python API

Set up Python API as http://developer.tobiipro.com/python/python-getting-started.html. 

Then run the [TobiiEyeTracking.py](TobiiEyeTracking.py) in the repository to collect the data externally.

If an eye tracker is successfully found, the data collecting is on going until the key 'q' is pressed (you can also change it to another key in the code). An output .csv data file (name with the start and end time) will be exported into the *out_dir* defined in the code.

 

 
