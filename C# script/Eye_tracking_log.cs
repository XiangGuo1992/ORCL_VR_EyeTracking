using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;
//using System.Windows.Media;
#if WINDOWS_UWP
using Windows.Storage;
using Windows.System;
using System.Threading.Tasks;
using Windows.Storage.Streams;
using Microsoft.MixedReality.Toolkit.Input;
#endif
//namespace Microsoft.MixedReality.Toolkit.Examples.Demos.EyeTracking
namespace Microsoft.MixedReality.Toolkit.Utilities
{
    public class Eye_tracking_log : MonoBehaviour
    {
        private string FILE_NAME = DateTime.Now.ToString("yyyyMMddTHHmmss") + ".csv";
        public GameObject cursor;

        //hand joint definition https://microsoft.github.io/MixedRealityToolkit-Unity/api/Microsoft.MixedReality.Toolkit.Utilities.TrackedHandJoint.html


        Camera cam;
        Vector3 camfacing;

        private void write_title_text()
        {
#if WINDOWS_UWP

        string path = Path.Combine(Application.persistentDataPath, FILE_NAME);
        using (TextWriter writer = System.IO.File.CreateText(path))
        {
            writer.WriteLine("tofiletimestamp,date_time," + "Enabled,"  + "IsEyeCalibrationValid," + "IsEyeTrackingDataValid," +  "IsEyeTrackingEnabledAndValid,"  
                + "GazeOrigin.X," + "GazeOrigin.Y," + "GazeOrigin.Z," 
                + "GazeDirection.X," + "GazeDirection.Y," + "GazeDirection.Z,"  + "HeadVelocity.X," + "HeadVelocity.Y," + "HeadVelocity.Z," 
                + "HeadMovementDirection.X," + "HeadMovementDirection.Y," + "HeadMovementDirection.Z," + "GazeCursor.X," + "GazeCursor.Y," 
                + "gazePos.X," + "gazePos.Y," + "gazePos.Z," 
                + "Camera.Position.x," + "Camera.Position.y," + "Camera.Position.z," 
                + "Camera.Rotation.w," + "Camera.Rotation.x," + "Camera.Rotation.y," + "Camera.Rotation.z,"  +"Camera.facing.x," + "Camera.facing.y," + "Camera.facing.z," 
                +   "RightIndexDistalJoint.position.x," + "RightIndexDistalJoint.position.y," + "RightIndexDistalJoint.position.z,"  
                             + "RightIndexKnuckle.position.x," + "RightIndexKnuckle.position.y," + "RightIndexKnuckle.position.z,"  
                             + "RightIndexMetacarpal.position.x," + "RightIndexMetacarpal.position.y," + "RightIndexMetacarpal.position.z,"  
                             + "RightIndexTip.position.x," + "RightIndexTip.position.y," + "RightIndexTip.position.z," 
                             
                             + "RightMiddleDistalJoint.position.x," + "RightMiddleDistalJoint.position.y," + "RightMiddleDistalJoint.position.z,"  
                             + "RightMiddleKnuckle.position.x," + "RightMiddleKnuckle.position.y," + "RightMiddleKnuckle.position.z,"  
                             + "RightMiddleMetacarpal.position.x," + "RightMiddleMetacarpal.position.y," + "RightMiddleMetacarpal.position.z,"  
                             + "RightMiddleMiddleJoint.position.x," + "RightMiddleMiddleJoint.position.y," + "RightMiddleMiddleJoint.position.z,"  
                             + "RightMiddleTip.position.x," + "RightMiddleTip.position.y," + "RightMiddleTip.position.z,"  

                             + "RightPinkyDistalJoint.position.x," + "RightPinkyDistalJoint.position.y," + "RightPinkyDistalJoint.position.z,"  
                             + "RightPinkyKnuckle.position.x," + "RightPinkyKnuckle.position.y," + "RightPinkyKnuckle.position.z,"  
                             + "RightPinkyMetacarpal.position.x," + "RightPinkyMetacarpal.position.y," + "RightPinkyMetacarpal.position.z,"  
                             + "RightPinkyMiddleJoint.position.x," + "RightPinkyMiddleJoint.position.y," + "RightPinkyMiddleJoint.position.z,"  
                             + "RightPinkyTip.position.x," + "RightPinkyTip.position.y," + "RightPinkyTip.position.z,"  

                             + "RightRingDistalJoint.position.x," + "RightRingDistalJoint.position.y," + "RightRingDistalJoint.position.z,"  
                             + "RightRingKnuckle.position.x," + "RightRingKnuckle.position.y," + "RightRingKnuckle.position.z,"  
                             + "RightRingMetacarpal.position.x," + "RightRingMetacarpal.position.y," + "RightRingMetacarpal.position.z,"  
                             + "RightRingMiddleJoint.position.x," + "RightRingMiddleJoint.position.y," + "RightRingMiddleJoint.position.z,"  
                             + "RightRingTip.position.x," + "RightRingTip.position.y," + "RightRingTip.position.z,"  

                             + "RightThumbDistalJoint.position.x," + "RightThumbDistalJoint.position.y," + "RightThumbDistalJoint.position.z,"  
                             + "RightThumbMetacarpalJoint.position.x," + "RightThumbMetacarpalJoint.position.y," + "RightThumbMetacarpalJoint.position.z," 
                             + "RightThumbProximalJoint.position.x," + "RightThumbProximalJoint.position.y," + "RightThumbProximalJoint.position.z," 
                             + "RightThumbTip.position.x," + "RightThumbTip.position.y," + "RightThumbTip.position.z,"  
                             
                             + "RightPalm.position.x," + "RightPalm.position.y," + "RightPalm.position.z,"  
                             + "RightWrist.position.x," + "RightWrist.position.y," + "RightWrist.position.z,"  

                             +   "LeftIndexDistalJoint.position.x," + "LeftIndexDistalJoint.position.y," + "LeftIndexDistalJoint.position.z,"  
                             + "LeftIndexKnuckle.position.x," + "LeftIndexKnuckle.position.y," + "LeftIndexKnuckle.position.z,"  
                             + "LeftIndexMetacarpal.position.x," + "LeftIndexMetacarpal.position.y," + "LeftIndexMetacarpal.position.z,"  
                             + "LeftIndexTip.position.x," + "LeftIndexTip.position.y," + "LeftIndexTip.position.z," 
                             
                             + "LeftMiddleDistalJoint.position.x," + "LeftMiddleDistalJoint.position.y," + "LeftMiddleDistalJoint.position.z,"  
                             + "LeftMiddleKnuckle.position.x," + "LeftMiddleKnuckle.position.y," + "LeftMiddleKnuckle.position.z,"  
                             + "LeftMiddleMetacarpal.position.x," + "LeftMiddleMetacarpal.position.y," + "LeftMiddleMetacarpal.position.z,"  
                             + "LeftMiddleMiddleJoint.position.x," + "LeftMiddleMiddleJoint.position.y," + "LeftMiddleMiddleJoint.position.z,"  
                             + "LeftMiddleTip.position.x," + "LeftMiddleTip.position.y," + "LeftMiddleTip.position.z,"  

                             + "LeftPinkyDistalJoint.position.x," + "LeftPinkyDistalJoint.position.y," + "LeftPinkyDistalJoint.position.z,"  
                             + "LeftPinkyKnuckle.position.x," + "LeftPinkyKnuckle.position.y," + "LeftPinkyKnuckle.position.z,"  
                             + "LeftPinkyMetacarpal.position.x," + "LeftPinkyMetacarpal.position.y," + "LeftPinkyMetacarpal.position.z,"  
                             + "LeftPinkyMiddleJoint.position.x," + "LeftPinkyMiddleJoint.position.y," + "LeftPinkyMiddleJoint.position.z,"  
                             + "LeftPinkyTip.position.x," + "LeftPinkyTip.position.y," + "LeftPinkyTip.position.z,"  

                             + "LeftRingDistalJoint.position.x," + "LeftRingDistalJoint.position.y," + "LeftRingDistalJoint.position.z,"  
                             + "LeftRingKnuckle.position.x," + "LeftRingKnuckle.position.y," + "LeftRingKnuckle.position.z,"  
                             + "LeftRingMetacarpal.position.x," + "LeftRingMetacarpal.position.y," + "LeftRingMetacarpal.position.z,"  
                             + "LeftRingMiddleJoint.position.x," + "LeftRingMiddleJoint.position.y," + "LeftRingMiddleJoint.position.z,"  
                             + "LeftRingTip.position.x," + "LeftRingTip.position.y," + "LeftRingTip.position.z,"  

                             + "LeftThumbDistalJoint.position.x," + "LeftThumbDistalJoint.position.y," + "LeftThumbDistalJoint.position.z,"  
                             + "LeftThumbMetacarpalJoint.position.x," + "LeftThumbMetacarpalJoint.position.y," + "LeftThumbMetacarpalJoint.position.z," 
                             + "LeftThumbProximalJoint.position.x," + "LeftThumbProximalJoint.position.y," + "LeftThumbProximalJoint.position.z," 
                             + "LeftThumbTip.position.x," + "LeftThumbTip.position.y," + "LeftThumbTip.position.z,"  
                             
                             + "LeftPalm.position.x," + "LeftPalm.position.y," + "LeftPalm.position.z,"  
                             + "LeftWrist.position.x," + "LeftWrist.position.y," + "LeftWrist.position.z,"  
                             
                             );
        }
           
#endif
        }



        private void write_text()
        {
            var timestamp = DateTime.Now.ToFileTime();
            string data_time = DateTime.Now.ToString("yyyyMMddTHHmmss");
            Vector3 gazePos = cursor.transform.position;
            Vector3 viewPos = cam.WorldToViewportPoint(gazePos);
            Vector3 camfacing = cam.transform.forward;

#if WINDOWS_UWP
            string path = Path.Combine(Application.persistentDataPath, FILE_NAME);
            var gazeProvider = CoreServices.InputSystem?.GazeProvider;


            
            var handJointService = CoreServices.GetInputSystemDataProvider<IMixedRealityHandJointService>();
            
            

            if (gazeProvider != null)
            {   
                
                if (handJointService != null)
                {
                        //right hand
                        Transform RightIndexDistalJoint  = handJointService.RequestJointTransform(TrackedHandJoint.IndexDistalJoint, Handedness.Right);
                        Transform RightIndexKnuckle  = handJointService.RequestJointTransform(TrackedHandJoint.IndexKnuckle, Handedness.Right);
                        Transform RightIndexMetacarpal  = handJointService.RequestJointTransform(TrackedHandJoint.IndexMetacarpal, Handedness.Right);
                        Transform RightIndexTip  = handJointService.RequestJointTransform(TrackedHandJoint.IndexTip, Handedness.Right);

                        Transform RightMiddleDistalJoint  = handJointService.RequestJointTransform(TrackedHandJoint.MiddleDistalJoint, Handedness.Right);
                        Transform RightMiddleKnuckle  = handJointService.RequestJointTransform(TrackedHandJoint.MiddleKnuckle, Handedness.Right);
                        Transform RightMiddleMetacarpal  = handJointService.RequestJointTransform(TrackedHandJoint.MiddleMetacarpal, Handedness.Right);
                        Transform RightMiddleMiddleJoint  = handJointService.RequestJointTransform(TrackedHandJoint.MiddleMiddleJoint, Handedness.Right);
                        Transform RightMiddleTip  = handJointService.RequestJointTransform(TrackedHandJoint.MiddleTip, Handedness.Right);

                        Transform RightPinkyDistalJoint  = handJointService.RequestJointTransform(TrackedHandJoint.PinkyDistalJoint, Handedness.Right);
                        Transform RightPinkyKnuckle  = handJointService.RequestJointTransform(TrackedHandJoint.PinkyKnuckle, Handedness.Right);
                        Transform RightPinkyMetacarpal  = handJointService.RequestJointTransform(TrackedHandJoint.PinkyMetacarpal, Handedness.Right);
                        Transform RightPinkyMiddleJoint  = handJointService.RequestJointTransform(TrackedHandJoint.PinkyMiddleJoint, Handedness.Right);
                        Transform RightPinkyTip  = handJointService.RequestJointTransform(TrackedHandJoint.PinkyTip, Handedness.Right);

                        Transform RightRingDistalJoint  = handJointService.RequestJointTransform(TrackedHandJoint.RingDistalJoint, Handedness.Right);
                        Transform RightRingKnuckle  = handJointService.RequestJointTransform(TrackedHandJoint.RingKnuckle, Handedness.Right);
                        Transform RightRingMetacarpal  = handJointService.RequestJointTransform(TrackedHandJoint.RingMetacarpal, Handedness.Right);
                        Transform RightRingMiddleJoint  = handJointService.RequestJointTransform(TrackedHandJoint.RingMiddleJoint, Handedness.Right);
                        Transform RightRingTip  = handJointService.RequestJointTransform(TrackedHandJoint.RingTip, Handedness.Right);

                        Transform RightThumbDistalJoint  = handJointService.RequestJointTransform(TrackedHandJoint.ThumbDistalJoint, Handedness.Right);
                        Transform RightThumbMetacarpalJoint  = handJointService.RequestJointTransform(TrackedHandJoint.ThumbMetacarpalJoint, Handedness.Right);
                        Transform RightThumbProximalJoint  = handJointService.RequestJointTransform(TrackedHandJoint.ThumbProximalJoint, Handedness.Right);
                        Transform RightThumbTip  = handJointService.RequestJointTransform(TrackedHandJoint.ThumbTip, Handedness.Right);

                        Transform RightPalm  = handJointService.RequestJointTransform(TrackedHandJoint.Palm, Handedness.Right);
                        Transform RightWrist  = handJointService.RequestJointTransform(TrackedHandJoint.Wrist, Handedness.Right);

                        //left hand
                        Transform LeftIndexDistalJoint  = handJointService.RequestJointTransform(TrackedHandJoint.IndexDistalJoint, Handedness.Left);
                        Transform LeftIndexKnuckle  = handJointService.RequestJointTransform(TrackedHandJoint.IndexKnuckle, Handedness.Left);
                        Transform LeftIndexMetacarpal  = handJointService.RequestJointTransform(TrackedHandJoint.IndexMetacarpal, Handedness.Left);
                        Transform LeftIndexTip  = handJointService.RequestJointTransform(TrackedHandJoint.IndexTip, Handedness.Left);

                        Transform LeftMiddleDistalJoint  = handJointService.RequestJointTransform(TrackedHandJoint.MiddleDistalJoint, Handedness.Left);
                        Transform LeftMiddleKnuckle  = handJointService.RequestJointTransform(TrackedHandJoint.MiddleKnuckle, Handedness.Left);
                        Transform LeftMiddleMetacarpal  = handJointService.RequestJointTransform(TrackedHandJoint.MiddleMetacarpal, Handedness.Left);
                        Transform LeftMiddleMiddleJoint  = handJointService.RequestJointTransform(TrackedHandJoint.MiddleMiddleJoint, Handedness.Left);
                        Transform LeftMiddleTip  = handJointService.RequestJointTransform(TrackedHandJoint.MiddleTip, Handedness.Left);

                        Transform LeftPinkyDistalJoint  = handJointService.RequestJointTransform(TrackedHandJoint.PinkyDistalJoint, Handedness.Left);
                        Transform LeftPinkyKnuckle  = handJointService.RequestJointTransform(TrackedHandJoint.PinkyKnuckle, Handedness.Left);
                        Transform LeftPinkyMetacarpal  = handJointService.RequestJointTransform(TrackedHandJoint.PinkyMetacarpal, Handedness.Left);
                        Transform LeftPinkyMiddleJoint  = handJointService.RequestJointTransform(TrackedHandJoint.PinkyMiddleJoint, Handedness.Left);
                        Transform LeftPinkyTip  = handJointService.RequestJointTransform(TrackedHandJoint.PinkyTip, Handedness.Left);

                        Transform LeftRingDistalJoint  = handJointService.RequestJointTransform(TrackedHandJoint.RingDistalJoint, Handedness.Left);
                        Transform LeftRingKnuckle  = handJointService.RequestJointTransform(TrackedHandJoint.RingKnuckle, Handedness.Left);
                        Transform LeftRingMetacarpal  = handJointService.RequestJointTransform(TrackedHandJoint.RingMetacarpal, Handedness.Left);
                        Transform LeftRingMiddleJoint  = handJointService.RequestJointTransform(TrackedHandJoint.RingMiddleJoint, Handedness.Left);
                        Transform LeftRingTip  = handJointService.RequestJointTransform(TrackedHandJoint.RingTip, Handedness.Left);

                        Transform LeftThumbDistalJoint  = handJointService.RequestJointTransform(TrackedHandJoint.ThumbDistalJoint, Handedness.Left);
                        Transform LeftThumbMetacarpalJoint  = handJointService.RequestJointTransform(TrackedHandJoint.ThumbMetacarpalJoint, Handedness.Left);
                        Transform LeftThumbProximalJoint  = handJointService.RequestJointTransform(TrackedHandJoint.ThumbProximalJoint, Handedness.Left);
                        Transform LeftThumbTip  = handJointService.RequestJointTransform(TrackedHandJoint.ThumbTip, Handedness.Left);

                        Transform LeftPalm  = handJointService.RequestJointTransform(TrackedHandJoint.Palm, Handedness.Left);
                        Transform LeftWrist  = handJointService.RequestJointTransform(TrackedHandJoint.Wrist, Handedness.Left);

                        using (StreamWriter writer =  new StreamWriter(path,true))
                    {
                            
                     writer.WriteLine(timestamp + "," + data_time + "," + gazeProvider.Enabled + "," + CoreServices.InputSystem.EyeGazeProvider.IsEyeCalibrationValid + "," + CoreServices.InputSystem.EyeGazeProvider.IsEyeTrackingDataValid + "," 
                     + CoreServices.InputSystem.EyeGazeProvider.IsEyeTrackingEnabledAndValid + "," 
                      + gazeProvider.GazeOrigin.x + "," + gazeProvider.GazeOrigin.y + "," + gazeProvider.GazeOrigin.z + ","
                          + gazeProvider.GazeDirection.x + "," + gazeProvider.GazeDirection.y + "," + gazeProvider.GazeDirection.z + ","
                           + gazeProvider.HeadVelocity.x + "," + gazeProvider.HeadVelocity.y + "," + gazeProvider.HeadVelocity.z + ","
                            + gazeProvider.HeadMovementDirection.x + "," + gazeProvider.HeadMovementDirection.y + "," + gazeProvider.HeadMovementDirection.z + "," 
                            + viewPos.x + "," + viewPos.y + "," + gazePos.x + "," + gazePos.y + "," + gazePos.z + "," 
                            + cam.transform.position.x + "," + cam.transform.position.y + "," + cam.transform.position.z + "," 
                            + cam.transform.rotation.w + "," + cam.transform.rotation.x + "," + cam.transform.position.y + "," + cam.transform.position.z + ","
                             + camfacing.x + "," + camfacing.y + "," + camfacing.z + "," 

                             + RightIndexDistalJoint.position.x + "," + RightIndexDistalJoint.position.y + "," + RightIndexDistalJoint.position.z + ","  
                             + RightIndexKnuckle.position.x + "," + RightIndexKnuckle.position.y + "," + RightIndexKnuckle.position.z + ","  
                             + RightIndexMetacarpal.position.x + "," + RightIndexMetacarpal.position.y + "," + RightIndexMetacarpal.position.z + ","  
                             + RightIndexTip.position.x + "," + RightIndexTip.position.y + "," + RightIndexTip.position.z + "," 
                             
                             + RightMiddleDistalJoint.position.x + "," + RightMiddleDistalJoint.position.y + "," + RightMiddleDistalJoint.position.z + ","  
                             + RightMiddleKnuckle.position.x + "," + RightMiddleKnuckle.position.y + "," + RightMiddleKnuckle.position.z + ","  
                             + RightMiddleMetacarpal.position.x + "," + RightMiddleMetacarpal.position.y + "," + RightMiddleMetacarpal.position.z + ","  
                             + RightMiddleMiddleJoint.position.x + "," + RightMiddleMiddleJoint.position.y + "," + RightMiddleMiddleJoint.position.z + ","  
                             + RightMiddleTip.position.x + "," + RightMiddleTip.position.y + "," + RightMiddleTip.position.z + ","  

                             + RightPinkyDistalJoint.position.x + "," + RightPinkyDistalJoint.position.y + "," + RightPinkyDistalJoint.position.z + ","  
                             + RightPinkyKnuckle.position.x + "," + RightPinkyKnuckle.position.y + "," + RightPinkyKnuckle.position.z + ","  
                             + RightPinkyMetacarpal.position.x + "," + RightPinkyMetacarpal.position.y + "," + RightPinkyMetacarpal.position.z + ","  
                             + RightPinkyMiddleJoint.position.x + "," + RightPinkyMiddleJoint.position.y + "," + RightPinkyMiddleJoint.position.z + ","  
                             + RightPinkyTip.position.x + "," + RightPinkyTip.position.y + "," + RightPinkyTip.position.z + ","  

                             + RightRingDistalJoint.position.x + "," + RightRingDistalJoint.position.y + "," + RightRingDistalJoint.position.z + ","  
                             + RightRingKnuckle.position.x + "," + RightRingKnuckle.position.y + "," + RightRingKnuckle.position.z + ","  
                             + RightRingMetacarpal.position.x + "," + RightRingMetacarpal.position.y + "," + RightRingMetacarpal.position.z + ","  
                             + RightRingMiddleJoint.position.x + "," + RightRingMiddleJoint.position.y + "," + RightRingMiddleJoint.position.z + ","  
                             + RightRingTip.position.x + "," + RightRingTip.position.y + "," + RightRingTip.position.z + ","  

                             + RightThumbDistalJoint.position.x + "," + RightThumbDistalJoint.position.y + "," + RightThumbDistalJoint.position.z + ","  
                             + RightThumbMetacarpalJoint.position.x + "," + RightThumbMetacarpalJoint.position.y + "," + RightThumbMetacarpalJoint.position.z + "," 
                             + RightThumbProximalJoint.position.x + "," + RightThumbProximalJoint.position.y + "," + RightThumbProximalJoint.position.z + "," 
                             + RightThumbTip.position.x + "," + RightThumbTip.position.y + "," + RightThumbTip.position.z + ","  
                             
                             + RightPalm.position.x + "," + RightPalm.position.y + "," + RightPalm.position.z + ","  
                             + RightWrist.position.x + "," + RightWrist.position.y + "," + RightWrist.position.z + ","  

                             + LeftIndexDistalJoint.position.x + "," + LeftIndexDistalJoint.position.y + "," + LeftIndexDistalJoint.position.z + ","  
                             + LeftIndexKnuckle.position.x + "," + LeftIndexKnuckle.position.y + "," + LeftIndexKnuckle.position.z + ","  
                             + LeftIndexMetacarpal.position.x + "," + LeftIndexMetacarpal.position.y + "," + LeftIndexMetacarpal.position.z + ","  
                             + LeftIndexTip.position.x + "," + LeftIndexTip.position.y + "," + LeftIndexTip.position.z + "," 
                             
                             + LeftMiddleDistalJoint.position.x + "," + LeftMiddleDistalJoint.position.y + "," + LeftMiddleDistalJoint.position.z + ","  
                             + LeftMiddleKnuckle.position.x + "," + LeftMiddleKnuckle.position.y + "," + LeftMiddleKnuckle.position.z + ","  
                             + LeftMiddleMetacarpal.position.x + "," + LeftMiddleMetacarpal.position.y + "," + LeftMiddleMetacarpal.position.z + ","  
                             + LeftMiddleMiddleJoint.position.x + "," + LeftMiddleMiddleJoint.position.y + "," + LeftMiddleMiddleJoint.position.z + ","  
                             + LeftMiddleTip.position.x + "," + LeftMiddleTip.position.y + "," + LeftMiddleTip.position.z + ","  

                             + LeftPinkyDistalJoint.position.x + "," + LeftPinkyDistalJoint.position.y + "," + LeftPinkyDistalJoint.position.z + ","  
                             + LeftPinkyKnuckle.position.x + "," + LeftPinkyKnuckle.position.y + "," + LeftPinkyKnuckle.position.z + ","  
                             + LeftPinkyMetacarpal.position.x + "," + LeftPinkyMetacarpal.position.y + "," + LeftPinkyMetacarpal.position.z + ","  
                             + LeftPinkyMiddleJoint.position.x + "," + LeftPinkyMiddleJoint.position.y + "," + LeftPinkyMiddleJoint.position.z + ","  
                             + LeftPinkyTip.position.x + "," + LeftPinkyTip.position.y + "," + LeftPinkyTip.position.z + ","  

                             + LeftRingDistalJoint.position.x + "," + LeftRingDistalJoint.position.y + "," + LeftRingDistalJoint.position.z + ","  
                             + LeftRingKnuckle.position.x + "," + LeftRingKnuckle.position.y + "," + LeftRingKnuckle.position.z + ","  
                             + LeftRingMetacarpal.position.x + "," + LeftRingMetacarpal.position.y + "," + LeftRingMetacarpal.position.z + ","  
                             + LeftRingMiddleJoint.position.x + "," + LeftRingMiddleJoint.position.y + "," + LeftRingMiddleJoint.position.z + ","  
                             + LeftRingTip.position.x + "," + LeftRingTip.position.y + "," + LeftRingTip.position.z + ","  

                             + LeftThumbDistalJoint.position.x + "," + LeftThumbDistalJoint.position.y + "," + LeftThumbDistalJoint.position.z + ","  
                             + LeftThumbMetacarpalJoint.position.x + "," + LeftThumbMetacarpalJoint.position.y + "," + LeftThumbMetacarpalJoint.position.z + "," 
                             + LeftThumbProximalJoint.position.x + "," + LeftThumbProximalJoint.position.y + "," + LeftThumbProximalJoint.position.z + "," 
                             + LeftThumbTip.position.x + "," + LeftThumbTip.position.y + "," + LeftThumbTip.position.z + ","  
                             
                             + LeftPalm.position.x + "," + LeftPalm.position.y + "," + LeftPalm.position.z + ","  
                             + LeftWrist.position.x + "," + LeftWrist.position.y + "," + LeftWrist.position.z + "," 
                            );
                    }
                }
                else 
                {
                    using (StreamWriter writer =  new StreamWriter(path,true))
                    {
                            
                     writer.WriteLine(timestamp + "," + data_time + "," + gazeProvider.Enabled + "," + CoreServices.InputSystem.EyeGazeProvider.IsEyeCalibrationValid + "," + CoreServices.InputSystem.EyeGazeProvider.IsEyeTrackingDataValid + "," 
                     + CoreServices.InputSystem.EyeGazeProvider.IsEyeTrackingEnabledAndValid + "," 
                        + gazeProvider.HitPosition.x + "," + gazeProvider.HitPosition.y + "," + gazeProvider.HitPosition.z + ","
                        + gazeProvider.HitNormal.x + "," + gazeProvider.HitNormal.y + "," + gazeProvider.HitNormal.z + ","
                         + gazeProvider.GazeOrigin.x + "," + gazeProvider.GazeOrigin.y + "," + gazeProvider.GazeOrigin.z + ","
                          + gazeProvider.GazeDirection.x + "," + gazeProvider.GazeDirection.y + "," + gazeProvider.GazeDirection.z + ","
                           + gazeProvider.HeadVelocity.x + "," + gazeProvider.HeadVelocity.y + "," + gazeProvider.HeadVelocity.z + ","
                            + gazeProvider.HeadMovementDirection.x + "," + gazeProvider.HeadMovementDirection.y + "," + gazeProvider.HeadMovementDirection.z + "," 
                            + viewPos.x + "," + viewPos.y + "," + gazePos.x + "," + gazePos.y + "," + gazePos.z + "," 
                            + cam.transform.position.x + "," + cam.transform.position.y + "," + cam.transform.position.z + "," 
                            + cam.transform.rotation.w + "," + cam.transform.rotation.x + "," + cam.transform.position.y + "," + cam.transform.position.z + ","
                             + camfacing.x + "," + camfacing.y + "," + camfacing.z ) ;
                    }
                }
                    
            }
#endif
        }



        // Start is called before the first frame update      
        void Start()
        {
            cam = GameObject.Find("MixedRealityPlayspace/Main Camera").GetComponent<Camera>();
            cursor = GameObject.Find("MixedRealityPlayspace/EyeGazeCursor(Clone)");
            


#if WINDOWS_UWP

                write_title_text();

#endif
        }

        // Update is called once per frame
        // private int frames = 0;
        void Update()
        {
            
            
            /*   
               frames++;

               if (frames % 10 == 0)
               {
       #if WINDOWS_UWP

           write_text();

       #endif
               }
            */

#if WINDOWS_UWP

        write_text();

#endif


        }

    }
}