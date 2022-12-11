using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitBoard : MonoBehaviour
{
    public List<BaseUnit> unitbases;
    public List<UnitSpawner> unitspawners;

    public void Setup()
    {
        unitspawners = new List<UnitSpawner>();
        for(int i= 0; i < transform.childCount; i++)
        {
            var curSpawner = transform.GetChild(i).GetComponent<UnitSpawner>();
            unitspawners.Add(curSpawner);
        }
    }

}
