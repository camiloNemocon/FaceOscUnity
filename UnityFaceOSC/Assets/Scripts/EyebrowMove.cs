using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EyebrowMove : MonoBehaviour
{
    //bones of eyebrow model
    public GameObject eyebrowRight;
    public GameObject eyebrowLeft;

    //game object with FaceOSCrescieveGesture script
    public GameObject objectGesture;

    //value to raise left eyebrow from FaceOSCrescieveGesture script
    public float Yleft;
    //value to raise right eyebrow from FaceOSCrescieveGesture script
    public float Yright;

    //value of diference between Yleft value and Yright value
    public float dif;
   

    // Update is called once per frame
    void Update()
    {
        //distance values between eyebrows left and eye left
        Yleft = objectGesture.GetComponent<FaceOSCreceiveGesture>().dataEyeBrowLeft;

        //distance values between eyebrows right and eye right
        Yright = objectGesture.GetComponent<FaceOSCreceiveGesture>().dataEyeBrowRight;

        //value of diference between Yleft value and Yright value
        dif = Yleft - Yright;

        //open eye left, close eye left or raise eyebrow left depend of the Yleft value  and diference between Yleft value and Yright value
        float posYleft = 0;
        if (Yleft >= 0.8f)
        {
            posYleft = 0.0001f;
        }
        else
        {
            if(dif >= 0.027f)
            {
                posYleft = -0.0004f;
            }
            else
            {
                posYleft = 0;
            }
        }
        //move bones of eyebrow left model
        eyebrowLeft.transform.localPosition = new Vector3(0, 0, posYleft);


        //open eye right, close eye right or raise eyebrow right depend of the Yright value and diference between Yleft value and Yright value
        float posYright;
        if (dif > 0.0f && Yright >= 0.8f)
        {
            posYright = 0.0001f;
        }
        else if (Yright < 0.8f && Yleft < 0.8f && dif >= 0.01f)
        {
            posYright = 0; 
        }
        else 
        {
            posYright = -0.0004f;
        }
        //move bones of eyebrow right model
        eyebrowRight.transform.localPosition = new Vector3(0, 0, posYright);

    }






}
