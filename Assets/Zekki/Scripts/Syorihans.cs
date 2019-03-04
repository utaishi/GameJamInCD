using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Syorihans : MonoBehaviour
{
	public GameObject inputText;
	private TypingText _typingText;
	public GameObject[] threeMen;
	public GameObject[] manImages;
	public GameObject[] manSleep;
	public GameObject[] manWake;
	private AudioSource wakeupSound;
	
	void Start () {
		for (int i = 0; i < 3; i++)
		{
			manImages[i] = Instantiate(manSleep[i], threeMen[i].transform);
		}
		_typingText = inputText.GetComponent<TypingText>();
		wakeupSound = GetComponent<AudioSource>();
	}
	
	void Update () {
		
	}

	public void ChangeManImage()
	{
		int count = _typingText.clearCount;
		Destroy(manImages[count]);
		manImages[count] = Instantiate(manWake[count], threeMen[count].transform);
		wakeupSound.Play();
	}
}
