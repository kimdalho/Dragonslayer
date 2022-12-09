using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testCode : MonoBehaviour
{
   

    private void Update()
    {
       if(Input.GetKeyDown(KeyCode.D))
        {
            transform.position += Vector3.right * Time.deltaTime * 20; 
        }
       else if (Input.GetKeyDown(KeyCode.F))
        {
            GetComponent<Rigidbody>().velocity += Vector3.right * Time.deltaTime * 20;
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log($"{other.name}");
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log($"{collision.collider.gameObject.name}");
    }

    private void OnParticleCollision(GameObject other)
    {
        switch(other.tag)
        {
            case "Fireball":
                var effect = other.GetComponent<ParticleEffect>();
                Debug.Log( effect.attack);
                Destroy(other.gameObject);
                break;

        }

        Debug.Log($"{other.tag}");
    }
}
