using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TypingText : MonoBehaviour
{
	private SetNotes _setNotes;
	private char[] problemText;
	public GameObject notes;
	private int textIndex = 0;
	public int clearCount = 0;
	
	void Start ()
	{
		_setNotes = notes.GetComponent<SetNotes>();
		problemText = _setNotes.firstNotes;
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
	}

	void Correct()
	{
		textIndex++;
		Debug.Log("correct"+textIndex);
		if (textIndex==6)
		{
			clearCount++;
			changeText();
			_setNotes.ChangeImage();
		}
	}

	void Mistake()
	{
		Debug.Log("miss"+textIndex);
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
