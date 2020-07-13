using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BookInput : API
{
    //[SerializeField] private Text txt_Book; //출력할 책 이름
    [SerializeField] private InputField inputTxT_Book; //입력받은 책 이름
    [SerializeField] [Range(0f, 1f)] private float speed = 1f;

    public string url = "http://www.aladin.co.kr/ttb/api/ItemSearch.aspx?ttbkey=ttbanny5051756001&QueryType=Title&MaxResults=10&start=1&SearchTarget=Book&output=js";
    public string newURL; // 검색한 책에 대한 url
    private string currentBook; // 현재 책 이름
    public Search query = new Search();

    //그려낼 cube를 위한 선언
    //검색 시 생길 책 오브젝트 관련 배열
    public GameObject[] cube;

    protected int arraysize;
    private float pos = 2.7f;

    //click 시에 나올 정보를 위한 선언
    private GameObject target;
    private GameObject CurrentBookTarget; //현재 선택된 bookobj
    //public GameObject background;
    public GameObject[] info;
    public GameObject BackButton;
    public GameObject Cam;  // maincamera
    public GameObject keyboard;  // virtual keyboard
    public GameObject loading;
    //public InputField input;
    private string txt;
    string text1;
    string text2;
    private bool movingObj = false;
    private int a = 1;
    private float runningTime = 0f;
    private float yPos = 0f;

    Vector3 position1;
    Vector3 scale1;
    Vector3 position2;
    Vector3 scale2;
    Vector3 CamPosReset;


    void Start()
    {
        keyboard.SetActive(false);
        //background.SetActive(false);
        //info.SetActive(false);
        BackButton.SetActive(false);
        loading.SetActive(false);
        CamPosReset = Cam.transform.position;
    }

    void Update()
    {

        

    }

    public void SearchInput()
    {
        //가상 키보드를 안보이게 함
        keyboard.SetActive(false);

        //inputTxT_Book.DeactivateInputField();

        //Camera를 처음 위치로 이동시키기(Cam position reset)
        Cam.transform.position = CamPosReset;

        //cube object reset 하기
        ResetCube();

        //검색어로 api에서 불러오기
        currentBook = inputTxT_Book.text;
        newURL = url + "&Query=" + currentBook;


        WWW request = new WWW(newURL);
        StartCoroutine(OnResponse(request));
    }


    public IEnumerator OnResponse(WWW req)
    {
        yield return req;
        Debug.Log("Text Start");
        string json = req.text;

        json = json.Replace(";", ""); //마지막 ; 없애기
        json = json.Replace("\\'", "*");
        json = json.Replace("&lt", "*");
        json = json.Replace("&gt", "*");
        Debug.Log(json);

        query = JsonUtility.FromJson<Search>(json); //이제 여기서 item(책) 추출해야 함
        SearchBookNum = query.item.Length;

        //받아온 개수로 cube 그려내기
        arraysize = SearchBookNum;
        Debug.Log("arraysize : " + arraysize);
        //cube = new GameObject[arraysize];

        loading.SetActive(true);
        for (int i = 0; i < arraysize; i++)
        {
            //cube[i] = GameObject.CreatePrimitive(PrimitiveType.Cube);  //큐브 오브젝트 생성
            cube[i].SetActive(true);

            //오브젝트 텍스쳐 변경
            query.item[i].CoverReplace();
            string image = query.item[i].cover;

            WWW www = new WWW(image);
            yield return www;
            cube[i].GetComponent<Renderer>().material.mainTexture = www.texture;
            text1 = "";
            text2 = "";

            for (int z = 0; z < query.item[i].title.Length; z++)
            {
                text1 += query.item[i].title[z];
                if (z % 27 == 26) text1 += "\n";
            }

            for (int z = 0; z < query.item[i].description.Length; z++)
            {
                text2 += query.item[i].description[z];
                if (z % 27 == 26) text2 += "\n";
            }

            txt = "제목 : " + text1 + "\n\n저자 : " + query.item[i].author
                     + "\n\n출판사 : " + query.item[i].publisher + "\n\n출간일: " + query.item[i].pubDate
                     + "\n\n정가 : " + query.item[i].priceStandard + "\n\n" + text2;

            info[i].GetComponent<TextMesh>().text = txt;

        }
        loading.SetActive(false);
        Debug.Log("End");
    }


    //cube array를 초기화시키는 함수
    public void ResetCube()
    {
        for (int i = 0; i < arraysize; i++)
        {
            cube[i].SetActive(false);
        }
    }


    public void ClickInput()
    {
        keyboard.SetActive(true);
        Debug.Log("Keyboard Click!");
    }
}
