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
namespace Microsoft.MixedReality.Toolkit.Examples.Demos.EyeTracking
{
    public class Eye_tracking_log : MonoBehaviour
    {
        private string FILE_NAME = DateTime.Now.ToString("yyyyMMddTHHmmss") + ".csv";
        public GameObject cursor;

        Camera cam;
        Vector3 camfacing;

        private void write_title_text()
        {
#if WINDOWS_UWP

        string path = Path.Combine(Application.persistentDataPath, FILE_NAME);
        using (TextWriter writer = System.IO.File.CreateText(path))
        {
            writer.WriteLine("tofiletimestamp,date_time," + "Enabled," + "HitPosition.X," + "HitPosition.Y," + "HitPosition.Z," 
                + "HitNormal.X," + "HitNormal.Y," + "HitNormal.Z," + "GazeOrigin.X," + "GazeOrigin.Y," + "GazeOrigin.Z," 
                + "GazeDirection.X," + "GazeDirection.Y," + "GazeDirection.Z,"  + "HeadVelocity.X," + "HeadVelocity.Y," + "HeadVelocity.Z," 
                + "HeadMovementDirection.X," + "HeadMovementDirection.Y," + "HeadMovementDirection.Z," + "GazeCursor.X," + "GazeCursor.Y," 
                + "gazePos.X," + "gazePos.Y," + "gazePos.Z," 
                + "Camera.Position.x," + "Camera.Position.y," + "Camera.Position.z," 
                + "Camera.Rotation.w," + "Camera.Rotation.x," + "Camera.Rotation.y," + "Camera.Rotation.z,"  +"Camera.facing.x," + "Camera.facing.y," + "Camera.facing.z");
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
            if (gazeProvider != null)
            {

                using (StreamWriter writer =  new StreamWriter(path,true))
            {
                            
             writer.WriteLine(timestamp + "," + data_time + "," + gazeProvider.Enabled + ","
                + gazeProvider.HitPosition.x + "," + gazeProvider.HitPosition.y + "," + gazeProvider.HitPosition.z + ","
                + gazeProvider.HitNormal.x + "," + gazeProvider.HitNormal.y + "," + gazeProvider.HitNormal.z + ","
                 + gazeProvider.GazeOrigin.x + "," + gazeProvider.GazeOrigin.y + "," + gazeProvider.GazeOrigin.z + ","
                  + gazeProvider.GazeDirection.x + "," + gazeProvider.GazeDirection.y + "," + gazeProvider.GazeDirection.z + ","
                   + gazeProvider.HeadVelocity.x + "," + gazeProvider.HeadVelocity.y + "," + gazeProvider.HeadVelocity.z + ","
                    + gazeProvider.HeadMovementDirection.x + "," + gazeProvider.HeadMovementDirection.y + "," + gazeProvider.HeadMovementDirection.z + "," 
                    + viewPos.x + "," + viewPos.y + "," + gazePos.x + "," + gazePos.y + "," + gazePos.z + "," 
                    + cam.transform.position.x + "," + cam.transform.position.y + "," + cam.transform.position.z + "," 
                    + cam.transform.rotation.w + "," + cam.transform.rotation.x + "," + cam.transform.position.y + "," + cam.transform.position.z + ","
                     + camfacing.x + "," + camfacing.y + "," + camfacing.z);
            }
            }
#endif
        }



        // Start is called before the first frame update      
        void Start()
        {
            cam = GameObject.Find("MixedRealityPlayspace/Main Camera").GetComponent<Camera>();
            cursor = GameObject.Find("MixedRealityPlayspace/DefaultCursor2(Clone)");
            


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