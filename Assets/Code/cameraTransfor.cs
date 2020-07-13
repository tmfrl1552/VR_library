using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class cameraTransfor : MonoBehaviour
{
    public GameObject A;

    Vector3 pos = new Vector3(10.609f, 1.676f, -3.92f);
    public GameObject target;
    public GameObject start;
    public GameObject Recommend;
    public GameObject Search;
    public GameObject Category;
    int speed = 10;
    int a = 1;
    //Vector3 rot = transform.rotation.eulerAngles;
    Quaternion q;

    void Start()
    {
        Recommend.SetActive(false);
        Search.SetActive(false);
        Category.SetActive(false);
        a = 1;
        Vector3 rot = transform.rotation.eulerAngles;
        rot.y += 90;
        q = Quaternion.Euler(rot);

    }

    void Update()
    {
        if (Input.GetMouseButton(0))
            a = 2;

        if (a == 2)
        {
            A.transform.position = Vector3.Lerp(A.transform.position, pos, Time.deltaTime);
            transform.rotation = Quaternion.Slerp(transform.rotation, q, 2f);
            start.SetActive(false);
            Recommend.SetActive(true);
            Search.SetActive(true);
            Category.SetActive(true);

        }
    }
}


