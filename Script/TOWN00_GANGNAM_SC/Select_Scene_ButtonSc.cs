using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Select_Scene_ButtonSc : MonoBehaviour {

    public GameObject TownObj = null;

    private IDictionary<string, string> m_UnitData = new Dictionary<string, string>();

    void Start () {
		
	}
	
	void Update () {

    }

    private void RecruitButton()
    {
        SceneManager.LoadScene("RecruitScene");
    }

    //private void MemberFire()
    //{
    //    m_UnitData.Add("Num", GameManager.Instance.SelectUnitNum.ToString());
    //    Debug.Log(GameManager.Instance.SelectUnitNum.ToString());
    //    http helper = http.Instance;
    //    helper.OnHttpRequest += OnHttpRequest;
    //    helper.post(100, "/DeleteUnit", m_UnitData);
    //}

    private void BackButton()
    {
        //http helper = http.Instance;
        //helper.OnHttpRequest += OnHttpRequest;
        //helper.get(100, "/Logout");
        SceneManager.LoadScene("LoginScene");
    }

    private void GameStart()
    {
        if(GameManager.Instance.SelectUnitNum > 0)
        {
            TownObj.SetActive(true);
        }
    }

    void OnHttpRequest(int id, WWW www)
    {
        Debug.Log(www.text);
        if (www.error != null)
        {
            Debug.Log("[Error] " + www.error);
        }
        else
        {
            Debug.Log(www.text);
        }

        http helper = http.Instance;
        helper.OnHttpRequest -= OnHttpRequest;
    }

}
