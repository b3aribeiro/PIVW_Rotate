using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateThis : MonoBehaviour
{
    public float rotatingSpeed = 50f;

    public bool hasRotatedOnce = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if(hasRotatedOnce == false)
        {
            transform.Rotate(Vector3.up, rotatingSpeed * Time.deltaTime);
            //transform.Rotate(0, 90, 0);
            hasRotatedOnce = true;
        }
    }

    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "Player")
        {
            hasRotatedOnce = false;
                //other.transform = transform.parent;
                //other.transform.Rotate(new Vector3(0, rotatingSpeed * Time.deltaTime, 0));
               //transform.Rotate(Vector3.up, rotatingSpeed * Time.deltaTime);
        }
    }

    void OnCollisionExit(Collision other)
    {
        hasRotatedOnce = true;
    }
}
