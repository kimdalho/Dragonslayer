using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Angle : MonoBehaviour
{
    public float ori_angle;

    public float angle;
    public float angle_z;
    public GameObject x;
    public GameObject y;

    public GameObject test;

    public float last_angle;
    public void Update()
    {
        //angle = Mathf.Atan2(x.transform.position.x,y.transform.position.y) * Mathf.Rad2Deg;
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 inputVec = Input.mousePosition;
            ori_angle = Mathf.Atan2(inputVec.y, inputVec.x) * Mathf.Rad2Deg;
            angle_z = test.transform.eulerAngles.z;
        }
        else if (Input.GetMouseButton(0))
        {
            Vector2 inputVec = Input.mousePosition;
            angle = ori_angle - (Mathf.Atan2(inputVec.y, inputVec.x) * Mathf.Rad2Deg);
            test.transform.rotation = Quaternion.Euler(0f, 0f, angle_z - angle);
        }
        //test.transform.rotation = Quaternion.Euler(0f, 0f, angle - 90);
    }
}
