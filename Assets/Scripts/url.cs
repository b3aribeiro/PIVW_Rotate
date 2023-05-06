using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class url : MonoBehaviour
{
    public string link;

    // Update is called once per frame
    public void Open()
    {
        Application.OpenURL(link);
    }
}
