using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameManager : MonoBehaviour
{
    // Start is called before the first frame update
    //variables for tinylytics
    public int trialNum;
    public string trialName;
    public List<string> trials;
    public static string initials_input;
    private static bool timerIsActive = true;
    public static float trialTimer = 0;
    private string sceneName;
    private float dist;
    private bool gameStatus;
    public GameObject player;
    //variables for position tracking
    private List<string> player_pos = new List<string>();
    //variables for rotation
    public Trial_end endStatus;
    private bool terminate;




    void Start() {
        InvokeRepeating("PositionTrack", 0f, 1);
        Cursor.lockState = CursorLockMode.Locked;   // keep confined to center of screen
        Cursor.visible = false;
        trialNum = GlobalControl.Instance.trialNum;
        trialName = GlobalControl.Instance.trialName;
        trials = GlobalControl.Instance.trials;
        initials_input = SaveInitials.name;
        terminate = false;
    }

    private void OnLevelWasLoaded()
    {
        timerIsActive = true;
        trialTimer = 0;

    }
    // Update is called once per frame
    void Update()
    {
        //timekeeping
        if (timerIsActive)
        {
            trialTimer += Time.deltaTime;
        }

        terminate = endStatus.endStatus;
        if (terminate) {
            ResetRound();
        }
   

        
    }


    void PositionTrack() {
        float pX = player.transform.position.x;
        float pZ = player.transform.position.z;
        Debug.Log(pX);
        player_pos.Add("[" + pX.ToString() + "," + pZ.ToString() + "]");
    }


    private void ResetRound()
    {
        //if (//lives == 0)
        
            string str = string.Join(",", player_pos);
            timerIsActive = false;
            trialNum = trialNum + 1;
            Tinylytics.AnalyticsManager.LogCustomMetric(initials_input + "_" + trialNum.ToString() + "_" + trials[trialNum - 1]+"_", "time:" + trialTimer.ToString());
            //Tinylytics.AnalyticsManager.LogCustomMetric(initials_input + "_" + trialNum.ToString() + "_" + trials[trialNum - 1], "Runtime:" + runTimer.ToString());
            Tinylytics.AnalyticsManager.LogCustomMetric(initials_input + "_" + trialNum.ToString() + "_" + trials[trialNum - 1]+"_", str);
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
