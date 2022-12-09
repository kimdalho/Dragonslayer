using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowSpawner : Spawner
{
    private const string path = "Arrow";

    [Header("개발용")]
    [SerializeField]
    private float speed;

    private SpawnItemData arrowInfo = new SpawnItemData(path);
    List<GameObject> curArrowList;
    private AudioSource audio;

   

    public void Setup()
    {
        audio = GetComponent<AudioSource>();
        curArrowList = GenerateNormalArrow();
        //스킬 선택될 때 호출될 내용
        GameManager.Instance.arrowUpgradAction = ArrowUpgradebyBaseSkillSelected;
    }

    /// <summary>
    /// 스킬을 선택할 때 마다 화살 강화
    /// </summary>
    /// <param name="baseSkill"></param>
    void ArrowUpgradebyBaseSkillSelected(BaseSkill baseSkill)
    {
        curArrowList = baseSkill.SettingArrow(curArrowList);
    }

    /// <summary>
    /// 기본 화살 제공
    /// </summary>
    /// <returns></returns>
    List<GameObject> GenerateNormalArrow()
    {
        List<GameObject> arrowList = new List<GameObject>();

        //화살 발사 각도, 위치 지정
        GameObject arrow = ResourceManager.Instance.Instantiate("Arrow");
        arrow.transform.position = transform.position;
        arrow.transform.eulerAngles = transform.eulerAngles;
        arrowList.Add(arrow);

        return arrowList;
    }

    /// <summary>
    /// 사용할 화살 가져오기
    /// </summary>
    /// <returns></returns>
    public GameObject getCurArrow()
    {
        //사용 가능한 화살 찾기
        foreach (var nowArrow in curArrowList)
        {
            if (!nowArrow.GetComponent<Arrow>().isArrowUsingNow)
            {
                //위치 초기화
                Create(nowArrow);
                return nowArrow;
            }
        }

        //못찾았으면 새로 제작하기.
        GameObject newArrow = Instantiate(curArrowList[0]);
        curArrowList.Add(newArrow);
        Create(newArrow);
        return newArrow;
    }

    public  GameObject Create(GameObject data)
    {
        GameObject nowArrow = data;
        //위치 초기화
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
