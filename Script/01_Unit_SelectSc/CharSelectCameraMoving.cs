using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharSelectCameraMoving : MonoBehaviour {

    public GameObject StartLine = null;
    public GameObject FinishLine = null;
    public GameObject Camera = null;

	// Use this for initialization
	void Start () {
        Camera.transform.position = StartLine.transform.position;
        Camera.transform.rotation = StartLine.transform.rotation;
	}
	
	// Update is called once per frame
	void Update () {
        //A -> B 이동
        Vector3 center = (Camera.transform.position + FinishLine.transform.position) * 0.5F;
        center -= new Vector3(0, 1, 0);
        Vector3 riseRelCenter = Camera.transform.position - center;
        Vector3 setRelCenter = FinishLine.transform.position - center;
        Camera.transform.position = Vector3.Slerp(riseRelCenter, setRelCenter, Time.deltaTime);
        Camera.transform.position += center;

        //A -> B 회전
        Camera.transform.rotation = Quaternion.Slerp(Camera.transform.rotation, FinishLine.transform.rotation, Time.deltaTime);
    }
}