using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trial_end2 : MonoBehaviour
{
    public Rotator status;
    private bool solved;
    private int rotateTimes;
    public bool endStatus;
    // Start is called before the first frame update
    void Start()
    {
        endStatus = false;
    }

    // Update is called once per frame
    void Update()
    {
        solved = status.rotated;
        rotateTimes = status.rotateCount;
    }

    private void OnTriggerEnter(Collider co)
    {
        if (co.gameObject.tag == "Player" && rotateTimes == 2 && solved == true)
        {
            Debug.Log("End Game");
            endStatus = true;
        }
    }
}
