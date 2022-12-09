using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ������ ���� Ŭ�����̴�
/// ������ ������ ó������ �������� �Ǵ� ���� ���� ������ �� ��� ������ �� Ŭ�������� �����Ѵ�.
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
