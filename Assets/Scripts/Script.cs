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


    void YukariSay(string text)
    {
        _dm.Prepare_Char_Talk(yukari_Takeba);
        StartCoroutine(TypeWrite(text));
    }


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
        yield break;
    }


    ///<WAIT><FOR><X><ROUTINES>///

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



}
