using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class StartGame : MonoBehaviour
{

    public int trialNum;
    public string trialName;
    public List<string> trials = new List<string>();
    public bool pattern;
    //public int winningScore;

    private void Start()
    {

        //shuffle the list when the game starts
        /*for (int i = 0; i < trials.Count; i++)
        {
            string temp = trials[i];
            int randomIndex = Random.Range(i, trials.Count);
            trials[i] = trials[randomIndex];
            trials[randomIndex] = temp;
        }*/

        //decide on a random pattern
        int randValue = Random.Range(0, 2);
        if (randValue == 0)
        {
            pattern = true;
        }
        else {
            pattern = false;
        }

        if (pattern)
        {
            trials[0] = "AutoRotate";
        }
        else {
            trials[0] = "PressRotate";
        }

        GlobalControl.Instance.pattern = pattern;
        

        GlobalControl.Instance.trials = trials; //set a global list of trials we can use in all of the scenes

    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            gameStart(); 
        }
    }

    void gameStart()
    {
        trialNum = 0; //set the trial number to the first item in the list
        GlobalControl.Instance.trialNum = trialNum; //this will set the trialNum to the first in the list
        //Tinylytics.AnalyticsManager.LogCustomMetric("Game Start", "Start " + System.DateTime.Now);
        trialName = GlobalControl.Instance.trials[trialNum];
        SceneManager.LoadScene(trialName);
        //Debug.Log(trialName);
    }
}
