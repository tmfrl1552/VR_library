using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scaleList : MonoBehaviour {
	private GameObject target;
	public GameObject cube;
    public GameObject board;
   // public GameObject info;
	public GameObject cate;
	public GameObject Rank;
	public int a=1;
	[SerializeField][Range(0f, 1f)]
	private float speed = 1f;
	private float yPos =0f,runningTime=0f; 
	private bool movingObj = false;
	string sample;
	private float turnspeed = 1.0f;
	public int booknum;
    public int isbig = 0;
    //public categoryAPI cateS = new categoryAPI(); 

    Vector3 position1;
	Vector3 scale1;
	Vector3 position2;
	Vector3 scale2;

	void Start(){
		a = 1;
		position1= transform.position;
		scale1 = transform.localScale;
		cube.SetActive (false);
	//	info.SetActive (false);
        board.SetActive(false);
    }

	public void ChangeScale(){
		a=1;
		transform.localScale = scale1;
		transform.position = position1;
		cube.SetActive (false);
        board.SetActive(false);
        movingObj = false;
		Rank.SetActive(true);
        isbig = 0;
    }
    public void SelectBook() //책 선택
    {
        if (isbig == 0)
        {
            /*abcd = GameObject.Find("category").GetComponent<categoryAPI>();
            for(int i = 0; i < abcd.bookinfo.Length; i++)
            {
                Debug.Log("info: " + abcd.bookinfo[i].text);
            }*/
            scale2.x = 2;
            scale2.y = 3;
            scale2.z = 0.3f;
            position2.x = -1.24f;
            position2.y = 3.0f;
            position2.z = -1.2f;
            transform.localScale = scale2;
            transform.position = position2;
            cube.SetActive(true);
            board.SetActive(true);
            movingObj = true;
            Rank.SetActive(false);
        }
    }
    // Update is called once per frame
    void Update () {
		if(movingObj == true)
		{
			//ScaleUp된 obj를 상하로 약간만 움직이는 코드작성
			runningTime += Time.deltaTime * speed;
			yPos = Mathf.Sin(runningTime) * 0.09f +1;
			//Debug.Log(yPos);
			transform.position = new Vector3(transform.position.x, yPos, transform.position.z);
		}
	}


}
