using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using static CommonPopup;

public enum ePlayStep
{
    step_GameStart = 1, 
    step_LevelUp = 3,
    step_SKILLSelect = 4,
    step_GameOver = 5,
}

public enum eWorldObject
{
    Unknown,
    Arrow,
    Player,
    Enemy,
    Boss
}

public enum eJsonType
{
    Unknown = 0,
    MasteryBook = 1, //Drop
    statSkill = 2,
    unitInfo = 3,
    bowInfo = 4,
    skillInfo = 5,
}

public enum LanguageType
{
    LT_ENG = 0,
    LT_KOR,
    LT_CN,
    LT_JP,
    LT_TW,
    LT_NONE,
    LT_SP
}

public enum eButtonUi
{
    None = -1,
    Inventory = 0,
    Upgrade = 1,
    Shop = 2,
}
public enum ePPType
{
    User_Bow = 0,
    User_LOGIN_TYPE_INT = 1,
    TEST_STRING = 2,
}
public enum eEventType
{
    //��� �̺�Ʈ Ÿ���̴�
    Language = 0,
}
//���� ���ǻ��� Instanceȭ �� ������ �̸��� ���ƾ��Ѵ�.
public enum eUnitStat
{
    None = 0,
    GreenGoblin = 1,
    RedGolin = 2,
}
//�Ʊ� ����
public enum eUnitType
{
    Enemy = 0,
    Hero = 1,
}

public enum eAttackType
{
    Melee = 0,
    RangeAttack =1,
}


public enum eScenes
{
    None = -1,
    TitleScene = 0,
    Loading = 1,
    LobbyScene = 2,
    InGameScene = 3,
    InGamePvPScene = 4,
}

public enum ePopupType
{
    Ok = 0,
    No = 1,
    YesNo = 2,
}

public static class Global
{
    public static readonly string LoginPanelName = "LoginPanel";

    public static Dictionary<ePlayStep, Action> inGameStepAction;

    public static Action onStart;
    public static Action onLeveUp;
    public static Action onGameover;
    public static Action onSkillselect;

    public static void SetUp()
    {
        Global.inGameStepAction = new Dictionary<ePlayStep, Action>();
        Global.inGameStepAction.Add(ePlayStep.step_GameStart, onStart);
        Global.inGameStepAction.Add(ePlayStep.step_LevelUp, onLeveUp);
        Global.inGameStepAction.Add(ePlayStep.step_SKILLSelect, onSkillselect);
        Global.inGameStepAction.Add(ePlayStep.step_GameOver, onGameover);
    }



    /// <summary>
    ///  �켱 �Ķ��� ���� �̺�Ʈ�ΰ��� �˼��ִ� ����Ÿ������ �����ߴ�.
    /// ������ �� ���������� ���ϰ� �Ķ��� ��뿡 �ǹ̰� ���°Ű��ٴ� ������ ���.
    /// </summary>
    public static Dictionary<eEventType, Action> eventList;

    public static event Action langCallback;

    public static eGameType curGameType;

    public static void Chainevent(eEventType eType, Action delEvent)
    {
        //���� ������
        //���߿� �ٸ������� Init�Լ� ���� ó��
        if(eventList == null)
        {
            eventList = new Dictionary<eEventType, Action>();
            eventList.Add(eEventType.Language, langCallback);
        }

        eventList[eType] += delEvent;
    }

    public static void Action(eEventType eType)
    {
        eventList[eType]?.Invoke();
    }

   

    public static CommonPopup CreateCommonPopup(string title, string desc, ePopupType type, UnityAction towYes, UnityAction towNo)
    {
        var go = ResourceManager.Instance.Instantiate("CommonPopup", LobbyUiManager.Instance.root);
        CommonPopup popup = go.GetComponent<CommonPopup>();
        popup.titleText.text = title;
        popup.descText.text = desc;
        popup.type = type;

        popup.towYes.onClick.AddListener(towYes);
        popup.towNo.onClick.AddListener(towNo);
        return popup;
    }

    public static CommonPopup CreateCommonPopup(string title, string desc, ePopupType type,UnityAction ok)
    {

        var go = ResourceManager.Instance.Instantiate("CommonPopup", LobbyUiManager.Instance.root);
        CommonPopup popup = go.GetComponent<CommonPopup>();
        popup.titleText.text = title;
        popup.descText.text = desc;
        popup.type = type;

        popup.oneOk.onClick.AddListener(ok);

        return popup;
    }



    public const string TAG_ENEMY = "Enemy";
}
