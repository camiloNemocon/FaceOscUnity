Unity Face OSC


This project was developed in Unity version 2019, using ofxFaceTracker by kylemcdonald and based on UnityOSC by thomasfrefericks.

The Face Tracking Aplication can download: https://github.com/kylemcdonald/ofxFaceTracker/releases

Depending of the function (Pose, Gesture or Raw) that use on Face Tracking Aplication (Face OSC), you will open the Unity scene to recognize osc data that are sending from Face OSC to Unity. 

The port that is used to recieve the data is 8338.

in Script FaceOSCreciveGesture.sc get the following data:
mouth width: /gesture/mouth/width
mouth height: /gesture/mouth/height
left eyebrow height: /gesture/eyebrow/left
right eyebrow height: /gesture/eyebrow/right
left eye openness: /gesture/eye/left
right eye openness: /gesture/eye/right
jaw openness: /gesture/jaw
nostril flate: /gesture/nostrils


in Script FaceOSCrecivePose.sc get the following data:
center position: /pose/position
scale: /pose/scale
orientation (which direction you're facing): /pose/orientation


in Script FaceOSCreciveRaw.sc get the following data:
raw points (66 xy-pairs): /raw


