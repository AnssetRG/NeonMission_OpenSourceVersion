using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camara : MonoBehaviour {

    public GameObject cam;

    public float x;
    public float y;
    public bool up;
    //public float OrtoChange;
    //public bool ChangeCameraOrto;
    // Use this for initialization
    //float ortoSize;
    //float oSChangeCounter;
    float cx;
    float cy;
    bool regre;
    bool act;
	void Start () {
        cx = 0;
        cy = 0;
        //oSChangeCounter = 0;
	}
	
	// Update is called once per frame
	void Update () {
        if (act)
        {
            cam.GetComponent<CameraController>().yOffSet = cy;
            cam.GetComponent<CameraController>().xOffSet = cx;
            //cam.GetComponent<CameraController>().cameraOrthoSize = ortoSize;
            if (regre)
            {
                if (up)
                {
                    if (cy >= 0)
                    {
                        cy = cy - 0.05f;
                    }
                    else
                    {
                        act = false;
                    }
                    if (cx >= 0)
                    {
                        cx = cx - 0.05f;
                    }
                }
                else
                {
                    if (cy <= 0)
                    {
                        cy = cy + 0.05f;
                    }
                    else
                    {
                        act = false;
                    }
                    if (cx <= 0)
                    {
                        cx = cx + 0.05f;
                    }
                }
                //if (ChangeCameraOrto)
                //{
                //    if(oSChangeCounter >= 0)
                //    {
                //        oSChangeCounter = oSChangeCounter - 0.05f;
                //        ortoSize -= 0.05f;
                //    }
                //    else
                //    {
                //        act = false;
                //    }
                //}
            }
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            if (up)
            {
                if (cy <= y)
                    cy = cy + 0.05f;
                if (cx <= x)
                    cx = cx + 0.05f;
            }
            else
            {
                if (cy >= y)
                    cy = cy - 0.05f;
                if (cx >= x)
                    cx = cx - 0.05f;
            }
            //if (ChangeCameraOrto)
            //{
            //    if(OrtoChange >= oSChangeCounter)
            //    {
            //        oSChangeCounter = oSChangeCounter + 0.05f;
            //        ortoSize += 0.05f;
            //    }
            //}
            regre = false;
            act = true;
            
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            regre = true;
        }
    }
}
