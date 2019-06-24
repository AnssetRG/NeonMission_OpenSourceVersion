using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotatorio : MonoBehaviour {

    private float Z;
    public float speed;
    public bool Act;
	// Use this for initialization
	void Start () {
        Z = 0f;
	}
	
	// Update is called once per frame
	void Update () {

        if (Act)
        {
            Z = speed + Z;

            if (Z == 360)
                Z = 0;
            Quaternion target = Quaternion.Euler(0, 0, Z);
            transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime);
        }
	}
}   
