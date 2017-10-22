using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove_Collision : MonoBehaviour {

    public GameObject obj = null;
    Town_Camera_Move_Sc MoveIndex;

    void Start () {
        MoveIndex = obj.GetComponent<Town_Camera_Move_Sc>();
    }
	
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        //CameraMoveCube가 움직이면서 부딪힌 다음 Target의 Index++ 해준다.
        if (other.name == MoveIndex.CameraMoveObj_Tf[MoveIndex.MoveObjIndex].name) MoveIndex.MoveObjIndex++;
    }
}
