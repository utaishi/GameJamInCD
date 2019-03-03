using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.UIElements;

public class TypingText : MonoBehaviour
{
	private SetNotes _setNotes;
	private Syorihans _syorihans;
	private char[] problemText;
	public GameObject notes;
	public GameObject threeMen;
	public GameObject backGround;
	private int textIndex = 0;
	public int clearCount = 0;
	private bool missed;
	
	void Start ()
	{
		_setNotes = notes.GetComponent<SetNotes>();
		problemText = _setNotes.firstNotes;
		_syorihans = threeMen.GetComponent<Syorihans>();
	}
	
	void Update () {
		if (Input.anyKeyDown)
		{
			if (Input.GetKeyDown(problemText[textIndex].ToString()))
			{
				Correct();
			}
			else
			{
				Mistake();
			}
		}

		if (missed)
		{
			backGround.GetComponent<Renderer>().material.color = new Color(1f, 0f, 0f, 1f);
		}
		else
		{
			backGround.GetComponent<Renderer>().material.color 
				= Color.Lerp(backGround.GetComponent<Renderer>().material.color, Color.clear, 5f * Time.deltaTime);
		}
		missed = false;
	}

	void Correct()
	{
		_setNotes.notesImages[textIndex].GetComponent<Renderer>().material.color=Color.black;
		textIndex++;
		if (textIndex==6)
		{
			_syorihans.ChangeManImage();
			clearCount++;
			changeText();
			_setNotes.ChangeImage();
		}
	}

	void Mistake()
	{
		missed = true;
	}

	void changeText()
	{
		if (clearCount==1)
		{
			problemText = _setNotes.secondNotes;
		}
		else
		{
			problemText = _setNotes.thirdNotes;
		}
		textIndex = 0;
	}
}
