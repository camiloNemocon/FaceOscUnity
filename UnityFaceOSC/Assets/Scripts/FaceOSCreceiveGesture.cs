// This is version 2(2020.04.20)
// Tested in Unity  2019.3.11

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceOSCreceiveGesture : MonoBehaviour
{
    //conection using osc
    public OSC osc;

    //maping values to move game objects
    private float mouthW;
    private float mouthH;
    private float eyebrowL;
    private float eyebrowR;
    private float eyeL;
    private float eyeR;
    private float jaw;
    private float nostrils;

    //game obeject that are moved and showed
    public GameObject mouth;
    public GameObject leftEyebrow;
    public GameObject rightEyebrow;

    //create artificial eyes 
    public GameObject leftEye;
    public GameObject rightEye;

    //Eyebrows values recieved from osc gesture
    private float rigthEB;
    private float leftEB;

    //Mouth values recieved from osc gesture
    public float HeigthM;
    public float WidthM;

    //distance values between eyebrows and eyes
    public float dataEyeBrowLeft;
    public float dataEyeBrowRight;


    void Start()
    {
        //recieve the gesture data from face osc 
        osc.SetAddressHandler("/gesture/mouth/width", mouthWidth);
        osc.SetAddressHandler("/gesture/mouth/height", mouthHeight);
        osc.SetAddressHandler("/gesture/eyebrow/left", eyebrowLeft);
        osc.SetAddressHandler("/gesture/eyebrow/right", eyebrowRight);
        osc.SetAddressHandler("/gesture/eye/left", eyeLeft);
        osc.SetAddressHandler("/gesture/eye/right", eyeRight);
        osc.SetAddressHandler("/gesture/jaw", jawSize);
        osc.SetAddressHandler("/gesture/jaw", nostrilsSize);
    }

    void Update()
    {
        //scale the box mouth
        mouth.transform.localScale = new Vector3(mouthW, mouthH, 2.0f);

        //move the box left eyebrow
        leftEyebrow.transform.localPosition = new Vector3(3.0f, eyebrowL, 2.0f);

        //move the box right eyebrow
        rightEyebrow.transform.localPosition = new Vector3(-3.0f, eyebrowR, 2.0f);

        //Location artificial eyes, those eyes dont have osc eyes data
        leftEye.transform.localPosition = new Vector3(3.0f, 2.9f, 2.0f);
        rightEye.transform.localPosition = new Vector3(-3.0f, 2.9f, 2.0f);

        //distance values between eyebrows and eyes
        dataEyeBrowLeft = Vector3.Distance(leftEye.transform.position, leftEyebrow.transform.position);
        dataEyeBrowRight = Vector3.Distance(rightEye.transform.position, rightEyebrow.transform.position);
    }

    //recieve and save the mouth wight data 
    void mouthWidth(OscMessage message)
    {
        WidthM = message.GetFloat(0);

        //mapping the data to scale the box mouth
        mouthW = map(WidthM,7,18,1,4.5f);
        //print(WidthM);
    }

    //recieve and save the mouth height data 
    void mouthHeight(OscMessage message)
    {
        HeigthM = message.GetFloat(0);

        //mapping the data to scale the box mouth
        mouthH = map(HeigthM,1,10,1,3.5f);
        //print(HeigthM);
    }

    //recieve and save the eyebrow left data 
    void eyebrowLeft(OscMessage message)
    {
        leftEB = message.GetFloat(0);

        //mapping the data to location the box eyebrow
        eyebrowL = map(leftEB,5,10,4,6.5f);
       //print(leftEB);
    }

    //recieve and save the eyebrow right data
    void eyebrowRight(OscMessage message)
    {
        rigthEB = message.GetFloat(0);

        //mapping the data to location the box eyebrow
        eyebrowR = map(rigthEB, 5, 10, 4, 6.5f);
        //print(rigthEB);
    }

    //recieve and save the eye left data
    void eyeLeft(OscMessage message)
    {
        eyeL = message.GetFloat(0);
        //print(eyeL);
    }

    //recieve and save the eye right data
    void eyeRight(OscMessage message)
    {
        eyeR = message.GetFloat(0);
        //print(eyeR);
    }

    //recieve and save the jaw data
    void jawSize(OscMessage message)
    {
        jaw = message.GetFloat(0);
        //print(jaw);
    }

    //recieve and save the nostrils data
    void nostrilsSize(OscMessage message)
    {
        nostrils = message.GetFloat(0);
        //print(nostrils);
    }

    //mapping value function
    public static float map(float x, float x1, float x2, float y1, float y2)
    {
        var m = (y2 - y1) / (x2 - x1);
        var c = y1 - m * x1; // point of interest: c is also equal to y2 - m * x2, though float math might lead to slightly different results.

        return m * x + c;
    }



}
