using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.GraphicsBuffer;

public class CharacterHp : MonoBehaviour
{
    public int maxHp;
    public int curxHp;
    public Slider hpbar;
    float target;
    private Transform mainCam;



    public void Setup(int maxData)
    {
        maxHp = maxData;
        curxHp = maxData;
        hpbar.value = 1f;
        target = (float)curxHp / (float)maxHp;
    }

    public void Hit(int damage)
    {
        curxHp -= damage;

        if(curxHp < 0)
        {
            curxHp = 0;
            hpbar.value = 0f;
            return;
        }

        target = (float)curxHp / (float)maxHp;

        //hpbar.value = (float)curxHp / (float)maxHp ;
    }

    public void Hill(int hill)
    {
        curxHp += hill;

        if (curxHp >= maxHp)
        {
            curxHp = maxHp;
            hpbar.value = 1f;
            return;
        }

        target = (float)curxHp / (float)maxHp;
    }


    private void Start()
    {
        mainCam = Camera.main.transform;
    }

    private void LateUpdate()
    {
        transform.LookAt(transform.position + mainCam.rotation * Vector3.forward,
            mainCam.rotation * Vector3.up);
    }

    private void Update()
    {

        hpbar.value = Mathf.Lerp(hpbar.value, target, 0.1f);
    }

    public int GetHp() 
    {
        return curxHp;
    }

}
