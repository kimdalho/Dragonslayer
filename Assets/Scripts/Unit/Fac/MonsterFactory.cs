using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;


public class MonsterFactory : UnitFactory<BaseMonster> 
{
  /*  public int FactoryNumber;

    private int taskCount;

    public bool stopFactory = false;

    public bool canFly = false;

    private IEnumerator Run()
    {
        while (true)
        {
            if (taskCount > 0 && stopFactory == false)
            {
                yield return new WaitForSeconds(1);
                GameObject go = ResourceManager.Instance.Instantiate("TestMonster");
                //초기화
                var baseunit = go.GetComponent<BaseUnit>();
                baseunit.canFly = canFly;

                //if(canFly)
                  //  baseunit.GetComponent<Rigidbody>().

                baseunit.Setup();
                baseunit.SetInfo();
                baseunit.SetHealth(1);
                //콜백
                PlayStateManager.Instance.event_StepChanged += go.GetComponent<BaseUnit>().event_StepChanged;
                //좌표 초기화
                go.transform.position = this.transform.position;
                //일 차감
                taskCount--;
                //리스트 담기
                UnitManager.Instance.AddMonsterList(go.GetComponent<BaseMonster>());
            }

            yield return null;
        }
    }

    private void CreateMonster()
    {
        //TODO: Instance화 unitInfoDataList[n].path로 수정필요
        //GameObject go = ResourceManager.Instance.Instantiate("Monster/GreenGoblin");

        //유닛정보 가져온다.
        var spawnUnit = TableContainer.unitInfoDataMgr.GetUnitInfoData(0);
        //생성
        GameObject go = ResourceManager.Instance.Instantiate(spawnUnit.path);
        //초기화
        var baseunit = go.GetComponent<BaseUnit>();
        baseunit.SetInfo(spawnUnit);
        baseunit.SetHealth(1);
        //콜백
        PlayStateManager.Instance.event_StepChanged += go.GetComponent<BaseUnit>().event_StepChanged;
        //좌표 초기화
        go.transform.position = this.transform.position;
        //일 차감
        taskCount--;
        //리스트 담기
        UnitManager.Instance.AddMonsterList(go.GetComponent<BaseMonster>());
    }

    public void StartRun()
    {
        stopFactory = false;
        StartCoroutine(Run());
    }

    public void SetTask()
    {
        taskCount++;
    }


    public override BaseMonster CreateUnit(int number)
    {
        BaseMonster result = Instantiate(prefabs[number]).GetComponent<BaseMonster>();

        return result;
    }



    public void StartFactory()
    {
        stopFactory = false;
    }

    public void DontMove()
    {
        stopFactory = true;
    }*/
}
