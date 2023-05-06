using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateThis : MonoBehaviour
{
    public float rotatingSpeed = 50f;

    public bool hasCollectedObj = false;
    public bool hasRotatedOnce = false;
    public int hasRotatedXTimes = 0;

    public GameObject pointer;
    public GameObject rotatedObject_A;
    public GameObject rotatedObject_B;
    public AudioSource rotateSoundA;
    public AudioSource rotateSoundB;

    // Update is called once per frame
    void Update()
    {

        
    }

    void Rotateplt() {
        if (hasRotatedOnce == true && hasRotatedXTimes == 0)
        {
            // transform.Rotate(Vector3.up, rotatingSpeed * Time.deltaTime);
            hasRotatedXTimes++;
            hasRotatedOnce = false;
            rotatedObject_A.transform.Rotate(0, 90, 0);
            rotateSoundA.Play();
            Debug.Log("Has Rotated AREA A");
            pointer.SetActive(false);
        }

        if (hasCollectedObj == true && hasRotatedXTimes == 1)
        {
            // transform.Rotate(Vector3.up, rotatingSpeed * Time.deltaTime);
            hasRotatedXTimes++;
            hasRotatedOnce = false;
            rotatedObject_B.transform.Rotate(0, 90, 0);
            rotateSoundB.Play();
            Debug.Log("Has Rotated AREA B");
        }
    }

    void OnTriggerEnter(Collider other) {

        if(other.gameObject.tag == "Player" && hasRotatedXTimes == 0)
        {
            hasRotatedOnce = true;
                //other.transform = transform.parent;
                //other.transform.Rotate(new Vector3(0, rotatingSpeed * Time.deltaTime, 0));
               //transform.Rotate(Vector3.up, rotatingSpeed * Time.deltaTime);

        Debug.Log("RotateThis ENTER TRIGGERED");
        }

        Rotateplt();
    }
}
