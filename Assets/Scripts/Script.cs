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
        _dm.SetCharVisuals(yukari_Takeba, DisplayPos.c1, CharEmotion.Blush);
        _dm.SetCharVisuals(mitsuru_Kirijo, DisplayPos.c2, CharEmotion.Angry);
        _backgrounds.Add(BackgroundNames.coffeeShop, backgrounds[0]);
        _dm.SetBGVisual(backgrounds[0]);
    }



    public IEnumerator StartScript()
    {
      
        _scriptStarted = true;
        

        // Current: Yukari in her bedroom.

        HideCharacters();
        _dm.Toggle_UI_Character1();
        _dm.Toggle_UI_NameTextboxTMP();
        _dm.SetText("");
        _dm.SetCharVisuals(yukari_Takeba, DisplayPos.c1, CharEmotion.Neutral);
        NarSay("And Yukari Takeba sits now looking in the mirror, slowly removing makeup.");
        yield return WaitForContinue();
        NarSay("It's a monotonous but necessary pattern, something she has grown used and succumbed to.");
        yield return WaitForContinue();
        NarSay("Her mind flashes through the day.");
        yield return WaitForContinue();
        NarSay("A set, a costume, she's in a kids show. Pink Argus.");
        yield return WaitForContinue();
        NarSay("That's who she is right now: an actress.");
        yield return WaitForContinue();
        NarSay("It pays, she gets money. She is self-sustaining. And she's on the road to where she wants to go:");
        yield return WaitForContinue();
        NarSay("Fame?");
        yield return WaitForContinue();
        NarSay("...");
        /*
  
    nar "She also maintains her studies, she's majoring in acting."
    nar "She's fine at the major, but the gen eds..."
    hide ySUMnorm
    image ySUMangry = "YukariSum3.png"
    show ySUMangry:
        xalign 0.75
        yalign 0.8
    nar "She shines more in preformance than with paper and pen."
    hide ySUMangry
    show ySUMnorm:
        xalign 0.75
        yalign 0.8
    nar "..."
    nar "Anyway, Yukari is ready for bed. She lives in an apartment alone now."
    nar "She goes to college, comes back to an empty home, save for the thought of adopting a cat."
    y "Maybe I should get a cat."
    nar "See? She thinks about it."
    nar "Other stuff she thinks about:"
    nar "highschool, her father, what she eats during the day."
    nar "The life of a first year college student, unfulfilled."
    nar "Her biggest problem is navigating the social scape of a place without the support of her SEES peers, without a family to lean on in the nights."
    nar "But enough."
    nar "To sleep, Yukari."
    nar "To sleep, my dear."
    nar "..."
        
    hide ySUMnorm
    image transitionBG = "Transition Background.png"
    show transitionBG
    nar "..."

    image coffeeShop = "CoffeeShop.png"
    show coffeeShop

    #Current: Yukari at a cafe near her college, Mitsuru enters
    show ySUMnorm:
        xalign 0.75
        yalign 0.8

    nar "..."
    nar "In this moment: Yukari's is SUPPOSED to be studying for her anthropology gen ed..."
    y "Yeah, anyway, that's what I heard about the agency, can you even believe it?"
    nar "But she's on the phone with a new friend she's met in her acting class."
    y "So anyway what's up with you?"
    nar "She sits in a coral reef of human behavior, the coffee shop next to campus. Students from all around interact, flirt and flutter like little birds, social cliques form and fade."
    nar "Although it may be a little bit less dramatic than that descriptions, these are really just young adults getting coffee and studying."
    y "Yeah, so anyway I was talking to Kitsume and-"
    image ySUMsurprise = "YukariSum5.png"*/


        yield return new WaitForSeconds(1);
        YukariSay("Hello I'm in another video game!");
        yield return WaitForContinue();
        YukariSay("Space press works?");
        yield return WaitForContinue();
        NarSay("Narration is a thing that happens!");
        yield break;
    }

    /// <summary>
    /// Writer-friendly shortcut for having Yukari talk.
    /// </summary>
    /// <returns></returns>
    void YukariSay(string text)
    {
        _dm.PrepareCharTalk(yukari_Takeba);
        StartCoroutine(TypeWrite(text));
    }
    
    void MitsuruSay(string text)
    {
        _dm.PrepareCharTalk(mitsuru_Kirijo);
        StartCoroutine(TypeWrite(text));
    }

    void NarSay(string text)
    {
        StartCoroutine(TypeWriteNar(text));
    }

    void HideCharacters()
    {
        _dm.Toggle_UI_Character1();
        _dm.Toggle_UI_Character2();
    }

    void HideCharName()
    {
        _dm.Toggle_UI_NameTextboxTMP();
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
        if (_dm.typingSped) {
            _dm.ResetTypeSpeed();
        }
        
        yield break;
    }

    IEnumerator TypeWriteNar(string text)
    {
        _typing = true;
        string txt = "";

        foreach (char c in text)
        {
            txt += c;
            _dm.SetTextNar(txt);
            yield return new WaitForSeconds(_dm.secondsToType);
        }
        _typing = false;
        if (_dm.typingSped)
        {
            _dm.ResetTypeSpeed();
        }
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
