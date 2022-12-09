using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 삭제
/// </summary>
public abstract  class SliderBase : InGameStepObject
{
    /// <summary>
    /// 최대치 한번만 정의된다.
    /// </summary>
    public int maxValue;
    /// <summary>
    /// 현재 값
    /// </summary>
    public int curxValue;
    public Slider slider;

    /// <summary>
    /// 목표치의 sliderValue값 0~1
    /// </summary>
    protected float targetValue;
    protected override void OnGameStart()
    {
        Setup(200);
    }


    public virtual void Setup(int maxData)
    {
        maxValue = maxData;
        curxValue = maxData;
        slider.value = 1f;
        targetValue = 1f;
    }



    private void Update()
    {
        slider.value = Mathf.Lerp(slider.value, targetValue, 0.1f);
    }

    public int GetHp()
    {
        return curxValue;
    }


}
