using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Rotator : MonoBehaviour
{
    public bool rotated;
    public int rotateCount;
    public GameObject pointer;
    public GameObject rotatedObject_A;
    public GameObject rotatedObject_B;
    public AudioSource rotateSoundA;
    public AudioSource rotateSoundB;
    public GameObject text;
    public GameObject player;

    public GameObject door1;
    public GameObject door2;
    private bool rotate1;
    private bool rotate2;
    // Start is called before the first frame update
    void Start()
    {
        rotated = false;
        rotateCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        bool dist = checkDist();
        Debug.Log(dist);
        if (dist && !rotated)
        {
            triggerRotate();
        }
        else {
            text.SetActive(false);
        }
        rotateAnimation();
    }

    void rotateAnimation() {
        if (rotate1 == true) {
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 90, 0), 0.05f);
        }
        if (rotate2 == true)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 180, 0), 0.05f);
        }
    }

    bool checkDist() {
        float dist = Vector3.Distance(player.transform.position, transform.position);
        if (dist <= 5f) {
            return true;
        }
        return false;
    }

    void triggerRotate() {
        text.SetActive(true);
        if (Input.GetKeyDown("r")) {
            Debug.Log("triggered");
            RotatePlt();
        }
    }

    void RotatePlt() {
        if (rotated == false && rotateCount == 0) {
            rotate1 = true;
            rotated = true;
            ++rotateCount;
            rotatedObject_A.transform.Rotate(0, 90, 0);
            rotateSoundA.Play();
            Debug.Log("Has Rotated AREA A");
            pointer.SetActive(false);
            text.SetActive(false);
            door1.SetActive(false);
        }

        if (rotated == false && rotateCount == 1) {
            rotate1 = false;
            rotate2 = true;
            rotated = true;
            ++rotateCount;
            rotatedObject_B.transform.Rotate(0, 90, 0);
            rotateSoundA.Play();
            Debug.Log("Has Rotated AREA B");
            pointer.SetActive(false);
            door2.SetActive(false);
        }

    }
}
