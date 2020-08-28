## http://developer.tobiipro.com/python/python-step-by-step-guide.html

import tobii_research as tr
import time
import pandas as pd
import keyboard
from datetime import datetime

output_dir = 'C:/github/ORCL_VR_EyeTracking/Data/EyeTrakcing/TobiiProPython/'
# 1. Find the Eye Tracker
found_eyetrackers = tr.find_all_eyetrackers()

my_eyetracker = found_eyetrackers[0]

print("Address: " + my_eyetracker.address)

print("Model: " + my_eyetracker.model)

print("Name (It's OK if this is empty): " + my_eyetracker.device_name)

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

def gaze_data(my_eyetracker):
    global global_gaze_data
    print("Subscribing to gaze data for eye tracker with serial number {0}.".format(my_eyetracker.serial_number))
    my_eyetracker.subscribe_to(tr.EYETRACKER_HMD_GAZE_DATA, gaze_data_callback, as_dictionary=True)
    
    while True:
        
        if keyboard.is_pressed('q'):            
            my_eyetracker.unsubscribe_from(tr.EYETRACKER_HMD_GAZE_DATA, gaze_data_callback)
            print("Unsubscribed from gaze data.")
            print("q pressed:")
            break
    #print(global_gaze_data)

start_time_stamp = time.time()   
start_datetime = datetime.now()

gaze_data(my_eyetracker)
df = pd.DataFrame(global_gaze_data)



end_time = time.time()
# file_name = str(start_time_stamp) + '-' + str(end_time) + '.csv'

file_name = str(start_datetime).replace(':','-') + '.csv'


df.to_csv(output_dir + file_name, index = False)








