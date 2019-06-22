using System.Collections;
using System.Collections.Generic;

using UnityEngine.UI;
using UnityEngine;

public class ScoreManager : MonoBehaviour {

    public static int score;
    public Text controls;
    public Text controls1;
    public Text controls2;
    Text text;

    void Start()
    {
        text = GetComponent<Text>();
        score = 0;
    }

    void Update()
    {
        if (score < 0)
        {
            score = 0;
        }

        text.text = "" + score;
        controls.text = "Jump: X";
        controls1.text = "Move: Joystick R";
        controls2.text = "Throw: ■";
    }

    public static void AddPoints(int pointsToAdd)
    {
        score += pointsToAdd;
    }

    public static void Reset()
    {
        score = 0;
    }
}
