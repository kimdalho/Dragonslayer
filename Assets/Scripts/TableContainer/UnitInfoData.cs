using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEditor;


[Serializable]
public class InGameUnitInfo
{
    public int atk;
    public int def;
    public int health;
    public float speed;
    public int dropExp;
}

[Serializable]
public class UnitInfoData
{
    public int id;
    public int condition;
    public InGameUnitInfo info;
    public eUnitType unitType;
    public eUnitStat stat;
    public eAttackType attacktype;
    public string path;
}

public class UnitInfoDataManager : DataManager
{
    /// <summary>
    /// key : 레벨 넘버, value : 레벨에 해당하는 유닛 정보
    /// </summary>
    public Dictionary<int, List<UnitInfoData>> unitInfoDataList = new Dictionary<int, List<UnitInfoData>>();

    public override void InitData()
    {
        var testDataArr = Jsonparser.LoadJsonFile<UnitInfoData>(eJsonType.unitInfo);
     
        //레벨에 맞는 유닛끼리 Dic에 묶어서 넣기
        foreach(var theData in testDataArr)
        {
            UnitInfoData tempdata = theData;
            var curCondition = tempdata.condition;

            if (unitInfoDataList.ContainsKey(curCondition) == false)
            {
                unitInfoDataList.Add(curCondition, new List<UnitInfoData>());
                unitInfoDataList[curCondition].Add(tempdata);
            }
            else
            {
                unitInfoDataList[curCondition].Add(tempdata);
            }
            //TODO : 몬스터 상태 변경할 것.
            //theData.path = string.Format("{0}/{1}", "Monster", theData.stat.ToString());
            theData.path = string.Format("{0}/{1}", "Monster", eUnitStat.GreenGoblin.ToString());
        }

    }
   
    /// <summary>
    /// 컨디션에 맞는 랜덤한 유닛 반환
    /// </summary>
    /// <param name="condition"></param>
    /// <returns></returns>
    public UnitInfoData GetUnitInfoData(int condition)
    {
        int rnd = UnityEngine.Random.Range(0, unitInfoDataList[condition].Count);
        return unitInfoDataList[condition][rnd];
    }
}




