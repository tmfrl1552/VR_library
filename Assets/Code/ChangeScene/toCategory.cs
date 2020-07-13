//버튼 누르면 카테고리 선택하는 화면으로 씬전환

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class toCategory : MonoBehaviour {

	public void ChangeGameScene(){
		SceneManager.LoadScene ("category");
	}	
}
