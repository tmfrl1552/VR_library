using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scaleSearch : MonoBehaviour
{
    private GameObject target;
    public GameObject cube;
    //public GameObject info;
    //public GameObject cate;
    public int a = 1;
    [SerializeField]
    [Range(0f, 1f)]
    private float speed = 1f;
    private float yPos = 0f, runningTime = 0f;
    private bool movingObj = false;
    string sample;
    private float turnspeed = 1.0f;
    public int booknum;
    public int isbig = 0;
    public GameObject board;

    Vector3 position1;
    Vector3 scale1;
    Vector3 position2;
    Vector3 scale2;
    GameObject[] aa;
    categoryAPI abcd;

    void Start()
    {
        board.SetActive(false);
        position1 = transform.position;
        scale1 = transform.localScale;
        //info.SetActive(false);
        cube.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (movingObj == true)
        {
            //ScaleUp된 obj를 상하로 약간만 움직이는 코드작성
            runningTime += Time.deltaTime * speed;
            yPos = Mathf.Sin(runningTime) * 5f;
            //Debug.Log(yPos);
            transform.position = new Vector3(transform.position.x, yPos+70, transform.position.z);
        }
        
    }

    public void SelectBook() //책 선택
    {
        if (isbig == 0)
        {
            scale2.x = 50;
            scale2.y = 53;
            scale2.z = 10;
            position2.x = -56.1f;
            position2.y = 46.6f;
            position2.z = 90.4f;
            transform.localScale = scale2;
            transform.localPosition = position2;
            cube.transform.position = new Vector3(board.transform.position.x - 40, board.transform.position.y + 35, board.transform.position.z - 7);
            cube.SetActive(true);
            board.SetActive(true);
            movingObj = true;
            isbig = 1;
        }
    }

    public void ChangeScale()
    {
        a = 1;
        transform.localScale = scale1;
        transform.position = position1;
        cube.SetActive(false);
        board.SetActive(false);
        movingObj = false;
        //Rank.SetActive(true);
        isbig = 0;
    }
}
