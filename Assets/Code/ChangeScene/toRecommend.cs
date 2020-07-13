using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class toRecommend : MonoBehaviour
{
    public void ChangeGameScene()
    {
        SceneManager.LoadScene("recomChoice");
    }
}
