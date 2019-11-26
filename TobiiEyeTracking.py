## http://developer.tobiipro.com/python/python-step-by-step-guide.html

import tobii_research as tr
import time

# 1. Find the Eye Tracker
found_eyetrackers = tr.find_all_eyetrackers()

my_eyetracker = found_eyetrackers[0]
print("Address: " + my_eyetracker.address)
print("Model: " + my_eyetracker.model)
print("Name (It's OK if this is empty): " + my_eyetracker.device_name)
print("Serial number: " + my_eyetracker.serial_number)

# 2.Calibrate the Eye tracker
## Enter Calibration Mode
enter_calibration_mode()
## Leave Calibration Mode
leave_calibration_mode()
## Collect Data
collect_data()
## Discard Data
discard_data()
## Compute and Apply
compute_and_apply()
## applying a calibration
apply_calibration_data()
## retrieving a calibration
retriev_calibration_data()


# 3. Get the gaze data!
def gaze_data_callback(gaze_data):
    # Print gaze points of left and right eye
    print("Left eye: ({gaze_left_eye}) \t Right eye: ({gaze_right_eye})".format(
        gaze_left_eye=gaze_data['left_gaze_point_on_display_area'],
        gaze_right_eye=gaze_data['right_gaze_point_on_display_area']))

my_eyetracker.subscribe_to(tr.EYETRACKER_GAZE_DATA, gaze_data_callback, as_dictionary=True)

time.sleep(5)

my_eyetracker.unsubscribe_from(tr.EYETRACKER_GAZE_DATA, gaze_data_callback)









