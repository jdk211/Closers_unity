using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Town_Rotate_Cloud_Sc : MonoBehaviour {

	void Start () {
		
	}
	
	void Update () {
        this.gameObject.transform.Rotate(Vector3.down * Time.deltaTime);
	}
}
