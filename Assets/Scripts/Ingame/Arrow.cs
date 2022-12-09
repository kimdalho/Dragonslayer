using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : InGameStepObject
{
    int atk = 2;
    float speed = 10f;

    public GameObject ArrowHead;
    public GameObject ArrowTail;

    [HideInInspector] public bool isArrowUsingNow = false;

    [SerializeField] bool dontMove;

    private void Start()
    {
        StartCoroutine(CoSelfDestroy());
    }

    public IEnumerator CoSelfDestroy()
    {
        yield return new WaitForSeconds(5.0f);
        isArrowUsingNow = false;
    }

    public void SetSpeed(float value)
    {
        this.speed = value;
    }


    private void FixedUpdate()
    {
        if (dontMove)
            return;

        transform.Translate(0, 0, speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == Global.TAG_ENEMY)
        {

            //특정 계산을 위한 클래스가 필요하다.
            var target = collision.gameObject.GetComponent<BaseMonster>();
            GameOperatorManager.Hit(this, target);
        }
    }

    public void SelfDestroy()
    {
        Destroy(this.gameObject);
    }

    public int GetAtk()
    {
        return atk;
    }

    public void Play()
    {
        dontMove = false;
    }

    public void DontMove()
    {
        dontMove = true;

    }
}
