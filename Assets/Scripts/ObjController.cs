using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjController : MonoBehaviour
{
    public float RotatingSpeed = 70f;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.up, RotatingSpeed * Time.deltaTime, Space.Self);
    }
}
