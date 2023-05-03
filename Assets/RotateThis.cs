using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateThis : MonoBehaviour
{
    public float rotatingSpeed = 50f;

    public bool hasRotatedOnce = false;

    public GameObject rotatedObject;

    // Update is called once per frame
    void Update()
    {

        if(hasRotatedOnce == true)
        {
           // transform.Rotate(Vector3.up, rotatingSpeed * Time.deltaTime);
            transform.Rotate(0, 90, 0);
            hasRotatedOnce = false;
        Debug.Log("RotateThis STOPPED");
        }
    }

    void OnTriggerEnter(Collider other) {

        if(other.gameObject.tag == "Player")
        {
            hasRotatedOnce = true;
                //other.transform = transform.parent;
                //other.transform.Rotate(new Vector3(0, rotatingSpeed * Time.deltaTime, 0));
               //transform.Rotate(Vector3.up, rotatingSpeed * Time.deltaTime);

        Debug.Log("RotateThis TRIGGERED");
        }
    }
}
