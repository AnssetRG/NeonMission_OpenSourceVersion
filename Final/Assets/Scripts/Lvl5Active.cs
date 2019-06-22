using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lvl5Active : MonoBehaviour {

    public GameObject sprite5;
    private bool mostarNivel;

    // Use this for initialization
    void Start () {
	    for(int i=0; i< NewMenuPrincipalController.lvlPasado.Length; i++)
        {
            mostarNivel = NewMenuPrincipalController.lvlPasado[i];
        }
	}
	
	// Update is called once per frame
	void Update () {
        sprite5.SetActive(mostarNivel);
	}
}
