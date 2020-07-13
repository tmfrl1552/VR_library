using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputClick : MonoBehaviour
{
    //public InputField input;
    public GameObject keyboard;
    //private InputField target;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.F2))
        {
            keyboard.SetActive(true);
        }
    }

}
