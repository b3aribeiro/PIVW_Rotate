using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectAndRotate : MonoBehaviour
{

    public float rotatingSpeed = 50f;
    
    void Start()
    {
        
    }

    void Update()
    {
    }

    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "isBase")
        {
            transform.parent = other.transform;       
        }

        Debug.Log("DetectAndRotate collided");
    }

    void OnCollisionExit(Collision other) 
    {
        transform.parent = null;
    }
}
