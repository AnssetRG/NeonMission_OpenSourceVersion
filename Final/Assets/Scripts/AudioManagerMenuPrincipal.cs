using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManagerMenuPrincipal : MonoBehaviour {

    public AudioSource intro;
    private bool introState;
    public AudioSource mainBGM;

	// Use this for initialization
	void Start () {
        introState = true;
	}
	
	// Update is called once per frame
	void Update () {
        if (!intro.isPlaying && introState)
        {
            mainBGM.Play();
            introState = false;
        }
	}
}
