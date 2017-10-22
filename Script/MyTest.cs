using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyTest : MonoBehaviour
{
    IDictionary<string, string> _data = new Dictionary<string, string>();

    // Use this for initialization
    void Start()
    {
        _data.Add("name", "asdf");
        _data.Add("pass", "asdf");
        http helper = http.Instance;
        helper.OnHttpRequest += OnHttpRequest;
        helper.post(100, "/test", _data);
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