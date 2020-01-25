# -*- coding: utf-8 -*-
"""
Created on Thu Jan 23 17:03:02 2020

@author: Xiang Guo
"""

import os
import xml.etree.ElementTree as ET
import pandas as pd
os.chdir('C:\\research\\VR-EyeTracking')
file_name = 'vr_data_20191204T233149.xml'

tree = ET.parse(file_name)
root = tree.getroot()

GazeData_TimeStamp, Pose_Position, Pose_Rotation, Pose_Valid = ([] for i in range(4))

LeftGazeDirection, LeftGazeDirectionValid, LeftGazeOrigin, LeftGazeOriginValid,\
LeftPupilDiameter, LeftPupilDiameterValid, LeftGazeRayWorldOrigin, LeftGazeRayWorldDirection,\
LeftGazeRayWorldValid  = ([] for i in range(9))

RightGazeDirection, RightGazeDirectionValid, RightGazeOrigin, RightGazeOriginValid,\
RightPupilDiameter, RightPupilDiameterValid, RightGazeRayWorldOrigin, RightGazeRayWorldDirection,\
RightGazeRayWorldValid = ([] for i in range(9))

CombinedGazeRayWorldOrigin, CombinedGazeRayWorldDirection, CombinedGazeRayWorldValid = ([] for i in range(3))

DeviceTimeStamp, SystemTimeStamp = [],[]

OriginalLeftGazeDirection, OriginalLeftGazeDirectionValid, OriginalLeftGazeOriginPositionInHMD, OriginalLeftGazeOriginPositionInHMDValid,\
OriginalLeftPupilDiameter, OriginalLeftPupilDiameterValid, OriginalLeftPupilPositionInTrackingArea,\
OriginalLeftPupilPositionInTrackingAreaValid = ([] for i in range(8))

OriginalRightGazeDirection, OriginalRightGazeDirectionValid, OriginalRightGazeOriginPositionInHMD, OriginalRightGazeOriginPositionInHMDValid,\
OriginalRightPupilDiameter, OriginalRightPupilDiameterValid, OriginalRightPupilPositionInTrackingArea,\
OriginalRightPupilPositionInTrackingAreaValid = ([] for i in range(8))


for gazedata in root:
    gaze_data_TimeStamp = gazedata.attrib['TimeStamp']
    GazeData_TimeStamp.append(gaze_data_TimeStamp)
    
    # pose
    pose = gazedata[0]
    pose_position = pose.attrib['Position']
    pose_rotation = pose.attrib['Rotation']
    pose_valid = pose.attrib['Valid']
    Pose_Position.append(pose_position)
    Pose_Rotation.append(pose_rotation)
    Pose_Valid.append(pose_valid)
    
    #left   
    left = gazedata[1]
    left_gaze_direction = left[0].attrib['Value']
    left_gaze_direction_valid = left[0].attrib['Valid']
    left_gaze_origin = left[1].attrib['Value']
    left_gaze_origin_valid = left[1].attrib['Valid']
    left_pupil_diameter = left[2].attrib['Value']
    left_pupil_diameter_valid = left[2].attrib['Valid']
    left_gaze_ray_world_origin = left[3].attrib['Origin']
    left_gaze_ray_world_direction = left[3].attrib['Direction']
    left_gaze_ray_world_valid = left[3].attrib['Valid']
    
    LeftGazeDirection.append(left_gaze_direction)
    LeftGazeDirectionValid.append(left_gaze_direction_valid)
    LeftGazeOrigin.append(left_gaze_origin)
    LeftGazeOriginValid.append(left_gaze_origin_valid)
    LeftPupilDiameter.append(left_pupil_diameter)
    LeftPupilDiameterValid.append(left_pupil_diameter_valid)
    LeftGazeRayWorldOrigin.append(left_gaze_ray_world_origin)
    LeftGazeRayWorldDirection.append(left_gaze_ray_world_direction)
    LeftGazeRayWorldValid.append(left_gaze_ray_world_valid)
    
    #right
    right = gazedata[2]
    right_gaze_direction = right[0].attrib['Value']
    right_gaze_direction_valid = right[0].attrib['Valid']
    right_gaze_origin = right[1].attrib['Value']
    right_gaze_origin_valid = right[1].attrib['Valid']
    right_pupil_diameter = right[2].attrib['Value']
    right_pupil_diameter_valid = right[2].attrib['Valid']
    right_gaze_ray_world_origin = right[3].attrib['Origin']
    right_gaze_ray_world_direction = right[3].attrib['Direction']
    right_gaze_ray_world_valid = right[3].attrib['Valid']
    
    RightGazeDirection.append(right_gaze_direction)
    RightGazeDirectionValid.append(right_gaze_direction_valid)
    RightGazeOrigin.append(right_gaze_origin)
    RightGazeOriginValid.append(right_gaze_origin_valid)
    RightPupilDiameter.append(right_pupil_diameter)
    RightPupilDiameterValid.append(right_pupil_diameter_valid)
    RightGazeRayWorldOrigin.append(right_gaze_ray_world_origin)
    RightGazeRayWorldDirection.append(right_gaze_ray_world_direction)
    RightGazeRayWorldValid.append(right_gaze_ray_world_valid)        
    
    #combined
    combinedgazerayworld = gazedata[3]
    combinedgazerayworld_origin = combinedgazerayworld.attrib['Origin']
    combinedgazerayworld_direction = combinedgazerayworld.attrib['Direction']
    combinedgazerayworld_valid = combinedgazerayworld.attrib['Valid']
    CombinedGazeRayWorldOrigin.append(combinedgazerayworld_origin)
    CombinedGazeRayWorldDirection.append(combinedgazerayworld_direction)
    CombinedGazeRayWorldValid.append(combinedgazerayworld_valid) 
    
    originalgaze = gazedata[4]
    originalgaze_device_TimeStamp = originalgaze.attrib['DeviceTimeStamp']
    originalgaze_system_TimeStamp = originalgaze.attrib['SystemTimeStamp']
    DeviceTimeStamp.append(originalgaze_device_TimeStamp)
    SystemTimeStamp.append(originalgaze_system_TimeStamp)

    #Original Left
    original_left = originalgaze[0]
    original_left_gaze_direction = original_left[0].attrib['UnitVector']
    original_left_gaze_direction_valid = original_left[0].attrib['Validity']
    original_left_gaze_origin_inHMD = original_left[1].attrib['PositionInHMDCoordinates']
    original_left_gaze_origin_inHMD_valid = original_left[1].attrib['Validity']
    original_left_pupil_diameter = original_left[2].attrib['PupilDiameter']
    original_left_pupil_diameter_valid = original_left[2].attrib['Validity']
    original_left_gaze_PupilPosition = original_left[3].attrib['PositionInTrackingArea']
    original_left_gaze_PupilPosition_valid = original_left[3].attrib['Validity']
    
    OriginalLeftGazeDirection.append(original_left_gaze_direction)
    OriginalLeftGazeDirectionValid.append(original_left_gaze_direction_valid)
    OriginalLeftGazeOriginPositionInHMD.append(original_left_gaze_origin_inHMD)
    OriginalLeftGazeOriginPositionInHMDValid.append(original_left_gaze_origin_inHMD_valid)
    OriginalLeftPupilDiameter.append(original_left_pupil_diameter)
    OriginalLeftPupilDiameterValid.append(original_left_pupil_diameter_valid)
    OriginalLeftPupilPositionInTrackingArea.append(original_left_gaze_PupilPosition)
    OriginalLeftPupilPositionInTrackingAreaValid.append(original_left_gaze_PupilPosition_valid)
    
    original_right = originalgaze[1]
    original_right_gaze_direction = original_right[0].attrib['UnitVector']
    original_right_gaze_direction_valid = original_right[0].attrib['Validity']
    original_right_gaze_origin_inHMD = original_right[1].attrib['PositionInHMDCoordinates']
    original_right_gaze_origin_inHMD_valid = original_right[1].attrib['Validity']
    original_right_pupil_diameter = original_right[2].attrib['PupilDiameter']
    original_right_pupil_diameter_valid = original_right[2].attrib['Validity']
    original_right_gaze_PupilPosition = original_right[3].attrib['PositionInTrackingArea']
    original_right_gaze_PupilPosition_valid = original_right[3].attrib['Validity']  
    
    OriginalRightGazeDirection.append(original_right_gaze_direction)
    OriginalRightGazeDirectionValid.append(original_right_gaze_direction_valid)
    OriginalRightGazeOriginPositionInHMD.append(original_right_gaze_origin_inHMD)
    OriginalRightGazeOriginPositionInHMDValid.append(original_right_gaze_origin_inHMD_valid)
    OriginalRightPupilDiameter.append(original_right_pupil_diameter)
    OriginalRightPupilDiameterValid.append(original_right_pupil_diameter_valid)
    OriginalRightPupilPositionInTrackingArea.append(original_right_gaze_PupilPosition)
    OriginalRightPupilPositionInTrackingAreaValid.append(original_right_gaze_PupilPosition_valid)



AdjustedTime = [(int(i)-int(DeviceTimeStamp[0]))/1000000 for i in DeviceTimeStamp]    
d =  {'AdjustedTime':AdjustedTime,  'DeviceTimeStamp': DeviceTimeStamp, 'SystemTimeStamp':SystemTimeStamp,\
      'GazeData_TimeStamp': GazeData_TimeStamp, 'Pose_Position':Pose_Position, \
      'Pose_Rotation': Pose_Rotation, 'Pose_Valid':Pose_Valid, 'LeftGazeDirection':LeftGazeDirection, \
      'LeftGazeDirectionValid': LeftGazeDirectionValid, 'LeftGazeOrigin': LeftGazeOrigin, \
      'LeftGazeOriginValid': LeftGazeOriginValid, 'LeftPupilDiameter': LeftPupilDiameter, \
      'LeftPupilDiameterValid':LeftPupilDiameterValid, 'LeftGazeRayWorldOrigin': LeftGazeRayWorldOrigin, \
      'LeftGazeRayWorldDirection': LeftGazeRayWorldDirection, 'LeftGazeRayWorldValid':LeftGazeRayWorldValid,\
      'RightGazeDirection':RightGazeDirection, 'RightGazeDirection':RightGazeDirection, \
      'RightGazeDirectionValid': RightGazeDirectionValid, 'RightGazeOrigin':RightGazeOrigin, \
      'RightGazeOriginValid': RightGazeOriginValid, 'RightPupilDiameter': RightPupilDiameter, \
      'RightPupilDiameterValid': RightPupilDiameterValid, 'RightGazeRayWorldOrigin':RightGazeRayWorldOrigin,\
      'RightGazeRayWorldDirection': RightGazeRayWorldDirection, 'RightGazeRayWorldValid':RightGazeRayWorldValid,\
      'CombinedGazeRayWorldOrigin': CombinedGazeRayWorldOrigin, 'CombinedGazeRayWorldDirection': CombinedGazeRayWorldDirection, \
      'CombinedGazeRayWorldValid': CombinedGazeRayWorldValid, 'OriginalLeftGazeDirection': OriginalLeftGazeDirection, \
      'OriginalLeftGazeDirectionValid': OriginalLeftGazeDirectionValid, \
      'OriginalLeftGazeOriginPositionInHMD': OriginalLeftGazeOriginPositionInHMD,\
      'OriginalLeftGazeOriginPositionInHMDValid': OriginalLeftGazeOriginPositionInHMDValid,\
      'OriginalLeftPupilDiameter':OriginalLeftPupilDiameter, \
      'OriginalLeftPupilDiameterValid': OriginalLeftPupilDiameterValid, \
      'OriginalLeftPupilPositionInTrackingArea':OriginalLeftPupilPositionInTrackingArea,\
      'OriginalLeftPupilPositionInTrackingAreaValid':OriginalLeftPupilPositionInTrackingAreaValid,\
      'OriginalRightGazeDirection': OriginalRightGazeDirection, \
      'OriginalRightGazeDirectionValid': OriginalRightGazeDirectionValid, \
      'OriginalRightGazeOriginPositionInHMD': OriginalRightGazeOriginPositionInHMD, \
      'OriginalRightGazeOriginPositionInHMDValid':OriginalRightGazeOriginPositionInHMDValid,\
      'OriginalRightPupilDiameter':OriginalRightPupilDiameter, \
      'OriginalRightPupilDiameterValid':OriginalRightPupilDiameterValid, \
      'OriginalRightPupilPositionInTrackingArea': OriginalRightPupilPositionInTrackingArea,\
      'OriginalRightPupilPositionInTrackingAreaValid': OriginalRightPupilPositionInTrackingAreaValid
}

df = pd.DataFrame(d)

df.to_csv(file_name.replace('.xml','.csv'),index = False)

