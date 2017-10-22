using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NameManager : MonoBehaviour {
    [Range(0, 1000)]
    public float y;
    public GameObject obj;
    public Camera camera;

	// Use this for initialization
	void Start () {
    }
	
	// Update is called once per frame
	void Update () {
        Vector3 screenPos = camera.WorldToScreenPoint(this.transform.position);
        float x = screenPos.x;

        obj.transform.position = new Vector3(x, screenPos.y + y, obj.transform.position.z);
    }
}
