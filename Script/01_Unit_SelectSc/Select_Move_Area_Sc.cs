using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Select_Move_Area_Sc : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void Select_Area() // 캐릭터 선택 후 거점 지역 이동
    {
        SceneManager.LoadScene("Town_Loading_Scene");
    }

    private void MoveAreaCancel()
    {
        this.gameObject.SetActive(false);
    }
}
