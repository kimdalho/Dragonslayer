using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitSpawner : Spawner
{
    public int FactoryNumber;

    public bool stopFactory = false;

    public bool canFly = false;

  
    public void CreateMonster()
    {
        //TODO: Instance화 unitInfoDataList[n].path로 수정필요
        //GameObject go = ResourceManager.Instance.Instantiate("Monster/GreenGoblin");

        //유닛정보 가져온다.
        var spawnUnit = TableContainer.unitInfoDataMgr.GetUnitInfoData(0);
        //생성
        GameObject go = ResourceManager.Instance.Instantiate(spawnUnit.path);
        if (go == null)
        {
            go = ResourceManager.Instance.Instantiate("Monster/TestMonster");
            Debug.LogWarning("존재하지 않습니다.");
        }

        //초기화
        var baseunit = go.GetComponent<TestMonster>();
        
        baseunit.Setup();
        baseunit.SetInfo();
        //좌표 초기화
        go.transform.position = this.transform.position;
    }


    public void CreateHero()
    {
        //TODO: Instance화 unitInfoDataList[n].path로 수정필요
        //GameObject go = ResourceManager.Instance.Instantiate("Monster/GreenGoblin");

        //유닛정보 가져온다.
        var spawnUnit = TableContainer.unitInfoDataMgr.GetUnitInfoData(0);
        //생성
        GameObject go = ResourceManager.Instance.Instantiate(spawnUnit.path);
        if (go == null)
        {
            go = ResourceManager.Instance.Instantiate("Monster/TestHero");
            Debug.LogWarning("존재하지 않습니다.");
        }

        //초기화
        var baseunit = go.GetComponent<TestMonster>();

        baseunit.Setup();
        baseunit.SetInfo();
        //좌표 초기화
        go.transform.position = this.transform.position;
    }




    public void StartFactory()
    {
        stopFactory = false;
    }

    public void DontMove()
    {
        stopFactory = true;
    }
}
