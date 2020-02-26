import setup_path 
import airsim
import numpy as np

import cv2
import time

client = airsim.CarClient()
client.confirmConnection()

start = time.time()

floor = client.simGetSegmentationObjectID('Floor')
print('flooer ID: ',floor)

cube = client.simGetSegmentationObjectID('Cube')
print('cube ID:',cube)

found = client.simSetSegmentationObjectID("Cylinder (1)", 0, True)
# client.simSetSegmentationObjectID("Floor", 0, True);


# success = client.simSetSegmentationObjectID("cylinder[\w]*", 1, True);

# success = client.simSetSegmentationObjectID("Environment[\w]*", 1);

# success = client.simSetSegmentationObjectID("cube[\w]*", 5, True)


# change alll cubes
success = client.simSetSegmentationObjectID("Cube[\w]*", 1, True)
success = client.simSetSegmentationObjectID("Cylinder[\w]*", 3, True)

# purple
success = client.simSetSegmentationObjectID("Cube1", 15, True)
cube = client.simGetSegmentationObjectID('Cube1')
print('cube ID after:',cube)

success = client.simSetSegmentationObjectID("Cube58", 15, True)
cube = client.simGetSegmentationObjectID('Cube58')
print('cube ID after:',cube)


# red
success = client.simSetSegmentationObjectID("Sphere", 2, True)
cube = client.simGetSegmentationObjectID('Sphere')
print('Sphere ID after:',cube)

# green
success = client.simSetSegmentationObjectID("Cylinderintheair", 200, True)
cube = client.simGetSegmentationObjectID('Cylinderintheair')
print('Cylinder ID after:',cube)
# 13289928
success = client.simSetSegmentationObjectID('13289928', 2, True)


#success = client.simSetSegmentationObjectID("cube[\w]*", 5);
'''
while (cv2.waitKey(1) & 0xFF) == 0xFF:
    milliseconds = (time.time() - start) * 1000
    responses = client.simGetImages([
            airsim.ImageRequest(0, airsim.ImageType.Scene, False, False),
            airsim.ImageRequest(0, airsim.ImageType.Segmentation, False, False)
            ])
    for i, response in enumerate(responses):
        img1d = np.fromstring(response.image_data_uint8, dtype=np.uint8) 
        img_rgba = img1d.reshape(response.height, response.width, 4)  
        img_rgba = np.flipud(img_rgba)
        airsim.write_png(str(milliseconds) + '_' + str(i) + '.png', img_rgba)
    time.sleep(1)
'''   

# for demo camera window, 1 = Depth vis, 2 = Segmentation, 3 = Scene
# actually, 3 = scene, 5 = depth, 0 = segmentation
responses = client.simGetImages([
        airsim.ImageRequest(0, 3),
        airsim.ImageRequest(0, 5),
        airsim.ImageRequest(0, 0),
        ])    
    
'''
responses = client.simGetImages([
        airsim.ImageRequest(0, airsim.ImageType.Scene),
        airsim.ImageRequest(0, airsim.ImageType.DepthPlanner),
        
        airsim.ImageRequest(0, airsim.ImageType.DepthPerspective),
        airsim.ImageRequest(0, airsim.ImageType.DepthVis),
        airsim.ImageRequest(0, airsim.ImageType.DisparityNormalized),
        airsim.ImageRequest(0, airsim.ImageType.Segmentation),
        airsim.ImageRequest(0, airsim.ImageType.SurfaceNormals),
        airsim.ImageRequest(0, airsim.ImageType.Infrared),
        ])    
'''   
for response in responses:
    if response.pixels_as_float:
        print("Type %d, size %d" % (response.image_type, len(response.image_data_float)))
        airsim.write_pfm('py %d.pfm'%response.image_type, airsim.get_pfm_array(response))
    else:
        print("Type %d, size %d" % (response.image_type, len(response.image_data_uint8)))
        airsim.write_file('py%d.png'%response.image_type, response.image_data_uint8)
        
        
        
        