﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PuzzleOperator : MonoBehaviour {

    public static GameObject[,] pieces =  new GameObject[4, 4]; // パズルピース
    private int[] x = new int[] { 0, 1, 2, 3 };
    private int[] y = new int[] { 0, 1, 2, 3 };
    public GameObject emptyPieces;

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
        y = y.OrderBy(a => Guid.NewGuid()).ToArray();
        int number; // パズルピースのナンバー(0-indexed)
        for (int i = 0; i < 4; ++i)
        {
            for(int j = 0; j < 4; ++j)
            {
                number = 4 * i + j;
                pieces[i, j] = GameObject.Find("PuzzlePieces_" + number.ToString());
                pieces[i, j].transform.localPosition = new Vector3(x[i], y[j]);
            }
        }

        emptyPieces = GameObject.Find("PuzzlePieces_14");
    }



    void Update ()
    {
        //十字キーでカーソル移動、Spaceキーで移動
        // PuzzlePieces_14はSprite Rendererをオフにしている
        // そのためPuzzlePieces_14(pieces[3, 2])とその周囲をswapすればよい
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {          
            for (int i = 0; i < 4; i++)
            {               
                for (int j = 0; j < 4; j++)
                {                   
                    if (pieces[i, j].transform.localPosition == Vector3.up + emptyPieces.transform.localPosition)
                    {                      
                        
                            Debug.Log("up!!!!");
                            Swap( pieces[i, j],  emptyPieces);
                            break;
                    }
                }
            }
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (pieces[i, j].transform.localPosition == Vector3.down + emptyPieces.transform.localPosition)
                    {
                        
                            Debug.Log("down");
                            Swap(pieces[i, j],emptyPieces);
                            break;
                    }
                }

            }
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                LoopRight();
            }
            
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                LoopLeft();
            }
            
        }
    }

    private void LoopLeft()
    {
        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                if (pieces[i, j].transform.localPosition == Vector3.left + emptyPieces.transform.localPosition)
                {
                    Swap(pieces[i, j], emptyPieces);
                    return;
                }
            }
        }
    }

    private void LoopRight()
    {
        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                if (pieces[i, j].transform.localPosition == Vector3.right + emptyPieces.transform.localPosition)
                {

                    Debug.Log("right");
                    Swap(pieces[i, j], emptyPieces);
                    return;
                }
            }
        }
    }
}
