using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeControl : API
{
    public GameObject[] cube;
    private int arraysize;
    private float pos = 2;

    // Use this for initialization
    void Start()
    {
        arraysize = SearchBookNum;
        cube = new GameObject[arraysize];
        for (int i = 0; i < arraysize; i++)
        {
            cube[i] = GameObject.CreatePrimitive(PrimitiveType.Cube);  //큐브 오브젝트 생성
            cube[i].transform.position = new Vector3(pos*i, 1, 0);  //큐브 포지션 설정
            cube[i].transform.localScale = new Vector3(1, 1.2f, 0.3f);
        }
    }
    
}
