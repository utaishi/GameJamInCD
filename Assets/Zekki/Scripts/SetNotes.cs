using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetNotes : MonoBehaviour
{
	public char[,] problemNotes = new char[6, 6];
	private char[] elements = {'a', 's', 'd'};
	public GameObject[] notes;
	public GameObject[] notesImages;
	public GameObject onCymbal;
	public GameObject onFrypan;
	public GameObject onHarisen;
	public GameObject inputText;
	private TypingText _typingText;

	void Start () {
		for (int i = 0; i < 6; i++)
		{
			problemNotes[0, i] = elements[Random.Range(0, 3)];
			problemNotes[1, i] = elements[Random.Range(0, 3)];
			problemNotes[2, i] = elements[Random.Range(0, 3)];
			problemNotes[3, i] = elements[Random.Range(0, 3)];
			problemNotes[4, i] = elements[Random.Range(0, 3)];
			problemNotes[5, i] = elements[Random.Range(0, 3)];
		}
		SetImage(problemNotes,0);

		_typingText = inputText.GetComponent<TypingText>();
	}
	
	void Update () {
		
	}

	public void ChangeImage()
	{
		DeleteImage();
		int count = _typingText.clearCount;
		SetImage(problemNotes, count);
	}

	void SetImage(char[,] parameters, int x)
	{
		for (int i = 0; i < 6; i++)
		{
			switch (parameters[x,i])
			{
				case 'a':
					notesImages[i] = Instantiate(onCymbal,notes[i].transform);
					break;
				case 's':
					notesImages[i] = Instantiate(onFrypan,notes[i].transform);
					break;
				case 'd':
					notesImages[i] = Instantiate(onHarisen,notes[i].transform);
					break;
			}
		}
	}

	void DeleteImage()
	{
		for (int i = 0; i < 6; i++)
		{
			Destroy(notesImages[i]);
		}
	}
}
