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

    public void Init()
    {
        LoadCharacters();
        StartScript();
    }

    void LoadCharacters()
    {
        yukari_Takeba.Init();
        mitsuru_Kirijo.Init();
        _displayManager = FindObjectOfType<DisplayManager>();
        _displayManager.Set_CharacterVisuals(yukari_Takeba, WhichDisplayCharacter.c1, CharacterEmotionType.Blush);
    }

    void StartScript()
    {

    }
}
