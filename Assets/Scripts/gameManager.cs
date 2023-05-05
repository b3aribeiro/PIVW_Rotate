using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameManager : MonoBehaviour
{
    // Start is called before the first frame update
    //variables for tinylytics
    public int trialNum;
    public GameObject endZone;
    public GameObject player;
    public GameObject flashLight;
    public GameObject torch;


    public string trialName;
    public List<string> trials;
    public static string initials_input;
    private static bool timerIsActive = true;
    public static float trialTimer = 0;
    private static float startTime;
    private static float runTimer = 0;
    private string sceneName;
    private float dist;
    private bool gameStatus;
    private bool isTriggered;
    private bool pattern;
    private string lightType;
    private string sName;
    //variables for position tracking
    private List<string> player_pos = new List<string>();


    void Awake()
    {
        
        
    }

    void Start() {
        InvokeRepeating("PositionTrack", 0f, 1);
        isTriggered = false;
        Cursor.lockState = CursorLockMode.Locked;   // keep confined to center of screen
        Cursor.visible = false;
        trialNum = GlobalControl.Instance.trialNum;
        trialName = GlobalControl.Instance.trialName;
        trials = GlobalControl.Instance.trials;
        pattern = GlobalControl.Instance.pattern;
        initials_input = SaveInitials.name;
        Scene scene = SceneManager.GetActiveScene();
        sName = scene.name;
        lightPattern();
    }

    private void OnLevelWasLoaded()
    {
        timerIsActive = true;
        trialTimer = 0;
        runTimer = 0;
        startTime = 0;

    }
    // Update is called once per frame
    void Update()
    {
        //timekeeping
        if (timerIsActive)
        {
            trialTimer += Time.deltaTime;
        }

        if (Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.LeftShift)) {
            startTime = Time.time;
        }

        if (Input.GetKeyUp(KeyCode.LeftShift) || Input.GetKeyUp(KeyCode.LeftShift))
        {
            float timePressed = Time.time - startTime;
            runTimer += timePressed;
        }

        gameStatus = checkDist();
        if (gameStatus&&!isTriggered) {
            ResetRound();
            isTriggered = true;
        }
    }

    void lightPattern() {
        if (pattern)
        {
            if (sName == "10_Loopless" || sName == "7_Looped")
            {
                flashLight.SetActive(true);
                torch.SetActive(false);
                lightType = "flashlight";
            }
            else {
                flashLight.SetActive(false);
                torch.SetActive(true);
                lightType = "torch";
            }
            
        }
        else {
            if (sName == "10_Loopless" || sName == "7_Looped")
            {
                flashLight.SetActive(false);
                torch.SetActive(true);
                lightType = "torch";
            }
            else {
                flashLight.SetActive(true);
                torch.SetActive(false);
                lightType = "flashlight";
            }
        }
        Debug.Log(sName);
        Debug.Log("t:"+pattern);
        Debug.Log(lightType);
    }

    void PositionTrack() {
        float pX = player.transform.position.x;
        float pZ = player.transform.position.z;
        Debug.Log(pX);
        player_pos.Add("[" + pX.ToString() + "," + pZ.ToString() + "]");
    }

    bool checkDist() {
        dist = Vector3.Distance(endZone.transform.position, player.transform.position);
        //Debug.Log(dist);
        if (dist < 2.5) {
            return true;
        }
        else { return false; }
    }

    private void ResetRound()
    {
        //if (//lives == 0)
        
            string str = string.Join(",", player_pos);
            //Debug.Log(str);
            timerIsActive = false;
            trialNum = trialNum + 1;
        Debug.Log(trialTimer + " " + runTimer);
            Tinylytics.AnalyticsManager.LogCustomMetric(initials_input + "_" + trialNum.ToString() + "_" + trials[trialNum - 1]+"_"+ lightType, "time:" + trialTimer.ToString()+","+ runTimer.ToString());
            //Tinylytics.AnalyticsManager.LogCustomMetric(initials_input + "_" + trialNum.ToString() + "_" + trials[trialNum - 1], "Runtime:" + runTimer.ToString());
            Tinylytics.AnalyticsManager.LogCustomMetric(initials_input + "_" + trialNum.ToString() + "_" + trials[trialNum - 1]+"_"+ lightType, str);
            //DestroySelf();
            //ResetScene();
            newTrial();
        
    }

    public void SaveGame()
    {
        GlobalControl.Instance.trialNum = trialNum;
        GlobalControl.Instance.trialName = trialName;
        GlobalControl.Instance.trials = trials;
    }

    void newTrial()
    {
        Debug.Log("trial count"+trials.Count);
        Debug.Log("next trial"+trialNum);
        if (trialNum < trials.Count)
        {
            trialName = trials[trialNum];
            SaveGame();

            sceneName = "interstitial"; //this name is used in the Coroutine, which is basically just a pause timer for 3 seconds.

            StartCoroutine(WaitForSceneLoad());
        }
        else { endGame(); }


    }

    void endGame()
    {
        //if you want to know how lond the entire set of trials took, you can add your tinyLytics call here
        sceneName = "ending"; //this name is used in the Coroutine, which is basically just a pause timer for 3 seconds.
        StartCoroutine(WaitForSceneLoad());

    }

    private IEnumerator WaitForSceneLoad()
    {
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene(sceneName);
    }
}
