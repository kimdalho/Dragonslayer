using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class ExpSlider : SliderBase
{

    public int level = 1;

    public override void Setup(int maxData)
    {
        maxValue = maxData;
        curxValue = 0;
        slider.value = 0f;
        targetValue = 0f;
    }

    // Start is called before the first frame update
    protected override void OnGameStart()
    {
        Setup(100 * level);
    }

    public void Zero()
    {
        curxValue = 0;
        slider.value = 0f;
        targetValue = 0f;
    }

    public void RefreshUi()
    {
        curxValue = GameManager.Instance.curExp;

        if (curxValue >= maxValue)
        {
            level += 1;
            Setup(100 * level);

            GameManager.Instance.SetStep(ePlayStep.step_LevelUp);
            return;
        }

        targetValue = (float)curxValue / (float)maxValue;
    }
    /* public void Hit(int damage)
 {
     curxHp -= damage;

     if (curxHp < 0)
     {
         curxHp = 0;
         hpbar.value = 0f;
         return;
     }

     target = (float)curxHp / (float)maxHp;

     //hpbar.value = (float)curxHp / (float)maxHp ;
 }*/

}
