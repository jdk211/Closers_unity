using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//
using System.IO;
using UnityEngine.UI;
//

public class JoinPanelScript : MonoBehaviour {

    private IDictionary<string, string> m_dicJoinData = new Dictionary<string, string>();

    public InputField IDInput       = null;
    public InputField PWInput       = null;
    public InputField LoginIDInput  = null;

    public GameObject SuccessPanel  = null;
    public GameObject FailedPanel   = null;

    // Use this for initialization
    void Start () {
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void JoinDisableActive()
    {
        ResetInput();
        this.gameObject.SetActive(false);

        LoginIDInput.Select();
    }

    private void JoinOK()
    {
        PlayerJoinMake();
    }

    private void PlayerJoinMake()
    {
        m_dicJoinData.Add("ID", IDInput.text);
        m_dicJoinData.Add("PW", PWInput.text);

        http helper = http.Instance;
        helper.OnHttpRequest += OnHttpRequest;
        helper.post(100, "/Join", m_dicJoinData);

        m_dicJoinData.Clear();
    }
    
    private void FailedBtnOK()
    {
        ResetInput();
        IDInput.Select();
        FailedPanel.SetActive(false);
    }

    private void SuccessBtnOK()
    {
        ResetInput();
        SuccessPanel.SetActive(false);
        this.gameObject.SetActive(false);
        LoginIDInput.Select();
    }

    private void ResetInput()
    {
        IDInput.text = "";
        PWInput.text = "";
    }

    void OnHttpRequest(int id, WWW www)
    {
        Debug.Log(www.text);
        if (www.error != null)
        {
            Debug.Log("[Error] " + www.error);
            FailedPanel.SetActive(true);
        }
        else
        {
            Debug.Log(www.text);
            SuccessPanel.SetActive(true);
        }

        http helper = http.Instance;
        helper.OnHttpRequest -= OnHttpRequest;
    }

}
