using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowSpawner : Spawner
{
    private const string path = "Arrow";

    [Header("���߿�")]
    [SerializeField]
    private float speed;

    private SpawnItemData arrowInfo = new SpawnItemData(path);
    List<GameObject> curArrowList;
    private AudioSource audio;

   

    public void Setup()
    {
        audio = GetComponent<AudioSource>();
        curArrowList = GenerateNormalArrow();
        //��ų ���õ� �� ȣ��� ����
        GameManager.Instance.arrowUpgradAction = ArrowUpgradebyBaseSkillSelected;
    }

    /// <summary>
    /// ��ų�� ������ �� ���� ȭ�� ��ȭ
    /// </summary>
    /// <param name="baseSkill"></param>
    void ArrowUpgradebyBaseSkillSelected(BaseSkill baseSkill)
    {
        curArrowList = baseSkill.SettingArrow(curArrowList);
    }

    /// <summary>
    /// �⺻ ȭ�� ����
    /// </summary>
    /// <returns></returns>
    List<GameObject> GenerateNormalArrow()
    {
        List<GameObject> arrowList = new List<GameObject>();

        //ȭ�� �߻� ����, ��ġ ����
        GameObject arrow = ResourceManager.Instance.Instantiate("Arrow");
        arrow.transform.position = transform.position;
        arrow.transform.eulerAngles = transform.eulerAngles;
        arrowList.Add(arrow);

        return arrowList;
    }

    /// <summary>
    /// ����� ȭ�� ��������
    /// </summary>
    /// <returns></returns>
    public GameObject getCurArrow()
    {
        //��� ������ ȭ�� ã��
        foreach (var nowArrow in curArrowList)
        {
            if (!nowArrow.GetComponent<Arrow>().isArrowUsingNow)
            {
                //��ġ �ʱ�ȭ
                Create(nowArrow);
                return nowArrow;
            }
        }

        //��ã������ ���� �����ϱ�.
        GameObject newArrow = Instantiate(curArrowList[0]);
        curArrowList.Add(newArrow);
        Create(newArrow);
        return newArrow;
    }

    public  GameObject Create(GameObject data)
    {
        GameObject nowArrow = data;
        //��ġ �ʱ�ȭ
        nowArrow.transform.position = transform.position;
        nowArrow.transform.eulerAngles = transform.eulerAngles;
        nowArrow.GetComponent<Arrow>().gameObject.SetActive(true);
        nowArrow.GetComponent<Arrow>().isArrowUsingNow = true;
        nowArrow.GetComponent<Arrow>().SetSpeed(speed);
        audio.Play();
        return nowArrow;
    }

    public override GameObject Create(SpawnItemData data)
    {
        GameObject go = ResourceManager.Instance.Instantiate(data.path);
        go.transform.position = this.transform.position;
        go.GetComponent<Arrow>().SetSpeed(speed);
        return go;
    }

    public override GameObject Create(Quaternion rot)
    {
        GameObject go = ResourceManager.Instance.Instantiate(path);
        go.transform.position = this.transform.position;
        go.transform.rotation = rot;
        go.GetComponent<Arrow>().SetSpeed(speed);
        return go;
    }

    public override GameObject Create(Vector3 pos, Quaternion rot)
    {
        GameObject go = ResourceManager.Instance.Instantiate(path);
        go.transform.position = pos;
        go.transform.rotation = rot;
        go.GetComponent<Arrow>().SetSpeed(speed);
        return go;
    }
}
