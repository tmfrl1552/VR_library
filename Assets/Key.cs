using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Key : MonoBehaviour
{
    public string kor_s;
    public string kor_b;
    public string En_s;
    public string En_b;
    public Text T;

    // Start is called before the first frame update
    void Start()
    {
        T = GetComponent<Text>();
    }
}
