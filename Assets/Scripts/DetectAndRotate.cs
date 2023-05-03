using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectAndRotate : MonoBehaviour
{

    public bool hasRotatedOnce = false;

    public float rotatingSpeed = 10f;
    
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

        Debug.Log("Rotated");
    }

    void OnCollisionExit(Collision other) 
    {
        transform.parent = null;
    }
}
