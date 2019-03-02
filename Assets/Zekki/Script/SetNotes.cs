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

	void Start () {
		for (int i = 0; i < 6; i++)
		{
			firstNotes[i] = elements[Random.Range(0, 3)];
			secondNotes[i] = elements[Random.Range(0, 3)];
			thirdNotes[i] = elements[Random.Range(0, 3)];
		}
	}
	
	void Update () {
		
	}

	void setImage(char[] parameters)
	{
		
	}
}
