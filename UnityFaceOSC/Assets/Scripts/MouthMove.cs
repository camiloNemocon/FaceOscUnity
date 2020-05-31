using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouthMove : MonoBehaviour
{
    //bones of mouth model
    public GameObject lipUp;
    public GameObject lipDown;
    //bones of cheek model
    public GameObject cheekLeft;
    public GameObject cheekRight;

    //game object with FaceOSCrescieveGesture script
    public GameObject objectGesture;

    //value of mouth FaceOSCrescieveGesture script
    private float height;
    private float weigth;

    //value of bones mouth Y position
    private float upMouthBones = 0.0005f;
    private float downMouthBones = 0.0005f;

    //value of bones cheek X position
    private float cheekLeftX = -0.00035f;
    private float cheekRightX = 0.00035f;

    //value of bones cheek Y position
    private float cheekLeftY = 0.001172607f;
    private float cheekRightY = 0.001172607f;


    void Update()
    {
        //Mouth height value
        height = objectGesture.GetComponent<FaceOSCreceiveGesture>().HeigthM;

        //open or close mouth depend of the height value
        if (height > 7)
        {
            upMouthBones = 0.0008f;
            downMouthBones = 0.0002f;
        }
        else if (height <= 7 && height > 4)
        {
            upMouthBones = 0.00065f;
            downMouthBones = 0.00035f;
        }
        else if (height <= 4 && height >= 2)
        {
            upMouthBones = 0.0006f;
            downMouthBones = 0.0004f;
        }
        else
        {
            upMouthBones = 0.0005f;
            downMouthBones = 0.0005f;
        }
        //move bones of mouth model
        lipUp.transform.localPosition = new Vector3(0, upMouthBones, 0.0004f);
        lipDown.transform.localPosition = new Vector3(0, downMouthBones, 0.0004f);


        //Mouth weigth value
        weigth = objectGesture.GetComponent<FaceOSCreceiveGesture>().WidthM;

        //position cheek depend of the weigth value
        if (weigth >= 16)
        {
            cheekLeftX = -0.0005f;
            cheekRightX = 0.0005f;

            cheekLeftY = 0.001f;
            cheekRightY = 0.001f;
        }
        else
        {
            cheekLeftY = 0.001172607f;
            cheekRightY = 0.001172607f;
        }

        if (weigth < 16 && weigth >= 14)
        {
            cheekLeftX = -0.00042f;
            cheekRightX = 0.00042f;           
        }
        else if (weigth < 14 && weigth >= 10)
        {
            cheekLeftX = -0.00035f;
            cheekRightX = 0.00035f;
        }
        else if (weigth < 10)
        {
            cheekLeftX = -0.00025f;
            cheekRightX = 0.00025f;
        }
        //move bones of cheek model
        cheekLeft.transform.localPosition = new Vector3(cheekLeftX, cheekLeftY, 0.0002f);
        cheekRight.transform.localPosition = new Vector3(cheekRightX, cheekRightY, 0.0002f);
    }

}
