using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Text.RegularExpressions;

public class HeatMap : MonoBehaviour
{
    // Public variables to hold the game object prefab and the file path to read the coordinates from
    public GameObject heatObject;
    public string filePath;
    public TextAsset textFile;
    public Vector3[] Locations;
    private string[] strArr;



    void Start()
    {
        //getLocation();
        StartCoroutine(LocationHM());
    }

    void getLocation() {
        // Read in the coordinates from the text file
        //string fileContents = File.ReadAllText("coordinates.txt");
        string text = textFile.text;
        // Use regular expressions to match each [x,y] pair in the file contents
        MatchCollection matches = Regex.Matches(text, @"\[(-?\d+\.\d+),(-?\d+\.\d+)\]");

        // Loop through each match and instantiate a game object at the x,y coordinates
        foreach (Match match in matches)
        {
            // Extract the x and y coordinates from the match
            float x = float.Parse(match.Groups[1].Value);
            float z = float.Parse(match.Groups[2].Value);

            // Instantiate the game object prefab at the x,y coordinates
            Vector3 position = new Vector3(x, 1f, z);
            Debug.Log("x:" + x + " z:" + z);
            Instantiate(heatObject, position, Quaternion.identity);
        }
    }

    IEnumerator LocationHM()
    {
        // Read in the coordinates from the text file
        //string fileContents = File.ReadAllText("coordinates.txt");
        string text = textFile.text;
        // Use regular expressions to match each [x,y] pair in the file contents
        MatchCollection matches = Regex.Matches(text, @"\[(-?\d+\.\d+),(-?\d+\.\d+)\]");

        // Loop through each match and instantiate a game object at the x,y coordinates
        foreach (Match match in matches)
        {
            // Extract the x and y coordinates from the match
            float x = float.Parse(match.Groups[1].Value);
            float z = float.Parse(match.Groups[2].Value);

            // Instantiate the game object prefab at the x,y coordinates
            Vector3 position = new Vector3(x, 1f, z);
            Debug.Log("x:" + x + " z:" + z);
            Instantiate(heatObject, position, Quaternion.identity);
            yield return new WaitForSeconds(0.05f);
        }
    }
}