using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 연산을 위한 클래스이다
/// 몬스터의 데미지 처리이후 생존여부 또는 생존 이후 라이프 등 모든 연산을 이 클래스에서 서비스한다.
/// </summary>


public static class GameOperatorManager 
{
    public static void Hit(Arrow arrow, BaseMonster targetMonster)
    {
        int curTargetHealth = targetMonster.GetInfo().health;
        curTargetHealth -= arrow.GetAtk();
        if(curTargetHealth > 0)
        {
            targetMonster.SetHealth(curTargetHealth);
        }
        else
        { 
            GameManager.Instance.curExp += targetMonster.GetExp();
            targetMonster.SetDead(eUnitAiType.Die);
            GameManager.Instance.refreshCallback.Invoke();

            GameManager.Instance.CheckLevelUp();

        }
        arrow.SelfDestroy();
    }

}
