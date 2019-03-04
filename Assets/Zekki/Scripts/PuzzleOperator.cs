using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PuzzleOperator : MonoBehaviour {

    public static GameObject[,] pieces =  new GameObject[4, 4]; // パズルピース
    int[] x = new int[] { 0, 1, 2, 3 };
    int[] y = new int[] { 0, 1, 2, 3 };

    static void Swap<T>(ref T a, ref T b)
    {
        var t = a;
        a = b;
        b = t;
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
    }

    int selectX = 0;
    int selectY = 0;
    public GameObject emptyPieces = GameObject.Find("PuzzlePieces_14");

    void Update ()
    {
        //十字キーでカーソル移動、Spaceキーで移動
        // PuzzlePieces_14はSprite Rendererをオフにしている
        // そのためPuzzlePieces_14(pieces[3, 2])とその周囲をswapすればよい
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            for(int i = 0; i < 4; i++)
            {
                for(int j = 0; j < 4; j++)
                {
                    if(pieces[i, j].transform.localPosition == Vector3.up + emptyPieces.transform.localPosition)
                    {
                        if (Input.GetKeyDown(KeyCode.Space))
                        {
                            Debug.Log("up");
                            Swap(ref pieces[i, j], ref emptyPieces);
                        }
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
                        if (Input.GetKeyDown(KeyCode.Space))
                        {
                            Debug.Log("down");
                            Swap(ref pieces[i, j], ref emptyPieces);
                        }
                    }
                }
            }
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (pieces[i, j].transform.localPosition == Vector3.right + emptyPieces.transform.localPosition)
                    {
                        if (Input.GetKeyDown(KeyCode.Space))
                        {
                            Debug.Log("right");
                            Swap(ref pieces[i, j], ref emptyPieces);
                        }
                    }
                }
            }
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (pieces[i, j].transform.localPosition == Vector3.left + emptyPieces.transform.localPosition)
                    {
                        if (Input.GetKeyDown(KeyCode.Space))
                        {
                            Debug.Log("left");
                            Swap(ref pieces[i, j], ref emptyPieces);
                        }
                    }
                }
            }
        }
    }
}
