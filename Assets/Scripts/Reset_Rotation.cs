using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reset_Rotation : MonoBehaviour
{
    public GameObject pointer;
    public GameObject pointer2; 
    public RotateThis rotateScript;
    public GameObject key;
    public AudioSource keySound;
    void Start()
    {
        rotateScript = GameObject.Find("ROTATOR_BYTRIGGER").GetComponent<RotateThis>();
        Debug.Log(rotateScript.hasCollectedObj);
    }


    void OnTriggerEnter(Collider co)
    {

        if (co.gameObject.tag == "Player")
        {
            rotateScript.hasCollectedObj = true;
            keySound.Play();
            Debug.Log("Reset ENTER TRIGGERED");
            pointer.SetActive(false);
            pointer2.SetActive(false);
            key.SetActive(false);
        }
    }
}
