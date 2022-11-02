using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Where all the writing for the game goes
//The only script that has setting-specific functionality and data
public class Script : MonoBehaviour
{
    public Character yukari_Takeba;
    public Character mitsuru_Kirijo;

    DisplayManager _displayManager;

    private void Start()
    {
        _displayManager = FindObjectOfType<DisplayManager>();
        StartScript();
    }

    void StartScript()
    {

    }
}
