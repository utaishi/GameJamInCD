using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerOnOrdinaceGamePart : MonoBehaviour {

    private Text timeText;
    public static float time = TimerOnRhythmPart.time;
    public static float passTime = TimerOnRhythmPart.passTime;

	void Start () {
        timeText = GetComponent<Text>();
        timeText.text = time.ToString("f2");
	}
	
	// Update is called once per frame
	void Update () {
        time -= Time.deltaTime;
        timeText.text = time.ToString("f2");

        if(time <= 0)
        {
            Debug.Log("GAMEOVER");
        }
	}
}
