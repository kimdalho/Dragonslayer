using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;


//인적 요소
//1. n개를 , 무작위 좌표 n개에 
//몬스터 a부터b까지 랜덤하게 n개 선택하고
//생성한다
//t만큼 기다린다.

public class AiPlayer : InGameStepObject
{

    [SerializeField]
    private List<UnitSpawner> spawnObjectList;

    /// <summary>
    /// 살아있는 몬스터 갯수 10개
    /// </summary>
    public List<BaseUnit> baseMonsters= new List<BaseUnit>();


    public float delay;

    public int count;

    public const int ZERO = 0;
    public WaitForSeconds WAIT_CACHE = new WaitForSeconds(10);

    private Coroutine run;


    protected override void OnGameOver()
    {
        StopAllCoroutines();
    }


    public void Setup()
    {
        delay = 10f;
        run = StartCoroutine(Run(1));
    }

    protected override void OnLevelUp()
    {
        StopAllCoroutines();
    }

    protected override void OnSkillSelecte()
    {
        run = StartCoroutine(Run(1));
    }



    private IEnumerator Run(int limitCount)
    {
        Queue<UnitSpawner> spawnerBuffer = new Queue<UnitSpawner>();

        while (true)        {
            if (limitCount > baseMonsters.Count)
            {
                spawnerBuffer.Clear();

                for (int i = ZERO; i < count; i++)
                {
                    int rnd = UnityEngine.Random.Range(ZERO, spawnObjectList.Count);
                    spawnerBuffer.Enqueue(spawnObjectList[rnd]);
                }

                while (spawnerBuffer.Count > ZERO)
                    spawnerBuffer.Dequeue().CreateMonster();

            }
            yield return WAIT_CACHE;
        }
    }

    

}
