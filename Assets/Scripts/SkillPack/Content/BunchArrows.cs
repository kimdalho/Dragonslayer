using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class BunchArrows : BaseSkill
{
    public GameObject arrowObject;
    public float delay;

    public object StartCoroutine { get; private set; }

    public override void Get()
    {
    }

    public List<GameObject> CreateArrows()
    {
        List<GameObject> arrowList = new List<GameObject>();
        for (int i = 0; i < 3; i++)
        {
            //화살 발사 각도, 위치 지정
            GameObject tempObject = ResourceManager.Instance.Instantiate("Arrow");
            Vector3 direction = new Vector2(Mathf.Cos((20 + 20 * i) * Mathf.Deg2Rad), Mathf.Sin((20 + 20 * i) * Mathf.Deg2Rad));
            tempObject.transform.right = direction;
            //궁수의 위치에서 조금 더 떨어진 곳으로
            arrowList.Add(tempObject);
            //direction 곱하는 이유 : 각도에 따라 띄워주는 간격을 다르게
            //나아가고자 하는 방향으로 간격을 띄움  
        }
        return arrowList;
    }
}
