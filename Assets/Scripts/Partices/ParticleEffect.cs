using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleEffect : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(CoSelfDestroy());
    }

    public IEnumerator CoSelfDestroy()
    {
        yield return new WaitForSeconds(5.0f);
        Destroy(gameObject);
    }


    public int attack;

}
