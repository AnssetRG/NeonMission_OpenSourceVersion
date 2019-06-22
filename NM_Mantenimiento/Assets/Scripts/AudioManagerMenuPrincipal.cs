using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManagerMenuPrincipal : MonoBehaviour {

    public AudioSource VGM_player;
    public AudioClip introOST;
    public AudioClip loopOST;

	// Use this for initialization
	void Start () {
        VGM_player.clip = introOST;
        VGM_player.Play();
	}
	
	// Update is called once per frame
	void Update () {
        if (!VGM_player.isPlaying && VGM_player.clip == introOST)
        {
            VGM_player.clip = loopOST;
            VGM_player.loop = true;
            VGM_player.Play();
        }
	}
}
