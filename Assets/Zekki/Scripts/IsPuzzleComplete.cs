using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsPuzzleComplete : MonoBehaviour {

    public static GameObject[,] pieces = new GameObject[4, 4]; // パズルピース
    private int number;
    void Start () {
        for (int i = 0; i < 4; ++i)
        {
            for (int j = 0; j < 4; ++j)
            {
                number = 4 * i + j;
                pieces[i, j] = GameObject.Find("PuzzlePieces_" + number.ToString());
            }
        }
    }
	
	void Update () {
        if (IsComplete()) Debug.Log("Clear!!!!!!");
	}

    private bool IsComplete()
    {
        int number;
        for (int i = 0; i < 4; i++)
        {
            for(int j = 0; j < 4; j++)
            {
                number = 4 * i + j;
                if (pieces[i, j].transform.localPosition != new Vector3(number % 4, 3 - number / 4))
                {
                    return false;
                }
            }
        }
        return true;
    }
}
