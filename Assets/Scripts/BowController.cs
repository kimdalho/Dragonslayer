using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BowController : InGameStepObject , IDontwork
{
    //public Slider slider;
    //
    public bool isd;

    [Range(-2, 2)]
    public float value;

    float angle;

    public float test;
    public bool IsCanMove;
    public float ori_angle;
    public float angle_z;

    
    private void Update()
    {
        if (IsCanMove == false)
            return;

        //angle = Mathf.Atan2(x.transform.position.x,y.transform.position.y) * Mathf.Rad2Deg;
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 inputVec = Input.mousePosition;
            ori_angle = Mathf.Atan2(inputVec.y, inputVec.x) * Mathf.Rad2Deg;
            angle_z = gameObject.transform.eulerAngles.z;
        }
        else if (Input.GetMouseButton(0))
        {
            Vector2 inputVec = Input.mousePosition;
            angle = ori_angle - (Mathf.Atan2(inputVec.y, inputVec.x) * Mathf.Rad2Deg);
            gameObject.transform.rotation = Quaternion.Euler(0f, 0f, angle_z - angle);
        }
    }
    
    public void DontMove()
    {
        IsCanMove = false;
    }
}
