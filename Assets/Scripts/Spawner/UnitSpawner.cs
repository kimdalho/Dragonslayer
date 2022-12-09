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
        //TODO: Instanceȭ unitInfoDataList[n].path�� �����ʿ�
        //GameObject go = ResourceManager.Instance.Instantiate("Monster/GreenGoblin");

        //�������� �����´�.
        var spawnUnit = TableContainer.unitInfoDataMgr.GetUnitInfoData(0);
        //����
        GameObject go = ResourceManager.Instance.Instantiate(spawnUnit.path);
        if (go == null)
        {
            go = ResourceManager.Instance.Instantiate("Monster/TestMonster");
            Debug.LogWarning("�������� �ʽ��ϴ�.");
        }

        //�ʱ�ȭ
        var baseunit = go.GetComponent<TestMonster>();
        
        baseunit.Setup();
        baseunit.SetInfo();
        //��ǥ �ʱ�ȭ
        go.transform.position = this.transform.position;
    }


    public void CreateHero()
    {
        //TODO: Instanceȭ unitInfoDataList[n].path�� �����ʿ�
        //GameObject go = ResourceManager.Instance.Instantiate("Monster/GreenGoblin");

        //�������� �����´�.
        var spawnUnit = TableContainer.unitInfoDataMgr.GetUnitInfoData(0);
        //����
        GameObject go = ResourceManager.Instance.Instantiate(spawnUnit.path);
        if (go == null)
        {
            go = ResourceManager.Instance.Instantiate("Monster/TestHero");
            Debug.LogWarning("�������� �ʽ��ϴ�.");
        }

        //�ʱ�ȭ
        var baseunit = go.GetComponent<TestMonster>();

        baseunit.Setup();
        baseunit.SetInfo();
        //��ǥ �ʱ�ȭ
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
