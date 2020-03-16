# -*- coding: utf-8 -*-
"""
Created on Wed Jan  3 10:15:56 2018

@author: Xiang Guo
"""

## To read the videos and write frame images.
import numpy as np
import cv2
import os
import glob
os.chdir('C:/github/ORCL_VR_EyeTracking/Data/Video/1.Raw Videos')
videolist = glob.glob('*.mp4')
output_path = 'C:/github/ORCL_VR_EyeTracking/Data/Video/2.videos_frames/'

for vid in videolist:
    path = output_path + vid.split('.')[0]  
    try:
        os.mkdir(path)
    except:
        pass
    vidcap = cv2.VideoCapture(vid)
    

    
    success,image = vidcap.read()
    count = 0
    success = True
    while success:
        success,image = vidcap.read()
        filename = str("/%d.jpg" % (count+1))
        filepath = path + filename
        cv2.imwrite(filepath, image)     # save frame as JPEG file
        count += 1
    os.remove(filepath)
    