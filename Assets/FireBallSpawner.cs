using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBallSpawner : Spawner
{
    [Header("°³¹ß¿ë")]
    [SerializeField]
    private float speed;

    public GameObject fireBall;

    public override GameObject Create(SpawnItemData data)
    {
        GameObject go = Instantiate(fireBall);
        go.transform.position = this.transform.position;
        go.GetComponent<Arrow>().SetSpeed(speed);
        return go;
    }

    public override GameObject Create(Quaternion rot)
    {
        GameObject go = Instantiate(fireBall);
        go.AddComponent<Arrow>();
        go.transform.position = this.transform.position;
        go.transform.rotation = rot;
        go.GetComponent<Arrow>().SetSpeed(speed);
        return go;
    }

    public override GameObject Create(Vector3 pos, Quaternion rot)
    {
        GameObject go = Instantiate(fireBall);
        go.transform.position = pos;
        go.transform.rotation = rot;
        go.GetComponent<Arrow>().SetSpeed(speed);
        return go;
    }
}
