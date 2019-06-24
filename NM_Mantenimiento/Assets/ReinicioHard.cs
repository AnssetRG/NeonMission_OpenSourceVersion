using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReinicioHard : MonoBehaviour {

    public CreacionHard creadorHard;
	void Start () {
        creadorHard = FindObjectOfType<CreacionHard>();
	}
	
	// Update is called once per frame
	void Update () {
        if(creadorHard.Act)
            Destroy(gameObject);
	}
}
