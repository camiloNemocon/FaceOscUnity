using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceOSCrecievePose : MonoBehaviour
{
    public OSC osc;

    private float posX;
    private float posY;
    private float sizeHead;
    private float UpDownTurn;
    private float LateralTurn;
    private float turnZ;

    public GameObject face;

    // Start is called before the first frame update
    void Start()
    {
        osc.SetAddressHandler("/pose/position", pos);
        osc.SetAddressHandler("/pose/scale", scaleHead);
        osc.SetAddressHandler("/pose/orientation", turn);
    }

    // Update is called once per frame
    void Update()
    {
        face.transform.position = new Vector3(posX, posY, 0.0f);
        face.transform.localScale = new Vector3(sizeHead, sizeHead, sizeHead);

        Quaternion target = Quaternion.Euler(UpDownTurn, LateralTurn, turnZ);

        face.transform.rotation = Quaternion.Slerp(face.transform.rotation, target, Time.deltaTime * 5.0f);
    }

    void pos(OscMessage message)
    {
        float x = message.GetFloat(0);
        posX = map(x, 50, 600, -5, 5);

        float y = message.GetFloat(1);        
        posY = map(y, 70, 400, 3, -3);

        //print(x+"  "+y);        
    }    

    void scaleHead(OscMessage message)
    {
        float head = message.GetFloat(0);
        sizeHead = map(head,1,6,0.5f,3);
        //print(head);
    }

    void turn(OscMessage message)
    {
        float upDown = message.GetFloat(0);
        UpDownTurn = map(upDown, -0.2f, 0.7f, 17, -17);

        float lateral = message.GetFloat(1);
        LateralTurn = map(lateral, -0.4f, 0.4f, -15, 15); 
        
        float z = message.GetFloat(2);
        turnZ = map(z, -0.8f, 0.8f, 20, -20);

        //print(upDown+"  "+LateralTurn+"  "+z);
    }

    public static float map(float x, float x1, float x2, float y1, float y2)
    {
        var m = (y2 - y1) / (x2 - x1);
        var c = y1 - m * x1; // point of interest: c is also equal to y2 - m * x2, though float math might lead to slightly different results.

        return m * x + c;
    }

}
