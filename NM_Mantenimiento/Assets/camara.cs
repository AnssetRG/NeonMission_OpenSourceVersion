using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camara : MonoBehaviour {

    public GameObject cam;

    public float x;
    public float y;
	// Use this for initialization
    float cx;
    float cy;
    bool regre;
    bool act;
	void Start () {
        cx = 0;
        cy = 0;
	}
	
	// Update is called once per frame
	void Update () {
        if (act)
        {
            cam.GetComponent<CameraController>().yOffSet = cy;
            cam.GetComponent<CameraController>().xOffSet = cx;
            if (regre)
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
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            if (cy >= y)
                cy = cy - 0.05f;
            if (cx >= x)
                cx = cx - 0.05f;
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
