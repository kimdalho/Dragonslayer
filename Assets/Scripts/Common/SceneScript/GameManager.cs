using UnityEngine;
using System.Collections.Generic;
using System;
using System.Collections;

public enum eGameStapType
{
    None = 0,
    Ready = 1,
    Start = 2,
    Playing = 3,
    LevelUp = 4,
    SelectSkill = 5,
}
/// <summary>
/// 게임 매니저는 더 위 상위 DefaultGame에 의해 처리된다.
/// </summary>

public class GameManager : Singleton<GameManager>
{
    private const int ZERO = 0;


    public bool gameOver = false;
    [SerializeField] MonsterFactory factoryMgr;


    [Header("Editor inster")]

    public int curExp = ZERO;
    public int curLevel = ZERO;
    public Dictionary<int, int> levelList;
    public Action refreshCallback;

    public Player[] players;
    public Player curPlayer;

    public ePlayStep curStep
    {
        get { return _curStep; }
        set { _curStep = value; }
    }

    public ePlayStep _curStep;


    //이거 날린다.
    public AiPlayer aiPlayer;
    public CharacterMovement player;

    public Action<BaseSkill> arrowUpgradAction;

    private void OnEnable()
    {
        Global.inGameStepAction[ePlayStep.step_GameStart] += OnStart;
        Global.inGameStepAction[ePlayStep.step_GameOver] += OnGameOver;

    }

    private void OnDestroy()
    {
        Global.inGameStepAction[ePlayStep.step_GameStart] -= OnStart;
        Global.inGameStepAction[ePlayStep.step_GameOver] -= OnGameOver;
    }

    private void Start()
    {
        SetStep(ePlayStep.step_GameStart);
    }



    public void SetStep(ePlayStep step)
    {
        curStep = step;
        Global.inGameStepAction[curStep].Invoke();
    }



    public void OnStart()
    {
        LevelTableDataSetup();
        refreshCallback += UiRefresh;
        StartCoroutine(CoAnimStart());
    }


    public void OnGameOver()
    {
        gameOver = true;
    }

    private IEnumerator CoAnimStart()
    {
        yield return StartCoroutine(InGameUiManager.Instance.CoPlayStartAnim());
        player.Setup();
        aiPlayer.Setup();
    }



    public void CheckLevelUp()
    {
        int conditionExp = levelList[curLevel];

        if (conditionExp <= curExp)
        {
            curLevel++;

        }
    }



    private void Update()
    {
        //ReStart
        if(Input.GetKeyDown(KeyCode.X))
        {
            SceneContianer.Instance.LoadScene(eScenes.InGameScene);
        }
        //Level Up
        else if (Input.GetKeyDown(KeyCode.S))
        {
            SetStep(ePlayStep.step_LevelUp);
        }
        else if (Input.GetKeyDown(KeyCode.B))
        {
            SetStep(ePlayStep.step_GameOver);
        }

    }
    private void LevelTableDataSetup()
    {
        levelList = new Dictionary<int, int>();
        levelList.Add(0, 50);
        levelList.Add(1, 100);
        levelList.Add(2, 300);
        levelList.Add(3, 500);
    }

    private void UiRefresh()
    {
        InGameUiManager.Instance.expTmp.text = curExp.ToString();

    }

}