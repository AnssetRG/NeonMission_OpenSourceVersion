using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinsCounter : MonoBehaviour {

    public static int CoinsCollected = 0;

	// Use this for initialization
	void Start () {
        CoinsCollected = 0;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public static void CollectCoint()
    {
        CoinsCollected++;
    }
}
