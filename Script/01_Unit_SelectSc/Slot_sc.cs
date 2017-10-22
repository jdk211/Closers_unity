using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slot_sc : MonoBehaviour {

    public  Image    m_UnitImg     = null;
    public  Text     m_UnitInfoTxt = null;
    public  string nickname;
    public  int      m_no;

    void Start () {
		
	}
	
	void Update () {
		
	}

    void ClickSlotNumber()
    {
        GameManager.Instance.SelectUnitNum = m_no;
        GameManager.Instance.unitNickname = nickname;
    }
}
