using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class SkillInfoData
{
    //public int id;
    //public int condition;
    //public InGameUnitInfo info;
    //public eUnitType unitType;
    //public eUnitStat unitStat;
    //public eAttackType attackType;
}

public class SkillInfoManager : DataManager
{
    public Dictionary<int, SkillInfoData> skillInfoDataList;


    public override void InitData()
    {

    }

    public SkillInfoData GetUnitInfoData(int id)
    {
        return skillInfoDataList[id];
    }
}

