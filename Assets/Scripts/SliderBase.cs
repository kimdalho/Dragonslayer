using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// ����
/// </summary>
public abstract  class SliderBase : InGameStepObject
{
    /// <summary>
    /// �ִ�ġ �ѹ��� ���ǵȴ�.
    /// </summary>
    public int maxValue;
    /// <summary>
    /// ���� ��
    /// </summary>
    public int curxValue;
    public Slider slider;

    /// <summary>
    /// ��ǥġ�� sliderValue�� 0~1
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
