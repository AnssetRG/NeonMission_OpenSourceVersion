using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lvl5Active : MonoBehaviour {

    public GameObject sprite5;
    private bool mostarNivel;
    private int contLvl;
    public int LvlsNeeded;

    // Use this for initialization
    void Start () {
        contLvl = 0;
	    for(int i=0; i< NewMenuPrincipalController.lvlPasado.Length; i++)
        {
            mostarNivel = NewMenuPrincipalController.lvlPasado[i];
            if (mostarNivel)
            {
                contLvl++;
            }
            
        }
	}
	
	// Update is called once per frame
	void Update () {
        if (contLvl >= LvlsNeeded)
            sprite5.SetActive(true);
        else
            sprite5.SetActive(false);
    }
}
