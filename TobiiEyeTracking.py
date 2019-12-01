## http://developer.tobiipro.com/python/python-step-by-step-guide.html

import tobii_research as tr
import time
import pandas as pd
import keyboard
# 1. Find the Eye Tracker
found_eyetrackers = tr.find_all_eyetrackers()

my_eyetracker = found_eyetrackers[0]
# tobii-ttp://VRU02-5A94AAX04179
print("Address: " + my_eyetracker.address)
# VR4_U2_P2
print("Model: " + my_eyetracker.model)
# vrg1 t2
print("Name (It's OK if this is empty): " + my_eyetracker.device_name)
# VRU02-5A94AAX04179
print("Serial number: " + my_eyetracker.serial_number)

'''
columns = ['device_time_stamp', 'system_time_stamp', 'left_gaze_direction_unit_vector', 
           'left_gaze_direction_validity', 'left_gaze_origin_position_in_hmd_coordinates', 
           'left_gaze_origin_validity', 'left_pupil_diameter', 'left_pupil_validity', 
           'left_pupil_position_in_tracking_area', 'left_pupil_position_validity', 
           'right_gaze_direction_unit_vector', 'right_gaze_direction_validity', 
           'right_gaze_origin_position_in_hmd_coordinates', 'right_gaze_origin_validity',
           'right_pupil_diameter', 'right_pupil_validity', 'right_pupil_position_in_tracking_area', 
           'right_pupil_position_validity']
'''


global_gaze_data = []


def gaze_data_callback(gaze_data):
    global global_gaze_data
    global_gaze_data.append(gaze_data)

'''
## detect for 3 seconds
def gaze_data(my_eyetracker):
    global global_gaze_data
    print("Subscribing to gaze data for eye tracker with serial number {0}.".format(my_eyetracker.serial_number))
    my_eyetracker.subscribe_to(tr.EYETRACKER_HMD_GAZE_DATA, gaze_data_callback, as_dictionary=True)
    time.sleep(3) 
    my_eyetracker.unsubscribe_from(tr.EYETRACKER_HMD_GAZE_DATA, gaze_data_callback)
    print("Unsubscribed from gaze data.")
    print("Last received gaze package:")
    #print(global_gaze_data)
   
gaze_data(my_eyetracker)
df = pd.DataFrame(global_gaze_data)
df.to_csv('C:/Users/ORCL/Documents/Xiang/eye_tracking_data_python/df.csv', index = False)
'''

### Detect until user press a key

df = pd.DataFrame(global_gaze_data)



df.to_csv('C:/Users/ORCL/Documents/Xiang/eye_tracking_data_python/df2.csv', index = False)








