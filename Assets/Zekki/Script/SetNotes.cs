using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetNotes : MonoBehaviour
{

	public char[] firstNotes = new char[6];
	public char[] secondNotes = new char[6];
	public char[] thirdNotes = new char[6];
	private char[] elements = {'a', 's', 'd'};
	public GameObject[] notes;
	public GameObject onCymbal;
	public GameObject onFrypan;
	public GameObject onHarisen;
	public GameObject inputText;
	private TypingText _typingText;

	void Start () {
		for (int i = 0; i < 6; i++)
		{
			firstNotes[i] = elements[Random.Range(0, 3)];
			secondNotes[i] = elements[Random.Range(0, 3)];
			thirdNotes[i] = elements[Random.Range(0, 3)];
		}
		SetImage(firstNotes);

		_typingText = inputText.GetComponent<TypingText>();
	}
	
	void Update () {
		
	}

	public void ChangeImage()
	{
		if (_typingText.clearCount==1)
		{
			SetImage(secondNotes);
		}
		else
		{
			SetImage(thirdNotes);
		}
	}

	void SetImage(char[] parameters)
	{
		for (int i = 0; i < 6; i++)
		{
			switch (parameters[i])
			{
				case 'a':
					notes[i] = Instantiate(onCymbal,notes[i].transform);
					break;
				case 's':
					notes[i] = Instantiate(onFrypan,notes[i].transform);
					break;
				case 'd':
					notes[i] = Instantiate(onHarisen,notes[i].transform);
					break;
					
			}
		}
	}

	void DeleteImage(char[] parameters)
	{
		for (int i = 0; i < 6; i++)
		{
			Destroy(notes[i]);
		}
	}
}
