using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Where all the writing for the game goes
//The only script that has setting-specific functionality and data
public class Script : MonoBehaviour
{
    public List<Sprite> backgrounds = new List<Sprite>();
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
        _displayManager.Set_CharVisuals(yukari_Takeba, WhichDisplayCharacter.c1, CharacterEmotionType.Blush);
        _displayManager.Set_CharVisuals(mitsuru_Kirijo, WhichDisplayCharacter.c2, CharacterEmotionType.Angry);
        _displayManager.Set_BGVisual(backgrounds[0]);

    }

    void StartScript()
    {

    }
}
