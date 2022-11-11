using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Sirenix.OdinInspector;

//holds references for all the sprites and behaviours for turning them on/off
public enum DisplayPos { c1, c2 };
[ExecuteInEditMode]
public class DisplayManager : MonoBehaviour
{

    [BoxGroup("Characters")]
    [SerializeField] Image _UI_character1;
    [BoxGroup("Characters")]
    [SerializeField] Image _UI_character2;
    [BoxGroup("Characters")]
    [SerializeField] Color _grayedOutCharacterColor;
    [BoxGroup("Characters")]
    [SerializeField] Color _vibrantCharacterColor;

    [BoxGroup("Background")]
    [SerializeField] Image _UI_background;


    [BoxGroup("Main Textbox")]
    [SerializeField] Image _UI_textbox;
    [BoxGroup("Main Textbox")]
    [SerializeField] TextMeshProUGUI _UI_textboxTMP;
    [BoxGroup("Main Textbox")]
    [SerializeField] TextMeshProUGUI _UI_nameTextboxTMP;

    [BoxGroup("Narration Textbox")]
    [SerializeField] Image _UI_narrationTextbox;
    [BoxGroup("Narration Textbox")]
    [SerializeField] TextMeshProUGUI _UI_narrationTextboxTMP;

    /// <summary>
    /// amount of seconds it takes to type out a letter
    /// </summary>
    [Range(0f, .1f)]
    public float secondsToType;


    /// <summary>
    /// Toggle UI Objects
    /// </summary>
    [BoxGroup("Characters")]
    [Button]
    public void Toggle_UI_Character1()
    {
        bool opposite = _UI_character1.IsActive();
        _UI_character1.gameObject.SetActive(!opposite);
    }
    [BoxGroup("Characters")]
    [Button]
    public void Toggle_UI_Character2()
    {
        bool opposite = _UI_character2.IsActive();
        _UI_character2.gameObject.SetActive(!opposite);
    }

    [BoxGroup("Main Textbox")]
    [Button]
    public void Toggle_UI_Textbox()
    {
        bool opposite = _UI_textbox.IsActive();
        _UI_textbox.gameObject.SetActive(!opposite);
    }
    [BoxGroup("Main Textbox")]
    [Button]
    public void Toggle_UI_TextboxTMP()
    {
        bool opposite = _UI_textboxTMP.IsActive();
        _UI_textboxTMP.gameObject.SetActive(!opposite);
    }
    [BoxGroup("Main Textbox")]
    [Button]
    public void Toggle_UI_NameTextboxTMP()
    {
        bool opposite = _UI_nameTextboxTMP.IsActive();
        _UI_nameTextboxTMP.gameObject.SetActive(!opposite);
    }

    [BoxGroup("Narration Textbox")]
    [Button]
    public void Toggle_UI_NarrationTextbox()
    {
        bool opposite = _UI_narrationTextbox.IsActive();
        _UI_narrationTextbox.gameObject.SetActive(!opposite);
    }
    [BoxGroup("Narration Textbox")]
    [Button]
    public void Toggle_UI_NarrationTextboxTMP()
    {
        bool opposite = _UI_narrationTextboxTMP.IsActive();
        _UI_narrationTextboxTMP.gameObject.SetActive(!opposite);
    }



    /// <summary>
    /// Visuals outside of talking -> called from "Script"
    /// use "count" for a grayed out character
    /// </summary>
    public void Set_CharVisuals(Character c, DisplayPos dC, CharEmotion emotionType)
    {
        Image displayCharacter = _UI_character1;

        if (dC == DisplayPos.c2)
        {
            displayCharacter = _UI_character2;
        }

        if (emotionType == CharEmotion.Count)
        {
            displayCharacter.color = _grayedOutCharacterColor;
            return;
        }

        displayCharacter.color = _vibrantCharacterColor;

        if (c.emotions.ContainsKey(emotionType))
        {
            displayCharacter.sprite = c.emotions[emotionType];
            return;
        }

        Debug.LogError("emotionType " + emotionType.ToString() + " does not exist.");
    }

    /// <summary>
    /// Changing the background look
    /// </summary>
    /// <param name="s"></param>
    public void Set_BGVisual(Sprite s)
    {
        _UI_background.sprite = s;
    }

    /// <summary>
    /// When text appears in the textbox -> called from "script"
    /// </summary>
    public void Prepare_Char_Talk(Character c)
    {
        _UI_nameTextboxTMP.text = c.LastName + " " + c.FirstName;
        _UI_nameTextboxTMP.color = c.NameColor;
    }

    public void SetText(string text)
    {
        _UI_textboxTMP.text = text;
    }




}
