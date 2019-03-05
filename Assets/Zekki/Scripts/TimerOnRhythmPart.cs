﻿using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

public class TimerOnRhythmPart : MonoBehaviour
{
	private Text timeText;
	private float time = 500.00f;
	
	void Start ()
	{
		timeText = GetComponent<Text>();
		timeText.text = time.ToString("f2");
		Observable.Interval(TimeSpan.FromMilliseconds(10)).Subscribe(x =>
		{
			time -= 0.01f;
			timeText.text = time.ToString("f2");
		});
	}
	
	void Update () {
		if (time<=0)
		{
			//GameOver
			Debug.Log("GAMEOVER");
		}
	}

	public void DecreaseTimer()
	{
		time -= 20;
		timeText.text = time.ToString("f2");
	}
}
