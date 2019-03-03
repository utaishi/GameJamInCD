using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PuzzleOperator : MonoBehaviour {

    public GameObject[,] pieces =  new GameObject[4, 4]; // パズルピース
    int[] x = new int[] { 0, 1, 2, 3 };
    int[] y = new int[] { 0, 1, 2, 3 };

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
                pieces[i, j].transform.localPosition = new Vector3(x[i], y[j], 0);
            }
        }
    }

    void Update ()
    {
        //十字キーでカーソル移動、Spaceキーで移動
    }
}
