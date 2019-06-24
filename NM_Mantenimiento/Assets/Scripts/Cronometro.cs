using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Cronometro : MonoBehaviour {


    public float StarTime;
    public Text timer;
    private bool finish;
    public float PlayTime;

	// Use this for initialization
	void Start () {
        StarTime = Time.time;
        PlayTime = 0;
	}
	
	// Update is called once per frame
	void Update () {
        if(!finish)
           {
            float t = Time.time - StarTime;
            PlayTime = t;
            string minutes = ((int)t / 60).ToString();
            string seconds = (t % 60).ToString("f2");
            timer.text = "Tiempo \t" + minutes + ":" + seconds;
        }
        //Debug.Log(PlayTime);
        ChangeColor();
	}

    void ChangeColor()
    {
        if(Time.timeScale == 0)
            timer.color = new Color(0, 255f, 255f, 0.2f);
        else
            timer.color = new Color(0, 255f, 255f, 1f);
    }

    public void FinishLevelTimer()
    {
        finish = true;
    }

    public float GetTime()
    {
        return PlayTime;
    }
}
