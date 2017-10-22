using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoginPanelScript : MonoBehaviour {

    private IDictionary<string, string> m_dicLoginData = new Dictionary<string, string>();

    public InputField IDInput       = null;
    public InputField PWInput       = null;
    public InputField JoinIDInput   = null;

    public GameObject JoinPanel     = null;
    public GameObject LoginFailed   = null;

    // Use this for initialization
    void Start () {
        IDInput.Select();
    }
	
	// Update is called once per frame
	void Update () {
        IDPWTab();
    }

    private void IDPWTab()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (IDInput.isFocused) PWInput.Select();
            else IDInput.Select();
        }
    }

    private void LoadCharaterSelectScene()
    {
        CompareID();
    }

    private void FailedBtnOK()
    {
        LoginFailed.SetActive(false);
        IDInput.text = "";
        PWInput.text = "";
        IDInput.Select();
    }

    private void JoinPanelActive()
    {
        JoinPanel.SetActive(true);
        JoinIDInput.Select();
    }

    private void CompareID()
    {
        m_dicLoginData.Add("ID", IDInput.text);
        m_dicLoginData.Add("PW", PWInput.text);

        http helper = http.Instance;
        helper.OnHttpRequest += OnHttpRequest;
        helper.post(100, "/Login", m_dicLoginData);
        
        m_dicLoginData.Clear();
    }

    void OnHttpRequest(int id, WWW www)
    {
        Debug.Log(www.text);
        if (www.error == null)
        {
            Debug.Log(www.text);
            SceneManager.LoadScene("CharacterSelectScene");
        }
        else
        {
            Debug.Log("[Error] " + www.error);
            LoginFailed.SetActive(true);
        }

        http helper = http.Instance;
        helper.OnHttpRequest -= OnHttpRequest;
    }
}
