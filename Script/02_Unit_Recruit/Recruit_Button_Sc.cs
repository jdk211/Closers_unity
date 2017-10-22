using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Recruit_Button_Sc : MonoBehaviour {

    public GameObject       InputName     = null;
    public GameObject       RangerIller   = null;
    public InputField       InputNickName = null;
    public Text             introduceText = null;
    public Image            nameImg       = null;
    public RawImage         videoImg      = null;
    public SpriteRenderer   unitIller     = null;
    public AudioSource      audio         = null;
    public Sprite[]         nameSprite    = new Sprite[10];

    private string          SelectJobName;
    private MovieTexture    videoPlayer;
    
    private IDictionary<string, string> m_UnitData = new Dictionary<string, string>();

    void Start () {
        SelectJobName = "RANGER";
        videoPlayer = videoImg.GetComponent<PlayVdieoOnCanvas>().movie;
    }

    private void Recruit_Before()
    {
        SceneManager.LoadScene("CharacterSelectScene");
    }

    private void Recruit_OK()
    {
        InputName.SetActive(true);
        InputNickName.Select();
    }

    private void Recruit_Input_Name_OK()
    {
        //캐릭터 생성이 된다.
        Debug.Log(InputNickName.text);

        MakeUnit();

        InputName.SetActive(false);
    }

    private void Recruit_Input_Name_Cancel()
    {
        InputNickName.text = "";
        InputName.SetActive(false);
    }

    void MakeUnit()
    {
        m_UnitData.Add("Job", SelectJobName);
        m_UnitData.Add("NickName", InputNickName.text);
        m_UnitData.Add("Num", GameManager.Instance.SelectUnitNum.ToString()); //UnitList 몇번째 Slot 인지

        http helper = http.Instance;
        helper.OnHttpRequest += OnHttpRequest;
        helper.post(100, "/RecruitUnit", m_UnitData);

        m_UnitData.Clear();
    }

    void OnHttpRequest(int id, WWW www)
    {
        Debug.Log(www.text);
        if (www.error == null)
        {
            Debug.Log(www.text);
            audio.clip = Resources.Load<AudioClip>("Image/02_UNIT_RECRUIT/Sound/CREATE_GUST_USER_" + SelectJobName + "_2") as AudioClip;
            audio.Play();
            SceneManager.LoadScene("CharacterSelectScene");
        }
        else
        {
            Debug.Log("[Error] " + www.error);
        }

        http helper = http.Instance;
        helper.OnHttpRequest -= OnHttpRequest;
    }

    public void Select_01(bool selectToggle)
    {
        ChangeJob("위상력을 모아서 폭발시킬 수 있는 건블레이드를 이용해 강력한 공격을 가하는 근거리 폭발형 클로저. 차원전쟁의 영웅이자" +
            "전설적인 클로저인 '알파 퀸'을 어머니로 두고 있는 소년, 뛰어난 잠재력으로 검은양 팀에 합류하기는 했으나, 아직 임무를 완벽하게" +
            "수행해야 한다는 의식이 부족한 편이다.", "STRIKER", 0);
    }
    public void Select_02(bool selectToggle)
    {
        ChangeJob("위상력을 활용한 염동력과 대기를 컨트롤하는 공격이 전매특허인 원거리 초자연 능력계 클로저. 부모가 차원종에 의해 목숨을 잃고" +
            "국가 시설에 맡겨져 유년 시절을 보낸 소녀, 검은양 팀의 리더이며, 위상 잠재력이 높지 않음에도 순수한 노력으로 최우수 졸업장을 딴 노력파이다." +
            "", "CASTER", 1);
    }
    public void Select_03(bool selectToggle)
    {
        ChangeJob("뛰어난 운동 신경으로 순간적으로 거리를 좁혀 리펄서 블레이드로 적을 난도질하고, " +
            "페이즈 건과 체술을 이용하는 중거리 스피드형 하이브리드 클로저. 위상능력이 뒤늦게 각성되어 " +
            "위상력을 컨트롤하는 것에 아직 미숙하기 때문에 유니온의 보조 도구들을 활용하는 편이다. " +
            "검은양 팀 맴버 중 가장 정식요원이 되려는 열망이 강하다.", "RANGER", 2);
    }
    public void Select_04(bool selectToggle)
    {
        ChangeJob("체력을 한순간 끌어올려 폭발적인 힘과 순발력을 응축시키는 근거리 격투형 클로저. 과거 차원 전쟁에 투입되어 심각한 부상을 입고" +
            "퇴역했으나 유니온 관계자의 부탁으로 검은양 팀에 가담했다. 현재는 위상력이 거의 남아있지 않으며 부작용도 있지만, 노련한 경험과" +
            "은둔 시절의 위상력 호흡법, 심신 보조제 등으로 떨어진 기량을 커버하고 있다.", "FIGHTER", 3);
    }
    public void Select_05(bool selectToggle)
    {
        ChangeJob("차원 소환 능력을 활용하여 긴 사정거리와 강력한 파괴력을 지닌 다수의 창 공격을 가하는 중거리 서포트형 클로저. 태어날 때부터" +
            "놀라운 위상 잠재력을 보여준 유니온의 차세대 기대주이다. 독일 베를린의 유니온 유럽 지부로부터 한국의 신서울로 파견 지역이 변경되어" +
            " 검은양 팀에 합류하게 된 정체불명의 소년.", "LANCER", 4);
    }
    public void Select_06(bool selectToggle)
    {
        ChangeJob("강적과의 전투를 즐기고, 한번 흥분하면 통제불능 상태로 적에게 돌진하는 늑대개 팀의 대원. 입이 거칠고, 때때로 자신의 감정을 제대로" +
            " 통제하지 못하는 모습을 보인다. 자신을 통제하고 있는 벌처스를 증오하고 있고, 언젠가 자신을 가두고 부려먹은 녀석들을 모두 죽여버린 뒤" +
            ", 자유를 쟁취하고 말 것이라는 열망을 품고 있다.", "HUNTER", 5);
    }
    public void Select_07(bool selectToggle)
    {
        ChangeJob("싸움을 싫어하고, 어째서인지 인간과 유사한 위상력을 사용할 수 있는 차원종. 모종의 사건으로 인해 늑대개 팀의 임시대원으로 임명되었고," +
            "싸움을 강요받게 된다. 비록 싸움을 싫어하는 그녀이지만, 인간의 지시대로 움직이는 것이 당연하다고 생각하고 있기에, 어쩔 수 없이 늑대개 팀의 " +
            "처리 임무에 동참하게 된다.", "WITCH", 6);
    }
    public void Select_08(bool selectToggle)
    {
        ChangeJob("늑대개 팀의 전력 부족을 해소하기 위해, 감시관 홍시영이 데려온 공중전의 전문가. 홍시영의 측근으로, 그녀의 지시에 따라 늑대개 팀의" +
            "처리 업무에 동참하는 한편, 트레이너를 비롯한 다른 늑대개 팀 대원들을 견제하는 역할 또한 은밀히 수행 중에 있다." +
            "우아하면서도 날렵한 몸놀림으로 상대를 농락하는 전투 스타일을 취한다.", "ROGUE", 7);
    }
    public void Select_09(bool selectToggle)
    {
        ChangeJob("위상력 창출이 가능한 전투 로봇, 오래 전부터 트레이너의 측근으로 활동해왔다. 공간을 효과적으로 활용하는 원거리 공격형 캐릭터인" +
            " 동시에 대공 공격에 특화되어 있어서, 대공 공격 시에 적에게 더 많은 피해를 줄 수 있다. 또 한 다양한 무기를 소환해 각종 돌발상황에 " +
            "안정적으로 대처할 수 있기도 하다.", "ARMS", 8);
    }
    public void Select_10(bool selectToggle)
    {
        ChangeJob("바이올렛은 위상장비 개발 기업인 벌처스 사장의 외동딸로, 위상력의 운용과 관련된 엘리트 교육을 받아왔다. 그녀는 일시적으로 " +
            "자신의 육체를 강화시키는 능력을 구사하고, 그 능력을 바탕으로 대검을 자유자재로 휘두르며 적을 유린한다. 그리고 그런 바이올렛을, 비서인" +
            " 하이드가 은밀히 보필하고 있다. 아버지의 계획을 위해, 그리고 자신의 야망을 위해, 아가씨가 검을 뽑아들었다.","VALKYRIE", 9);
    }

    private void ChangeJob(string text, string job, int index)
    {
        introduceText.text = text;
        SelectJobName = job;

        audio.clip = Resources.Load<AudioClip>("Image/02_UNIT_RECRUIT/Sound/CREATE_GUST_USER_" + job + "_1") as AudioClip;
        audio.Play();

        videoPlayer = Resources.Load<MovieTexture>("Image/02_UNIT_RECRUIT/Movie/MOVIE_" + job) as MovieTexture;
        videoPlayer.Stop();

        videoImg.GetComponent<RawImage>().texture = videoPlayer;
        videoImg.color = new Color(255, 255, 255);

        videoPlayer.Play();

        if (job == "RANGER")
        {
            unitIller.sprite = null;
            RangerIller.SetActive(true);
        }
        else
        {
            RangerIller.SetActive(false);
            unitIller.sprite = Resources.Load<Sprite>("Image/02_UNIT_RECRUIT/IMG/DLG_PVP_JUNIOR_LOADING_GUST_USER_" + job);
        }

        nameImg.sprite = nameSprite[index];
        nameImg.rectTransform.sizeDelta = new Vector2(nameSprite[index].rect.width, nameSprite[index].rect.height);
    }

}
