using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zekki;

public class TimerOnRhythmPart : MonoBehaviour
{
	private Text timeText;
    public static float setTime = 300f;
    public static float time;
	public static float passTime;
	
	void Start ()
	{
		timeText = GetComponent<Text>();
		timeText.text = time.ToString("f2");
        time = setTime;
	}
	
	void Update ()
	{
		time -= Time.deltaTime;
		timeText.text = time.ToString("f2");
		
		if (time<=0)
		{
            //GameOver
            GetComponent<ChangeSceneUeta>().ChangeAnyScene("GameOver");
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
		passTime = setTime - time;
	}

    public void Initialize()
    {
        time = setTime;
    }
}
