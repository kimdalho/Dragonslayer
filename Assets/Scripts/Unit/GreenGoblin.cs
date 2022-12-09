using System.Collections;
using UnityEngine;
using System;
using DG.Tweening;
//테스트용 인터페이스
//움직이는 객체한에서 움직임을 얼려둔다


enum eMovetype
{
    UP = 0,
    Left = 1,
    Right = 2,
    Down = 3,
}


class GreenGoblin : BaseMonster
{
    
    
    protected override IEnumerator CoAiMovement()
    {
        while (!die)
        {
            switch (curType)
            {
                case eUnitAiType.Follow:
                    if (dontMove == true)
                    {
                        rb.velocity = Vector2.zero;
                        yield return null;
                    }
                    else
                    {
                    }
                    break;
                case eUnitAiType.Attack:
                    break;
                case eUnitAiType.Die:
                    Destroy(this.gameObject);
                    break;
            }
            Debug.Log(curType);
            yield return null;
        }

    }


}
