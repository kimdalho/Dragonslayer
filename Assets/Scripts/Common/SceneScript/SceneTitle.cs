using System.Collections;
using UnityEngine;
using UnityEngine.UI;


public class SceneTitle : SceneBase
{

    private const string LOCAL_EMAIL_DATA = "localemailData";
    private const string LOCAL_PWD_DATA = "localpwdData";
  
    [SerializeField] UiLoginButtons loginButtons;
    [SerializeField] GameObject tabToStart;
    [SerializeField] Slider Slider;

    private bool clicked;

    CommonPopup curPopup;

    private void Start()
    {
        clicked = false;
        Global.SetUp();
    }
    public void TabToStart()
    {
        SceneContianer.Instance.LoadScene(eScenes.LobbyScene);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && !clicked)
        {
            int dataCount  =  PlayerPrefs.GetInt("AssetData");

            //에셋번들이 없다 가져와야한다.
            if (dataCount <= 0 && curPopup is null)
            {
                CommonPopup commonPopup = null;

                commonPopup = Global.CreateCommonPopup(
                    "Asset Downlaod",
                    "Would you like to \n download the game?",
                    ePopupType.YesNo,
                () =>
                    {
                        tabToStart.SetActive(false);
                        StartCoroutine(CoLoadAssetDownload());
                        Destroy(commonPopup.gameObject);

                    },//AssetDownLoad
                ()=>
                    {
                    }//Cancel
                );

                curPopup = commonPopup;

            }
            
            if(curPopup == null && dataCount > 0)
            {
                ShowLoginPopup();
            }
        }
    }

    private IEnumerator CoLoadAssetDownload()
    {
        Slider.gameObject.SetActive(true);
        Slider compo = Slider.GetComponent<Slider>();

        while (compo.value < 1)
        {
            compo.value += Time.deltaTime;
            yield return null;
        }

        CommonPopup commonPopup = null;

        commonPopup = Global.CreateCommonPopup(
        "Message",
        "Asset download is complete.",
        ePopupType.Ok,
        () =>
        {
            //탭 투 스타트가 나타나고
            tabToStart.SetActive(true);
            //로딩바가 닫히고
            Slider.gameObject.SetActive(false);
            //팝업창이 닫히고,
            Destroy(commonPopup.gameObject);
            //캐쉬는 생기고
            PlayerPrefs.SetInt("AssetData", 10);
        }//AssetDownLoad
        );


    }

    public void ShowLoginPopup()
    {
        clicked = true;
        var result = LoginStart();
        if (result)
        {
            //여기서부터는 플레이어 프리펩으로 로그인시도 코드 들어가야함
        }
        else
        {
            loginButtons.gameObject.SetActive(!result);
        }
    }


    public bool LoginStart()
    {
        //현제 시퀀스
        //탭을 누름
        //PlayerPrefab에 존재 여부 확인
        //없다면 로긴버튼들 활성화

        var emaildata = PlayerPrefs.GetString(LOCAL_EMAIL_DATA);
        var pwddata = PlayerPrefs.GetString(LOCAL_PWD_DATA);
        if (emaildata == "" || pwddata == "")
        {
            //저장된 아이디 데이터가 확인되지않는다 로그인을 할수있게끔 버튼리스트를 활성화시켜준다.
            return false;
        }
        return false;
    }
}