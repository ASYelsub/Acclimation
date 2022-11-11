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

    bool _typing = false;

    Dictionary<BackgroundNames, Sprite> _backgrounds = new Dictionary<BackgroundNames, Sprite>();
    public void Init()
    {
        LoadScene();
    }

    void LoadScene()
    {
        yukari_Takeba.Init();
        mitsuru_Kirijo.Init();
        _dm = FindObjectOfType<DisplayManager>();
        _dm.Set_CharVisuals(yukari_Takeba, DisplayPos.c1, CharEmotion.Blush);
        _dm.Set_CharVisuals(mitsuru_Kirijo, DisplayPos.c2, CharEmotion.Angry);
        _backgrounds.Add(BackgroundNames.coffeeShop, backgrounds[0]);
        _dm.Set_BGVisual(backgrounds[0]);
    }



    public IEnumerator StartScript()
    {
        _scriptStarted = true;
        yield return new WaitForSeconds(1);
        YukariSay("Hello I'm in another video game!");
        yield return WaitForContinue();
        YukariSay("Space press works?");
        yield break;
    }

    /// <summary>
    /// Writer-friendly shortcut for having Yukari talk.
    /// </summary>
    /// <returns></returns>
    void YukariSay(string text)
    {
        _dm.Prepare_Char_Talk(yukari_Takeba);
        StartCoroutine(TypeWrite(text));
    }



    ///<WRITER><FUNCTIONALITY><BELOW>///

    /// <summary>
    /// Routine responsible for displaying text to the screen with the displayManager in a type-writer fashion.
    /// </summary>
    /// <returns></returns>

    IEnumerator TypeWrite(string text)
    {
        _typing = true;
        string txt = "";

        foreach (char c in text)
        {
            txt += c;
            _dm.SetText(txt);
            yield return new WaitForSeconds(_dm.secondsToType);
        }
        _typing = false;
        _dm.ResetTypeSpeed();
        yield break;
    }


    ///<WAIT><FOR><X><ROUTINES>///


    /// <summary>
    /// Coroutine to check if player presses any of the continue buttons.
    /// </summary>
    /// <returns></returns>
    IEnumerator WaitForContinue()
    {
        while ((!Input.GetKeyDown(KeyCode.Space) && !Input.GetMouseButtonDown(0) && !Input.GetKeyDown(KeyCode.Return))
        || _typing)
        {
            yield return null;
        }
        yield break;
    }


    ///<UPDATE>///

    /// <summary>
    /// Mainly here to check if player is trying to speed up text by spamming any of the buttons.
    /// </summary>
    /// <returns></returns>
    void Update()
    {
        if (_typing)
        {
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Return) || Input.GetMouseButtonDown(0))
            {
                _dm.SpeedUpTyping();
            }
        }
    }

}
