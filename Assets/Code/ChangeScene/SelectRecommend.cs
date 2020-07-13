using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectRecommend : MonoBehaviour
{
    // Start is called before the first frame update
    public void ToBest()
    {
        SceneManager.LoadScene("BestSeller");
    }

    // Update is called once per frame
    public void ToNew()
    {
        SceneManager.LoadScene("NewSpecial");
    }
    public void ToBlogger()
    {
        SceneManager.LoadScene("BlogBest");
    }
}
