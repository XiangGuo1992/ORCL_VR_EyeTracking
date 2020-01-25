# -*- coding: utf-8 -*-
"""
Created on Sat Jan 25 16:15:43 2020

@author: Xiang Guo
"""

import numpy as np
import os
import cv2
import re
from matplotlib import pyplot as plt
import pandas as pd
os.chdir('C:\\research\\VR-EyeTracking')

framelist = os.listdir(os.path.join('videos_frames','movie01-22-2020 224229'))
#number of frame images
framelen=len(framelist)


df = pd.read_table('vr_data_20191204T233149.csv')
#length of raw data
dflen = len(df)


for j in framelist:
    i = int(re.findall("\d+",j)[0])
    i = round(i*dflen/framelen)
    if (df['Point of Regard Binocular X [px]'][i] == '-' or df['Point of Regard Binocular Y [px]'][i] == '-'):
    	print('outlier:',j,i)
    	continue

    PointX = round(float(df['Point of Regard Binocular X [px]'][i]))
    PointY = round(float(df['Point of Regard Binocular Y [px]'][i]))
    
    img =cv2.imread(j)
    cv2.circle(img,(PointX, PointY), 20, (0,255,0),-1)
    plt.imshow(img)
    cv2.imwrite('E:\\Xiang Guo\\Lian\\test3\\' + re.findall("\d+",j)[0] +'_output.jpg',img)