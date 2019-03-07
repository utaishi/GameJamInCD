using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerOnRhythmPart : MonoBehaviour
{
	private Text timeText;
	public static float time = 500.00f;
	public static float passTime;
	
	void Start ()
	{
		timeText = GetComponent<Text>();
		timeText.text = time.ToString("f2");
	}
	
	void Update ()
	{
		time -= Time.deltaTime;
		timeText.text = time.ToString("f2");
		
		if (time<=0)
		{
			//GameOver
			Debug.Log("GAMEOVER");
		}
	}

	public void DecreaseTimer()
	{
		time -= 30;
		timeText.text = time.ToString("f2");
	}

	public void ClearTime()
	{
		passTime = 500f - time;
	}
}
