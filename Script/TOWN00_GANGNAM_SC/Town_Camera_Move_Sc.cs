using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//처음 TOWN00씬에 입장하면 카메라 무빙을 한다.

public class Town_Camera_Move_Sc : MonoBehaviour
{
    public Transform[] CameraMoveObj_Tf = new Transform[7];
    public Transform MainCamera_Tf = null;
    public Transform CharacterCamera_Tf = null;

    private float MoveSpd = 5.0f;

    public int MoveObjIndex
    {
        get;set;
    }

    void Start()
    {
        MoveObjIndex = 1;
    }

    void Update()
    {
        MainCamera_Tf.position = CameraMoveObj_Tf[0].position;

        MoveCamera();
    }

    void MoveCamera()
    {
        //if(MoveObjIndex < CameraMoveObj_Tf.Length)
        //{
        //    //A -> B 이동, CameraMove_Collision에서 MoveObjIndex를 변경시켜준다.
        //    Vector3 vec3Dir = CameraMoveObj_Tf[MoveObjIndex].position - CameraMoveObj_Tf[0].position;
        //    vec3Dir.Normalize();
        //    CameraMoveObj_Tf[0].Translate(vec3Dir * (Time.deltaTime * MoveSpd));

        //    //A -> B 회전
        //    MainCamera_Tf.transform.rotation = Quaternion.Slerp(MainCamera_Tf.rotation,
        //                                                        CameraMoveObj_Tf[MoveObjIndex].rotation, Time.deltaTime);
        //}
        //else if(MoveObjIndex >= CameraMoveObj_Tf.Length)
        //{
            MainCamera_Tf.position = CharacterCamera_Tf.position;
            MainCamera_Tf.rotation = CharacterCamera_Tf.rotation;
        //}
    }
}