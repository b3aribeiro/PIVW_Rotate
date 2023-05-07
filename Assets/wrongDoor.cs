using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class wrongDoor : MonoBehaviour
{
    public GameObject player;
    public GameObject doorText;
    public Rotator check;
    public RotateThis check2;
    private float dist;

    private Scene m_scene;
    private string sceneName;
    private bool inRange;
    // Start is called before the first frame update
    void Start()
    {
        m_scene = SceneManager.GetActiveScene();
        sceneName = m_scene.name;
        inRange = false;
    }

    // Update is called once per frame
    void Update()
    {
        //print(check2.hasRotatedXTimes);
        dist = Vector3.Distance(transform.position, player.transform.position);
        if (dist < 5) {
            inRange = true;
            switch (sceneName) {
                case "PressRotate":
                    if (check.rotateCount == 2)
                    {
                        doorText.SetActive(true);
                    }
                    return;
                case "AutoRotate":
                    if (check2.hasRotatedXTimes == 2)
                    {
                        doorText.SetActive(true);
                    }
                    return;
            }
            
            
        }
        if (inRange) {
            doorText.SetActive(false);
            inRange = false;
        }
        
    }
}
