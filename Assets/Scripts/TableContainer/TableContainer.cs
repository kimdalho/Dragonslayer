using System.Collections.Generic;
using UnityEngine;
public class TableContainer : Singleton<TableContainer>
{
    public static BowTableManager bowInfoDataMgr;
    public static UnitInfoDataManager unitInfoDataMgr;
    public static SkillInfoManager skillInfoMgr;


    private void Awake()
    {
        Setup();
    }

    public void Setup()
    {
        unitInfoDataMgr = new UnitInfoDataManager();
        bowInfoDataMgr = new BowTableManager();
        skillInfoMgr = new SkillInfoManager();
    }
}

[System.Serializable]
public class masteryBookArr
{
    public JosnMasteryData[] masteryBook;
}

[System.Serializable]
public class JosnMasteryData
{
    public uint id;
    public int canactivate;
    public uint rankFloor;

    public int nextid;
    public uint cost;
    public string statSkill;
}
