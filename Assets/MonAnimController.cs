using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonAnimController : MonoBehaviour
{
    public Animator animator;

     public void Update()
    {
        if(Input.GetKeyDown(KeyCode.A))
        {
            animator.SetBool("Attackb", true);
        }
        else if (Input.GetKeyDown(KeyCode.B))
        {
            animator.SetBool("Attackb", false);
        }
        else if (Input.GetKeyDown(KeyCode.C))
        {
            animator.SetTrigger("DeadTrg");
        }
    }
}
