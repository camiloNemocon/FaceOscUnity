// This is version 2(2020.04.20)
// Tested in Unity  2019.3.11

using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class FaceOSCrecievePose : MonoBehaviour
{
    //conection using osc
    public OSC osc;

    //maping values to move game object face
    private float posX;
    private float posY;
    private float sizeHead;
    private float UpDownTurn;
    private float LateralTurn;
    private float turnZ;

    //game object face
    public GameObject face;


    void Start()
    {
        //recieve the pose data from face osc
        osc.SetAddressHandler("/pose/position", pos);
        osc.SetAddressHandler("/pose/scale", scaleHead);
        osc.SetAddressHandler("/pose/orientation", turn);
    }


    void Update()
    {
        //move game object face
        face.transform.position = new Vector3(posX, posY, 0.0f);

        //scale game object face
        face.transform.localScale = new Vector3(sizeHead, sizeHead, sizeHead);

        Quaternion target = Quaternion.Euler(UpDownTurn, LateralTurn, turnZ);

        //rotate game object face
        face.transform.rotation = Quaternion.Slerp(face.transform.rotation, target, Time.deltaTime * 5.0f);
    }

    //recieve and save the position face data 
    void pos(OscMessage message)
    {
        float x = message.GetFloat(0);

        //mapping the position x data  
        posX = map(x, 50, 600, -5, 5);

        float y = message.GetFloat(1);

        //mapping the position y data
        posY = map(y, 70, 400, 3, -3);

        //print(x+"  "+y);        
    }

    //recieve and save the scale face data
    void scaleHead(OscMessage message)
    {
        float head = message.GetFloat(0);

        //mapping the head data
        sizeHead = map(head,1,6,0.5f,3);

        //print(head);
    }

    //recieve and save the turn face data
    void turn(OscMessage message)
    {
        float upDown = message.GetFloat(0);

        //mapping the turn head data
        UpDownTurn = map(upDown, -0.2f, 0.7f, -17, 17);

        float lateral = message.GetFloat(1);
        
        //mapping the turn head data
        LateralTurn = map(lateral, -0.3f, 0.1f, 160, 200); 
        
        float z = message.GetFloat(2);

        //mapping the turn head data
        turnZ = map(z, -0.8f, 0.8f, 20, -20);


        //print(upDown + "  " + LateralTurn + "  " + z);
    }

    //mapping value function
    public static float map(float x, float x1, float x2, float y1, float y2)
    {
        var m = (y2 - y1) / (x2 - x1);
        var c = y1 - m * x1; // point of interest: c is also equal to y2 - m * x2, though float math might lead to slightly different results.

        return m * x + c;
    }

}
