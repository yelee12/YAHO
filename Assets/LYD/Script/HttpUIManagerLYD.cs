using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using UnityEngine.UI;

public class HttpUIManagerLYD : MonoBehaviour
{
    //descPlay에 있는 inputField들임.
    public InputField inputTitle;
    public InputField inputContent;
    public Button calender;
    public Text calenderT;
    public Button btnOk;
    public Button btnCancel;
    public GameObject descdisplay;

    //체크리스트 한테 있는것들
    public GameObject checkdis;
    public InputField InputcheckTitle;
    public GameObject checkObject;
    public GameObject checkContent;

    //스크롤뷰에 생성될 프리팹(cardObject)와 그 위치(cardContent)를 넣어준다.
    public GameObject cardObject;
    public Transform cardContent;

    public GameObject meetingObject;
    public Transform meetingContent;

    public Dropdown dropdown_project;
    public Dropdown dropdown_meetingPro;
    public int idx;

    public Text _period1;
    public Text _period2;
    //옵션에 들어갈 프로젝트이름들
    public Dropdown.OptionData m_pNamedata;
    //프로젝트의 이름들을 담을 리스트들
    public List<Dropdown.OptionData> m_pName = new List<Dropdown.OptionData>();

    public Dropdown.OptionData meetingPNamedata;
    public List<Dropdown.OptionData> meetingPName = new List<Dropdown.OptionData>();

    public RealMemoUI memo;

    public Sprite frame32;


    //태그부분
    public GameObject btnDoing;
    public GameObject btnComplete;
    public GameObject image_tag;
    public GameObject preDoing;
    public GameObject preComplete;
    public Transform empty_tag;
    public Sprite frame38;

    string _title = "오늘 할 일";
    string _content = "무슨내용입니다.";
    string _checkTitle = "할 일";
   // int _tag = 0;

   // string _date = "2022-11-20";
    // Start is called before the first frame update
    void Start()
    {
        #region Listener
        inputTitle.onEndEdit.AddListener(Title);
        inputTitle.onSubmit.AddListener(Title);

        inputContent.onEndEdit.AddListener(Content);
        inputContent.onSubmit.AddListener(Content);

        InputcheckTitle.onEndEdit.AddListener(CheckTitle);
        InputcheckTitle.onSubmit.AddListener(CheckTitle);

        btnOk.onClick.AddListener(OnBtnOk);
        btnCancel.onClick.AddListener(OnBtnCancel);
        
        #endregion
    }

    /* public void tags(int i)
     {
         _tag = i;
         Debug.Log(i);
     }*/

    public int num;
   //태그 add 누르면 image_tag창이 뜬다. 
   public void TagAdd()
   {
        image_tag.SetActive(true);
        GameObject go = empty_tag.transform.GetChild(0).gameObject;
        if (go != null)
        {
            Destroy(go);
            num = 0;
        }
    }

    /*public void TagMinus()
    {
        //먼저 empty_tag의 자식을 찾는다.
        
        GameObject go = empty_tag.transform.GetChild(0).gameObject;
        if(go != null)
        {
            Destroy(go);
            num = 0;
        }
    }*/
    public void Doing()
    {
        GameObject go = Instantiate(preDoing, empty_tag);
        num = 0;
        image_tag.SetActive(false);

    }

    public void Complete()
    {
        GameObject go = Instantiate(preComplete, empty_tag);
        num = 1;
        image_tag.SetActive(false);

    }

    public void TagBtnX()
    {
        image_tag.SetActive(false);
    }

    public void Title(string s)
    {
        _title = s;
        Debug.Log(s);
    }

    public void Content(string s)
    {
        _content = s;
        Debug.Log(s);
    }

    public void CheckTitle(string s)
    {
        _checkTitle = s;
        Debug.Log(s);
    }
    public void OnBtnOk()
    {
        PostTodoList();
        //대신 수정하지 않았을 때는 눌러도 보내지지 않도록 만들어 놓을 것!

    }

    public void OnBtnAdd()
    {
        descdisplay.SetActive(true);
        if(inputTitle.text != null && inputContent.text != null)
        {
            inputTitle.text = "";
            inputContent.text = "";
        }
        calenderT.text = "0000-00-00";
    }

    public void OnCheckBtnAdd()
    {
        checkdis.SetActive(true);
        if(InputcheckTitle.text != null)
        {
            InputcheckTitle.text = "";
        }
    }

    public void OnCheckXBtn()
    {
        if(InputcheckTitle.text.Length < 1)
        {

        }
        else
        {

        }
        checkdis.SetActive(false);
    }
    public void OnTaskStart()
    {
        GetProject(1, "Y");
    }
    public void OnBtnCancel()
    {
        if (inputTitle.text.Length < 1 || inputContent.text.Length < 1)
        {

        }
        else
        {
            GetProject(1, "Y");

        }
        descdisplay.SetActive(false);

        //->안적을때는 그냥 함수가 실행되지 않도록 
    }
    // Update is called once per frame
    void Update()
    {
        //if(Input.GetKeyDown(KeyCode.Alpha0))
        //{
            //PostTodoList();
        //}

       /* if (Input.GetKeyDown(KeyCode.Z))
        {
            //여기서 멤버no  +프로젝트no 조회하도록 코드를 짜야한다.
            //x키를 눌렀을 때 이어지도록
            //취소버튼 누를 때 

            GetTodolist(1, 1);

        }

        if (Input.GetKeyDown(KeyCode.X))
        {
            GetProject(1, "Y");

        }*/

        
    }
    

    //descPlay 확인 버튼에 넣기 
    //todoList post 하기 
    public void PostTodoList()
    {
        HttpRequesterLYD requesterLYD = new HttpRequesterLYD();

        requesterLYD.url = "http://43.201.58.81:8088/todolist";
        requesterLYD.requestTypeLYD = RequestTypeLYD.POST;
        
        
        TodoListData data = new TodoListData();
        data.memberNo = 1; //이부분은 (자기번호) 저장되어있는 부분을 보내야하는것이 아닌가?
        data.projectNo = int.Parse(pjNum[index]);
        print("프젝넘버인덱스번호 : " + int.Parse(pjNum[index])); //이부분은 (병한오빠가 프젝명을 적으면 그걸로 갖고와서 하는것)
        data.dueDate = calenderT.text; //calender.ShowCalendar(target); 여기에 target이 안나옴// //내가 원하는 날짜 / 달력에서 체크한 부분 Text_Select_Data를 넣어주기  Text_Select_Data.text넣어줘야하는데 button클릭하고나서의 text값을 넣어줘야함.
        data.title = _title; //inputField 에 넣기
        data.content = _content; //inputField에 넣기
        data.tagNo = num; //0,1 로 가게 하면 되는데, 체크리스트가 클릭되면 이제 1로 되면서 태그가 변경되는것으로 보내져야한다. 
        requesterLYD.todoList = JsonUtility.ToJson(data, true);
        print(requesterLYD.todoList);

        requesterLYD.onComplete = OnCompleteSignIn;
        print("11111111111111");
        HttpManagerLYD.instance.SendRequestLYD(requesterLYD);
    }

    public void OnCompleteSignIn(DownloadHandler handler)
    {
        string s = "{\"data\":" + handler.text + "}";
        print(s);

        //data를 list<TodoListdata>에 넣기
        TodolistDataArray array = JsonUtility.FromJson<TodolistDataArray>(s);
        for(int i = 0; i < array.data.Count; i++)
        {
            print(array.data[i].memberNo + "\n" + array.data[i].projectNo + "\n" + array.data[i].dueDate + "\n" + array.data[i].title + "\n" + array.data[i].content + "\n" + array.data[i].tagNo);


        }
        print("조회완료");
    }

    //버튼에 넣을 함수 하나 더 만들기

    //드롭다운에 프로젝트가 떠야한다. //프로젝트 정보리스트 조회  //버튼에 넣을 함수를 하나 더 만들어줘서 거기 안에다가 GetProject값을 넣어주면 됨. 
    public void GetProject(int memberNum, string Y)
    {
        HttpRequesterLYD requesterLYD = new HttpRequesterLYD();

        requesterLYD.url = $@"http://43.201.58.81:8088/projects?memberNo={memberNum}&isProcess={Y}";
        requesterLYD.requestTypeLYD = RequestTypeLYD.GET;
        requesterLYD.onComplete = OnComepleteProject;

        HttpManagerLYD.instance.SendRequestLYD(requesterLYD);



    }

    public void OnComepleteProject(DownloadHandler handler)
    {
        JObject jobject = JObject.Parse(handler.text);
        print(jobject.ToString());
        

        //옵션을 클리어해주는게 맞나??? < 이부분은 물어보기>
        var d = dropdown_project.GetComponent<Dropdown>(); 
        //d.ClearOptions();
        //d.value = 1;
        var jsonP = jobject["data"];
        print("1111111" + jsonP);
        foreach (var j1 in jsonP)
        {
            //프로젝트의 이름을 dropdown options에 담아준다. 
            m_pNamedata = new Dropdown.OptionData();
            
            m_pNamedata.text = j1["projectName"].ToString();
           // print("111111111111" + m_pNamedata.text);
            m_pName.Add(m_pNamedata);
            //여기에서 생기는 프로젝트 넘버가 리스트? 안에 담겨서 gettodolist에 담겨야함. 1, 2
           // pjNum.Add(j1["projectNo"].ToString());
            // string s = dropdown_project.options[].text;
            //dropdown을 눌렀을 때마다 날짜가 바뀌어야한다. 
            startdate.Add(j1["projectPeriod"]["startDate"].ToString());
            endDate.Add(j1["projectPeriod"]["endDate"].ToString());
            // print("111111111111111111111" + j1["projectMemberLists"].ToString());

            pjNum.Add(j1["projectNo"].ToString());
           //이제 여기서 프로젝트 넘버랑 멤버 넘버를 꼽아가지고 gettodolist랑 연결해야됨.
           
           var jp = j1["projectMemberLists"];
           foreach(var j2 in jp)
           {
                print("프로젝트넘버 : " + j2["projectNo"].ToString());
                print("멤버 넘버 : " + j2["memberNo"].ToString());
           }

        }


        foreach (var m in m_pName)
        {
            //drop다운 옵션에 추가 - 프로젝트이름 (m이 프로젝트가 담겨 있는 이름 : 첫 프로젝트 , pn)
            d.options.Add(new Dropdown.OptionData() { text = m.text });

        }
        d.value = index;
        DropdwonpNameSelected(index);

        d.onValueChanged.RemoveAllListeners();
        d.onValueChanged.AddListener(ChangeDropDown);
        
    }

    List<string> startdate = new List<string>();
    List<string> endDate = new List<string>();
   public List<string> pjNum = new List<string>();
    public int index;

    void ChangeDropDown(int index)
    {
        DropdwonpNameSelected(index);
    }


    void DropdwonpNameSelected(int value)
    {

        index = value;

        _period1.text = startdate[index];
        _period2.text = endDate[index];

        //게시판 날리기 (게시판 안에 있는 카드를 날리기)
        GetTodolist(1, int.Parse(pjNum[index]));//int.Parse(pjNum[index]));
        print("11111111" + int.Parse(pjNum[index]));
        //이렇게되면 번호가 바뀔때마다 계속 생성이 됨. 그러면 어떻게해야할까?
        //-> 먼저 index는 0, 1만 나옴 0에는 첫번째 프로젝트 이름이, 1에는 2번째 프로젝트 이름 
        //->projectNo에 (1,2)는 잘 바뀌지만 2번 프로젝트에 아무런 to do list가 없으면 생성되지 않아햐한다.
        //버튼을 누를때마다 생성되는 것이 아니라 한번만 
        
    }

    //getTodolist를 하기 위해서는 

    public void GetTodolist(int memberNum, int projectNum)
    {
        
        HttpRequesterLYD requesterLYD = new HttpRequesterLYD();

        //post/1, get, 완료되었을 때 호출되는 함수
        requesterLYD.url = $@"http://43.201.58.81:8088/todolist?memberNo={memberNum}&projectNo={projectNum}";
        requesterLYD.requestTypeLYD = RequestTypeLYD.GET;
        requesterLYD.onComplete = OnCompleteGetPost;

        HttpManagerLYD.instance.SendRequestLYD(requesterLYD);
        
            
    }

    public Image btnImage;
    public Button btn;
    public Text t;
    public string tagNum;
    public void OnCompleteGetPost(DownloadHandler handler)
    {
        //제이슨 배열 안에 제이슨이 있을 때 원하는 값만 가져올 수 있도록
        JObject jobject = JObject.Parse(handler.text);
        print(jobject.ToString());

        var jsonkey = jobject["data"];
        /*for (int i = 0; i < ; i++)
        {
        
        }*/

        RemoveCard();

        foreach(var j1 in jsonkey)
        {
            
            //1. 스크롤뷰 content안에 title button이 (cardObject)생성되야함. 
            GameObject go = Instantiate(cardObject, cardContent);
           
            HttpManagerLYD.instance.Set(cardContent);
            go.GetComponentInChildren<Text>().text = j1["title"].ToString();
            _title = go.GetComponentInChildren<Text>().text;
            
            //체크박스
            btnImage = go.transform.GetChild(2).GetComponent<Image>();
            btn = go.transform.GetChild(2).GetComponent<Button>();
            t = go.transform.GetChild(2).GetComponentInChildren<Text>();


            //string으로 태그 번호를 받아서 
            tagNum = j1["tagNo"]["tagNo"].ToString();
            //만약 태그 번호가 1번이면 btnImage.sprite = frame32;,  //2. 버튼 인터렉터블 꺼주기 + 카드 
            //이부분은 체크리스트에서 하기 
            
            if(tagNum == "1")
            {
                btnImage.sprite = frame38;
                t.text = "완료";
                //inputTitle.interactable = false;

                //btn.interactable = false;
                //Button s = go.GetComponent<Button>();
                //s.interactable = false;
            }
            
            //inputContent.text = j1["content"].ToString();
            _content = j1["content"].ToString();
            
            calenderT.text = j1["dueDate"].ToString();

            memo = go.GetComponent<RealMemoUI>();
            memo.Set(_title, _content, calenderT.text, tagNum, descdisplay, btnImage, t, calender);//, btn);

            //타이틀이 8자리 이상이면 8자리 이후에 ...을 더해준다. 
            if (_title.Length > 8)
            {
                string a = _title.Substring(0, 8);
                _title =  a + "...";
            }
            //텍스트를 바꿨으므로 다시 _title에 적용을 시켜주는것 
            go.GetComponentInChildren<Text>().text = _title;
            // print(j1["projectNo"].ToString());
            //  print(j1["tagNo"]["tagName"].ToString());

        }
    }


    public void RemoveCard()
    {
         
        Transform[] projectParent = cardContent.GetComponentsInChildren<Transform>();
        if (projectParent != null)
        {
            for (int i = 1; i < projectParent.Length; i++)
            {
                if (projectParent[i] != transform)
                    Destroy(projectParent[i].gameObject);
            }
        }
    }


    //여기서 부터 <회의록>
    public void OnGetMeeting()
    {
        GetMeeting(1);
    }
    public void GetMeeting(int memberNum)
    {

        HttpRequesterLYD requesterLYD = new HttpRequesterLYD();

        //post/1, get, 완료되었을 때 호출되는 함수
        requesterLYD.url = $@"http://43.201.58.81:8088/projects?memberNo={memberNum}&isProcess=Y";
        requesterLYD.requestTypeLYD = RequestTypeLYD.GET;
        requesterLYD.onComplete = OnCompleteGetMeeting;

        HttpManagerLYD.instance.SendRequestLYD(requesterLYD);


    }

    List<string> MpNum = new List<string>();
    public void OnCompleteGetMeeting(DownloadHandler handler)
    {
        JObject jobject = JObject.Parse(handler.text);
        print(jobject.ToString());

        //옵션을 클리어해주는게 맞나??? < 이부분은 물어보기>
        var d = dropdown_meetingPro.GetComponent<Dropdown>();
        //d.ClearOptions();
        //d.value = 1;
        var jsonP = jobject["data"];
        print("1111111" + jsonP);
        foreach (var j1 in jsonP)
        {
            //프로젝트의 이름을 dropdown options에 담아준다. 
            meetingPNamedata = new Dropdown.OptionData();

            meetingPNamedata.text = j1["projectName"].ToString();
            // print("111111111111" + m_pNamedata.text);
            meetingPName.Add(meetingPNamedata);

            MpNum.Add(j1["projectNo"].ToString());
            print("2222222222222 : " +MpNum);
        }

        foreach (var m in meetingPName)
        {
            //drop다운 옵션에 추가 - 프로젝트이름 (m이 프로젝트가 담겨 있는 이름 : 첫 프로젝트 , pn)
            d.options.Add(new Dropdown.OptionData() { text = m.text });
            

        }
        d.value = idx;
        DropdwonmeetingPNameSelected(idx);

        d.onValueChanged.RemoveAllListeners();
        d.onValueChanged.AddListener(ChangeDropDown1);
    }

    void ChangeDropDown1(int idx)
    {
        DropdwonmeetingPNameSelected(idx);
    }


    void DropdwonmeetingPNameSelected(int value)
    {

        idx = value;

        //게시판 날리기 (게시판 안에 있는 카드를 날리기)
        GetMeetingData(int.Parse(MpNum[idx]));//int.Parse(pjNum[index]));
        print("11111111 : " + int.Parse(MpNum[idx]));
        

    }

    public void GetMeetingData(int proNum)
    {
        HttpRequesterLYD requesterLYD = new HttpRequesterLYD();

        //post/1, get, 완료되었을 때 호출되는 함수
        requesterLYD.url = $@"http://43.201.58.81:8088/meetings?projectNo={proNum}";
        requesterLYD.requestTypeLYD = RequestTypeLYD.GET;
        requesterLYD.onComplete = OnCompleteGetMeetingData;

        HttpManagerLYD.instance.SendRequestLYD(requesterLYD);
    }

    
    public void OnCompleteGetMeetingData(DownloadHandler handler)
    {
        JObject jobject = JObject.Parse(handler.text);
        print(jobject.ToString());

        RemoveMeetingCard();

        var Jm = jobject["data"];
        foreach(var j1 in Jm)
        {
           GameObject startTime = Instantiate(meetingObject, meetingContent);
           
            string mn = j1["meetingNo"].ToString();
            startTime.GetComponent<MeetingGetTest>().a = mn;
            string st = j1["meetingStartTime"].ToString().Substring(0, 10);
            //print(st);
            startTime.GetComponentInChildren<Text>().text = st;

        }
    }

    public void RemoveMeetingCard()
    {

        Transform[] projectParent = meetingContent.GetComponentsInChildren<Transform>();
        if (projectParent != null)
        {
            for (int i = 1; i < projectParent.Length; i++)
            {
                if (projectParent[i] != transform)
                    Destroy(projectParent[i].gameObject);
            }
        }
    }

   /* public void GetMeetingImage(int meetingNo)
    {
        HttpRequesterLYD requesterLYD = new HttpRequesterLYD();

        //post/1, get, 완료되었을 때 호출되는 함수
        requesterLYD.url = $@"http://43.201.58.81:8088/meetings/{meetingNo}";
        requesterLYD.requestTypeLYD = RequestTypeLYD.GET;
        requesterLYD.onComplete = OnCompleteGetMeetingImageData;

        HttpManagerLYD.instance.SendRequestLYD(requesterLYD);
    }

    public void OnCompleteGetMeetingImageData(DownloadHandler handler)
    {
        
    }
*/

}
