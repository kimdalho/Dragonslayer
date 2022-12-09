using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMonster : BaseMonster
{
    private const string ARROW = "Arrow";


    public override void SetInfo()
    {
        info.atk = 10;
        info.def = 3;
        info.dropExp = 3;
        info.speed = 10;
        info.health = 6;
        hpbar.Setup(info.health);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == ARROW)
        {
            if (hpbar.gameObject.activeSelf == false)
                hpbar.gameObject.SetActive(true);

            Hit(3);
            hpbar.Hit(3);
            hitParticle.Play();
            other.gameObject.GetComponent<Arrow>().isArrowUsingNow = false;
            other.gameObject.SetActive(false);

        }
        else
        {
            Debug.Log(other.name);
        }
    }
}
