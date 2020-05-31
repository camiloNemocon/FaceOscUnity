using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceOSCreceiveGesture : MonoBehaviour
{
    public OSC osc;

    private float mouthW;
    private float mouthH;
    private float eyebrowL;
    private float eyebrowR;
    private float eyeL;
    private float eyeR;
    private float jaw;
    private float nostrils;

    public GameObject mouth;
    public GameObject leftEyebrow;
    public GameObject rightEyebrow;
    

    // Start is called before the first frame update
    void Start()
    {
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
        mouth.transform.localScale = new Vector3(mouthW, mouthH, 2.0f);

        leftEyebrow.transform.localPosition = new Vector3(3.0f, eyebrowL, 2.0f);

        rightEyebrow.transform.localPosition = new Vector3(-3.0f, eyebrowR, 2.0f);
    }


    void mouthWidth(OscMessage message)
    {
        float WidthM = message.GetFloat(0);
        mouthW = map(WidthM,7,18,1,4.5f);
        //print(WidthM);
    }

    void mouthHeight(OscMessage message)
    {
        float HeigthM = message.GetFloat(0);
        mouthH = map(HeigthM,1,10,1,3.5f);
        //print(HeigthM);
    }

    void eyebrowLeft(OscMessage message)
    {
        float leftEB = message.GetFloat(0);
        eyebrowL = map(leftEB,5,10,4,6.5f);
       //print(leftEB);
    }

    void eyebrowRight(OscMessage message)
    {
        float rigthEB = message.GetFloat(0);
        eyebrowR = map(rigthEB, 5, 10, 4, 6.5f);
        //print(rigthEB);
    }

    void eyeLeft(OscMessage message)
    {
        eyeL = message.GetFloat(0);
        //print(eyeL);
    }

    void eyeRight(OscMessage message)
    {
        eyeR = message.GetFloat(0);
        //print(eyeR);
    }

    void jawSize(OscMessage message)
    {
        jaw = message.GetFloat(0);
        //print(jaw);
    }

    void nostrilsSize(OscMessage message)
    {
        nostrils = message.GetFloat(0);
        //print(nostrils);
    }

    public static float map(float x, float x1, float x2, float y1, float y2)
    {
        var m = (y2 - y1) / (x2 - x1);
        var c = y1 - m * x1; // point of interest: c is also equal to y2 - m * x2, though float math might lead to slightly different results.

        return m * x + c;
    }





}
