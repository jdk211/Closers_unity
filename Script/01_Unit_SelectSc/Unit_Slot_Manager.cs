using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//
using LitJson;
using System.IO;
using System.Linq;
//
public class Unit_Slot_Manager : MonoBehaviour
{
    public Sprite[] JobImg = new Sprite[11];

    enum SPRITENAME
    {
        STRIKER,
        CASTER,
        RANGER,
        FIGHTER,
        LANCER,
        HUNTER,
        WITCH,
        ROGUE,
        ARMS,
        VALKYRIE,
        NULL
    }

    GameObject Slot = null;

    // Use this for initialization
    void Start()
    {
        LoadPrefebs();
        InitSlot();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void LoadPrefebs()
    {
        if (Slot == null)
        {
            Slot = Resources.Load<GameObject>("Prefabs/Slot");
        }
    }

    void InitSlot()
    {
        http helper = http.Instance;
        helper.OnHttpRequest += OnHttpRequest;
        helper.get(100, "/UnitList");
    }

    void OnHttpRequest(int id, WWW www)
    {
        if (www.error == null)
        {

            string row = www.text;
            Debug.Log(row);

            JsonData UnitList_DB = JsonMapper.ToObject(row);
            //슬롯에 정보 입력
            if(UnitList_DB.Count > 0)
            {
                for (int i = 0; i < UnitList_DB.Count; i++)
                {
                    GameObject obj = Instantiate(Slot, Vector3.zero, Quaternion.identity) as GameObject;

                    obj.transform.parent = gameObject.transform;
                    obj.transform.localPosition = new Vector3(-17.9f, 276.8f - (i * 81.6f), 0.0f);

                    Slot_sc in_slot = obj.GetComponent<Slot_sc>();
                    in_slot.m_no = int.Parse((string)UnitList_DB[i]["num"]);
                    in_slot.nickname = (string)UnitList_DB[i]["nickname"];
                    int spriteIndex = SpriteNameCatch((string)UnitList_DB[i]["job"]);
                    in_slot.m_UnitImg.sprite = JobImg[spriteIndex];

                    in_slot.m_UnitInfoTxt.text = "LV " + (string)UnitList_DB[i]["level"] + "\n\n" + (string)UnitList_DB[i]["nickname"];
                }
            }
            //빈슬롯 처리
            for (int i = UnitList_DB.Count; i < 6; i++)
            {
                //x = -17.9, y0 = 276.8, y1 = 195.2
                GameObject obj = Instantiate(Slot, Vector3.zero, Quaternion.identity) as GameObject;

                obj.transform.parent = gameObject.transform;
                obj.transform.localPosition = new Vector3(-17.9f, 276.8f - (i * 81.6f), 0.0f);

                Slot_sc in_slot = obj.GetComponent<Slot_sc>();
                in_slot.m_no = (i + 1);
                in_slot.m_UnitImg.sprite = JobImg[(int)SPRITENAME.NULL];
                in_slot.m_UnitInfoTxt.text = "새 맴버 영입";
            }
        }
        else
        {
            Debug.Log("[Error] " + www.error);
        }

        http helper = http.Instance;
        helper.OnHttpRequest -= OnHttpRequest;
    }

    private int SpriteNameCatch(string jobName)
    {
        switch (jobName)
        {
            case "STRIKER":
                return (int)SPRITENAME.STRIKER;
            case "CASTER":
                return (int)SPRITENAME.CASTER;
            case "RANGER":
                return (int)SPRITENAME.RANGER;
            case "FIGHTER":
                return (int)SPRITENAME.FIGHTER;
            case "LANCER":
                return (int)SPRITENAME.LANCER;
            case "HUNTER":
                return (int)SPRITENAME.HUNTER;
            case "WITCH":
                return (int)SPRITENAME.WITCH;
            case "ROGUE":
                return (int)SPRITENAME.ROGUE;
            case "ARMS":
                return (int)SPRITENAME.ARMS;
            case "VALKYRIE":
                return (int)SPRITENAME.VALKYRIE;
            default:
                return (int)SPRITENAME.NULL;
        }
    }
}


//씬 변경시 사라질것으로 생각됨
//void DestroyObj()
//{
//    Transform[] childObj = gameObject.GetComponentsInChildren<Transform>();

//    for (int i = 0; i < itemNameString.Length; i++)
//    {
//        Destroy(childObj[i].gameObject);
//    }
//}