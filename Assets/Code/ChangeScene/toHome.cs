using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class toHome : MonoBehaviour
{
    public void ChangeGameScene()
    {
        SceneManager.LoadScene("First");
    }
}
