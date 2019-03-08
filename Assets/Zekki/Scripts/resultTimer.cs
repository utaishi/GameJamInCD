using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class resultTimer : MonoBehaviour {
    [SerializeField] private Text rhythmTime;
    [SerializeField] private Text ordinanceTime;

    [SerializeField] private GameObject bakuhatu;
    [SerializeField] private GameObject clearBGM;
    [SerializeField] private GameObject shippaiBGM;

	// Use this for initialization
	void Start () {
        rhythmTime.text = TimerOnRhythmPart.passTime.ToString("f2");
        ordinanceTime.text = TimerOnOrdinaceGamePart.time.ToString("f2");

        if (TimerOnOrdinaceGamePart.time <= 0.0f)
        {
            bakuhatu.SetActive(true);
            shippaiBGM.SetActive(true);
        }
        else
        {
            clearBGM.SetActive(true);
        }

        

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
