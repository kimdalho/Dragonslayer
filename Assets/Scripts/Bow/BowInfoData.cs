using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class BowInfoData
{
    public int id;
    public string name;
    public string testName;
    public int level;
    public float atk;
    public float speed;
    public float range;
    public string sprite;
}

public class BowTableManager : DataManager
{
    public Dictionary<int, BowInfoData> bowInfoDataList = new Dictionary<int, BowInfoData>();


    public override void InitData()
    {
        var DataArr = Jsonparser.LoadJsonFile<BowInfoData>(eJsonType.bowInfo);

        foreach(var theData in DataArr)
        { 
            bowInfoDataList.Add(theData.id, theData);
        }
    }

    public bool BowInfoListExistData(int id)
    {
        return bowInfoDataList.ContainsKey(id);
    }

    public int BowInfoListCount()
    {
        return bowInfoDataList.Count;
    }

    public BowInfoData GetBowInfoData(int id)
    {
        if (bowInfoDataList.ContainsKey(id) == true)
        {
            return bowInfoDataList[id];
        }
        else
        {
            Debug.Log("���������ʴ� ���̵� ������ Ȯ���߽��ϴ� ����Ʈ�� ��ȯ�մϴ�");
            return bowInfoDataList[0];
        }

    }
}

