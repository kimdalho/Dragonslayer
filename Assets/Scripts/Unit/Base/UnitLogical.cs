using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitLogical : MonoBehaviour
{
    public eUnitAiType curType;
    [SerializeField]
    public InGameUnitInfo info;
    public bool die;

    public void SetInfo(UnitInfoData data)
    {
        info = data.info;

    }

    public InGameUnitInfo GetInfo()
    {
        return info;
    }

    public void SetCurType(eUnitAiType value)
    {
        curType = value;
    }

    public void SetHealth(int value)
    {
        info.health = value;
    }

    public int GetExp()
    {
        if (info.dropExp <= 0)
            info.dropExp = 3;

        return info.dropExp;
    }

    public void SetDead(eUnitAiType type)
    {
        curType = type;
    }
}
