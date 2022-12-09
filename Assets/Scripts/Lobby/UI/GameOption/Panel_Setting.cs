using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Collections;
using UnityEngine.Networking;

/// <summary>
/// Panel_Setting 싱글톤 객체인 GameOption을 제어하기 위한 컨트롤러이다.
/// </summary>


public class Panel_Setting : Base_Panel
{
    //푸쉬알람을 받을것인가
    private const string PUSH_STRING = "PLAYER_PUSH";
    
    bool[] connect = new bool[3] { false,false,false };


    enum eButtons
    {
        SettingButton = 0,

    }
    public enum eSliders
    {
        BG_Slider = 0,
    }

    public enum eUiToggles
    {
        AlarmToggle = 0,
    }

    private void Start()
    {
        Init();
    }


    public override void Init()
    {
        //LobbyUiManager.Instance.panel_stack.Push(OnEscape);

        //푸쉬
        bool push_flag = PlayerPrefs.GetInt(PUSH_STRING) > 0 ? true : false;
        connect[0] = push_flag;

        Bind<Button>(typeof(eButtons));
        Bind<Slider>(typeof(eSliders));
        Bind<UiToggle>(typeof(eUiToggles));

        Get<Button>("SettingButton").onClick.AddListener(OnEscape);
    }

    public override void OnEscape()
    {
        Destroy(gameObject);
    }
    public void OnClicked_Plus(Slider slider)
    {
        float value = slider.value;
        value += 0.1f;
        if (1f <= value) value = 1f;
        slider.value = value;
    }

    public void OnClicked_Minus(Slider slider)
    {
        float value = slider.value;
        value -= 0.1f;
        if (1f <= value) value = 1f;
        slider.value = value;
    }


    private void OnClickedLangKor()
    {
        GameOption.CurrentLanguage = LanguageType.LT_KOR;
    } 


}
