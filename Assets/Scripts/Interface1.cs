using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;


public enum eGameType
{
    None = -1, //현 게임상태가 존재하지않다면 상태는 항상 None을 의미해야한다.
    Default = 0, //기본 디펜싱의 기능만을 가지고있는 게임타입을 의미한다.
    Special = 1, //특수 기능의 게임이다 추후 확장성을 위해 남겨둔다.
}

public interface IDontwork
{
    public void DontMove();
}

/// <summary>
/// 주요 게임 프래임 매우 중요
/// </summary>
public abstract class InGameStepObject : MonoBehaviour
{
    
    protected virtual void Awake()
    {
        Global.inGameStepAction[ePlayStep.step_GameStart] += OnGameStart;
        Global.inGameStepAction[ePlayStep.step_LevelUp] += OnLevelUp;
        Global.inGameStepAction[ePlayStep.step_GameOver] += OnGameOver;
        Global.inGameStepAction[ePlayStep.step_SKILLSelect] += OnSkillSelecte;
    }

    protected virtual void OnEnable()
    {
    }

    protected virtual void OnDestroy()
    {
        Global.inGameStepAction[ePlayStep.step_GameStart] -= OnGameStart;
        Global.inGameStepAction[ePlayStep.step_LevelUp] -= OnLevelUp;
        Global.inGameStepAction[ePlayStep.step_GameOver] -= OnGameOver;
        Global.inGameStepAction[ePlayStep.step_SKILLSelect] -= OnSkillSelecte;
    }

    protected virtual void OnGameStart()
    {
        
    }

    protected virtual void OnLevelUp()
    {
        try
        {
            gameObject.SetActive(false);
        }
        catch (Exception ex)
        {

        }
    }

    protected virtual void OnSkillSelecte()
    {
        try
        {
            gameObject.SetActive(true);
        }
        catch (Exception ex)
        {

        }
        
    }


    protected virtual void OnGameOver()
    {
        gameObject.SetActive(false);
    }
}

public abstract class DataManager
{
    public DataManager()
    {
        InitData();
    }

    /// <summary>
    /// 유닛 데이터 로드
    /// </summary>
    public abstract void InitData();
}