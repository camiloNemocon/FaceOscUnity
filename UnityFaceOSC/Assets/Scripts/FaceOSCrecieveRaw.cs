// This is version 2(2020.04.20)
// Tested in Unity  2019.3.11

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceOSCrecieveRaw : MonoBehaviour
{
    //conection using osc
    public OSC osc;

    //vectore3 arraylist to save position of points face osc 
    private Vector3[] rawList;
    //quantity of points from face osc
    private int numPts = 66;

    //cube in unity as a point face osc
    GameObject punto;
    //game object array to locate each cube
    private GameObject[] puntos;

    
    void Start()
    {

        rawList = new Vector3[numPts];

        //recieve the raw data from face osc
        osc.SetAddressHandler("/raw", posPoints);


        puntos = new GameObject[numPts];
        for (int i = 0; i < numPts; i++)
        {
            //creta a cube
            punto = GameObject.CreatePrimitive(PrimitiveType.Cube);
            //scale cube
            punto.transform.localScale = new Vector3(2.5f, 2.5f, 2.5f);

            //save cube in array game object
            puntos[i] = punto;
        }
    }

    void Update()
    {
        //position of each cube
        for (int i = 0; i < rawList.Length; i++)
        {
            puntos[i].transform.position = new Vector3(rawList[i].x, rawList[i].y, rawList[i].z);
        }
    }

    //recieve and save the points position face data 
    void posPoints(OscMessage message)
    {
        for (int i = 0; i < numPts; i++)
        {
            float Xpos = message.GetFloat(i * 2);
            float Ypos = message.GetFloat((i * 2) + 1);
            rawList[i] = new Vector3(Xpos, Ypos, 0);
            //print(i+"  "+Xpos+"  "+Ypos);

        }


    }

}
