using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zekki;

public class TimerOnOrdinaceGamePart : MonoBehaviour {

    private Text timeText;
    public static float time = TimerOnRhythmPart.time;
    public static float passTime = TimerOnRhythmPart.passTime;

    [SerializeField] private GameObject jibakuObject;
    private bool jibakuStart = false;

	void Start () {
        time = TimerOnRhythmPart.time;
        passTime = TimerOnRhythmPart.passTime;
        timeText = GetComponent<Text>();
        timeText.text = time.ToString("f2");
	}
	
	// Update is called once per frame
	void Update () {
        time -= Time.deltaTime;
        timeText.text = time.ToString("f2");

        if(time <= 0)
        {

            GetComponent<ChangeSceneUeta>().ChangeAnyScene("GameOver");
            Debug.Log("GAMEOVER");
        }

        //Debug
        if (Input.GetKey(KeyCode.Z))
        {
            if(Input.GetKeyDown(KeyCode.X)){
                if (!jibakuStart)
                {
                    jibakuObject.SetActive(true);
                    Invoke("Jibaku",5f);
                    jibakuStart = true;
                }
                
            }
        }

        
	}

    private void Jibaku()
    {
        time = 0;
    }
}
