using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class UserData : Singleton<UserData>
{
    //public str_ArributeStat stat;

    /// <summary>
    /// 로비에서 선택한 보우의 형테를 InGame에 가져오기위함
    /// 플레이어 프리펩으로 Bow의 아이디를 가져온다.
    /// </summary>
    public int curBow;

}

