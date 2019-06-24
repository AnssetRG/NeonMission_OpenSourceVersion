using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reinicio : MonoBehaviour {

    public bool Act;
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {

        if (GetComponentInParent<Creacion>().Act == true)
        {
            Destroy(gameObject);
        }
	}
}
