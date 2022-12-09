using System;
using UnityEngine;

public abstract class UnitFactory<T> : MonoBehaviour where T : BaseUnit
{
    protected BaseUnit[] prefabs;
    

    public virtual T CreateUnit(int number)
    {
        T type = default(T);

        return type;
    }
}





/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleFactory : MonoBehaviour
{
    public static SimpleFactory instance = null;

    public GreenGoblin prefab_greenGoblin;
    public RedGoblin prefab_redGoblin;

    void Awake()
    {
        //싱글톤을 간단한 모양으로 구현.
        instance = this;
    }

    public Goblin CreateGoblin(string type)
    {
        Goblin goblin = null;

        if (type.Equals("green"))
        {
            goblin = Instantiate(prefab_greenGoblin);
        }
        else if (type.Equals("red"))
        {
            goblin = Instantiate(prefab_redGoblin);
        }

        return goblin;
    }
}
*/