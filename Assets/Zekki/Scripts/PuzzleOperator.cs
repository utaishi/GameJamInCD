﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PuzzleOperator : MonoBehaviour {

    public static GameObject[,] pieces = new GameObject[4, 4]; // パズルピース
    private bool[] x= new bool[] { true, false };
    public GameObject emptyPieces;
    private AudioSource SE;

    static void Swap(GameObject a, GameObject b)
    {
        var t = a.transform.position;
        a.transform.position = b.transform.position;
        b.transform.position = t;
        
    }                                                                          

    void Start()
    {
        //パズルをランダム生成
        //ピース16枚にそれぞれランダムで相対座標(0<=x<=3,0<=y<=3)を入れる
        x = x.OrderBy(a => Guid.NewGuid()).ToArray();
        int number; // パズルピースのナンバー(0-indexed)
        for (int i = 0; i < 4; ++i)
        {
            for(int j = 0; j < 4; ++j)
            {
                number = 4 * i + j;
                pieces[i, j] = GameObject.Find("PuzzlePieces_" + number.ToString());
                pieces[i, j].transform.localPosition = new Vector3(number % 4, 3 - number / 4);
            }
        }
        for(int i = 0; i < 100; i++)
        {
            for(int j = 0; j < 3; j++)
            {
                for(int k = 0; k < 3; k++)
                {
                    x = x.OrderBy(a => Guid.NewGuid()).ToArray();
                    if (x[0])
                    {
                        Swap(pieces[j, k], pieces[j, k + 1]);
                    }
                }
            }
        }
        for (int i = 0; i < 100; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                for (int k = 0; k < 3; k++)
                {
                    x = x.OrderBy(a => Guid.NewGuid()).ToArray();
                    if (x[0])
                    {
                        Swap(pieces[k, j], pieces[k + 1, j]);
                    }
                }
            }
        }
        emptyPieces = GameObject.Find("PuzzlePieces_14");
        SE = GetComponent<AudioSource>();
    }



    void Update ()
    {
        // 入れ替えられるピースは色を変える

        SelectDisplay();

        //十字キーでカーソル移動、Spaceキーで移動
        // PuzzlePieces_14はSprite Rendererをオフにしている
        // そのためPuzzlePieces_14(pieces[3, 2])とその周囲をswapすればよい
        if (Input.GetKey(KeyCode.UpArrow))
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                LoopDirection(Vector3.up, SE);
            }
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                LoopDirection(Vector3.down, SE);
            }
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                LoopDirection(Vector3.right, SE);
            }
            
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                LoopDirection(Vector3.left, SE);
            }
            
        }
    }

    private void LoopDirection(Vector3 direction, AudioSource se)
    {
        for(int i = 0;i < 4; i++)
        {
            for(int j = 0; j < 4; j++)
            {
                if(pieces[i, j].transform.localPosition == direction + emptyPieces.transform.localPosition)
                {
                    Swap(pieces[i, j], emptyPieces);
                    se.PlayOneShot(SE.clip);
                    return;
                }
            }
        }
    }

    private void SelectDisplay()
    {
        for(int i = 0; i < 4; i++)
        {
            for(int j = 0; j < 4; j++)
            {
                pieces[i, j].GetComponent<SpriteRenderer>().color = Color.white;
            }
        }
        for(int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                if (pieces[i, j].transform.localPosition == Vector3.up + emptyPieces.transform.localPosition)
                {
                    pieces[i, j].GetComponent<SpriteRenderer>().color = new Color(0.5130f, 0.5622f, 0.5943f);
                }
                if (pieces[i, j].transform.localPosition == Vector3.down + emptyPieces.transform.localPosition)
                {
                    pieces[i, j].GetComponent<SpriteRenderer>().color = new Color(0.5130f, 0.5622f, 0.5943f);
                }
                if (pieces[i, j].transform.localPosition == Vector3.right + emptyPieces.transform.localPosition)
                {
                    pieces[i, j].GetComponent<SpriteRenderer>().color = new Color(0.5130f, 0.5622f, 0.5943f);
                }
                if (pieces[i, j].transform.localPosition == Vector3.left + emptyPieces.transform.localPosition)
                {
                    pieces[i, j].GetComponent<SpriteRenderer>().color = new Color(0.5130f, 0.5622f, 0.5943f);
                }
            }
        }
    }
}
