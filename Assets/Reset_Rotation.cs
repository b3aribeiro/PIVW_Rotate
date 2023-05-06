using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reset_Rotation : MonoBehaviour
{
    public RotateThis rotateScript;
    public float test;
    void Start()
    {
        rotateScript = GameObject.Find("ROTATOR_BYTRIGGER").GetComponent<RotateThis>();
        Debug.Log(rotateScript.hasCollectedObj);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider co)
    {
        if (co.gameObject.tag == "Player")
        {
            rotateScript.hasCollectedObj = true;
            Debug.Log("Reset ENTER TRIGGERED");
        }
    }
}
