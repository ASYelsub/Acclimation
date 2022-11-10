using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Where all the writing for the game goes
//The only script that has setting-specific functionality and data

enum BackgroundNames
{
    coffeeShop
}
public class Script : MonoBehaviour
{

    public List<Sprite> backgrounds = new List<Sprite>();
    public Character yukari_Takeba;
    public Character mitsuru_Kirijo;

    DisplayManager _dm;
    bool _scriptStarted = false;
    bool _canContinue = false;
    Dictionary<BackgroundNames, Sprite> _backgrounds = new Dictionary<BackgroundNames, Sprite>();
    public void Init()
    {
        LoadCharacters();
        LoadBackgrounds();
    }

    void LoadCharacters()
    {
        yukari_Takeba.Init();
        mitsuru_Kirijo.Init();
        _dm = FindObjectOfType<DisplayManager>();
        _dm.Set_CharVisuals(yukari_Takeba, DisplayPos.c1, CharEmotion.Blush);
        _dm.Set_CharVisuals(mitsuru_Kirijo, DisplayPos.c2, CharEmotion.Angry);


    }

    void LoadBackgrounds()
    {
        _backgrounds.Add(BackgroundNames.coffeeShop, backgrounds[0]);
        _dm.Set_BGVisual(backgrounds[0]);
    }

    private void Update()
    {
        if (!_scriptStarted && Input.GetKeyDown(KeyCode.Space))
        {
            StartScript();
            return;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ContinueScript();
        }
    }

    void StartScript()
    {
        _scriptStarted = true;
        _dm.Set_Text(yukari_Takeba, "Hello I'm in another video game!");

    }

    void ContinueScript()
    {

    }

    /// <summary>
    /// Coroutine to check if player presses space or not.
    /// </summary>
    /// <returns></returns>
    IEnumerator WaitForSpacePress()
    {
        while (!Input.GetKeyDown(KeyCode.Space))
        {
            yield return null;
        }
        yield break;
    }




}
