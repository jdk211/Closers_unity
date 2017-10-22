using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    private static GameManager sInstance;
    public static GameManager Instance
    {
        get
        {
            if(sInstance == null)
            {
                GameObject newGameObject = new GameObject("_GameManager");
                sInstance = newGameObject.AddComponent<GameManager>();
            }
            return sInstance;
        }
    }

    public int SelectUnitNum;   //CharacterSelect Scene에서 선택된 Slot Number를 저장
    public string unitNickname;
    public bool isTown;

    private void Awake()
    {
        //Application.runInBackground = true;
        DontDestroyOnLoad(this.gameObject);
    }
}
