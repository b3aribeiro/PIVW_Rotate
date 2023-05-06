using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reset_Rotation_2 : MonoBehaviour
{
    public GameObject pointer;
    public GameObject pointer2;
    public Rotator rotateScript;
    public GameObject key;
    public AudioSource keySound;
    public GameObject door2;
    void Start()
    {
        rotateScript = GameObject.Find("Rotator").GetComponent<Rotator>();
        
    }


    void OnTriggerEnter(Collider co)
    {

        if (co.gameObject.tag == "Player" && rotateScript.rotateCount==1)
        {
            rotateScript.rotated = false;
            door2.SetActive(true);
            keySound.Play();
            Debug.Log("Reset ENTER TRIGGERED");
            pointer.SetActive(false);
            pointer2.SetActive(false);
            key.SetActive(false);
        }
    }
}
