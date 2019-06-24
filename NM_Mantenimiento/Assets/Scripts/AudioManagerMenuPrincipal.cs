using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManagerMenuPrincipal : MonoBehaviour {

    public AudioSource OST_player;
    public AudioSource FOLEY_player;
    public AudioClip intro_OST;
    public AudioClip loop_OST;
    public AudioClip[] FOLEYS;
    

	// Use this for initialization
	void Start () {
        OST_player.clip = intro_OST;
        OST_player.Play();
        OST_player.loop = false;
        FOLEY_player.loop = false;
        FOLEY_player.clip = null;
    }
	
	// Update is called once per frame
	void Update () {
        if (!OST_player.isPlaying && OST_player.clip == intro_OST)
        {
            OST_player.clip = loop_OST;
            OST_player.Play();
            OST_player.loop = true;
        }
	}

    public void PlayFoley(int position)
    {
        FOLEY_player.clip = FOLEYS[position];
        FOLEY_player.Play();
    }

}
