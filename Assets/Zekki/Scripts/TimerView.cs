using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;
using System;

public class TimerView : MonoBehaviour {

    [SerializeField] private TimeCounter timeCounter;
    [SerializeField] private Text counterText;

	void Start () {
        timeCounter.OnTimeChanged.Subscribe(time => 
        {
            counterText.text = time.ToString();
        });
	}
}
