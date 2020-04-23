using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceOSCrecieveRaw : MonoBehaviour
{
    public OSC osc;

    public GameObject prefab;

    private Vector3[] rawList;
    private int numPts = 66;

    GameObject punto;
    private GameObject[] puntos;

    // Start is called before the first frame update
    void Start()
    {
        rawList = new Vector3[numPts];

        osc.SetAddressHandler("/raw", posPoints);

        puntos = new GameObject[numPts];
        for (int i = 0; i < numPts; i++)
        {
            punto = Instantiate(prefab);

            puntos[i] = punto;
        }
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < rawList.Length; i++)
        {
            puntos[i].transform.position = new Vector3(rawList[i].x, rawList[i].y, rawList[i].z);
        }
    }

    void posPoints(OscMessage message)
    {
        for (int i = 0; i < numPts; i++)
        {
            float Xpos = message.GetFloat(i * 2);
            float Ypos = message.GetFloat((i * 2) + 1);
            rawList[i] = new Vector3(Xpos, Ypos, 0);
            //print(i+"  "+Xpos+"  "+Ypos);

           // GameObject punto = Instantiate(prefab);
           // punto.transform.position = new Vector3(Xpos, Ypos, 0);
        }


    }

}
