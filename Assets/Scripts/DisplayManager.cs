using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Sirenix.OdinInspector;

//holds references for all the sprites and behaviours for turning them on/off
public enum WhichDisplayCharacter { c1, c2 };
[ExecuteInEditMode]
public class DisplayManager : MonoBehaviour
{

    [BoxGroup("characters")]
    [SerializeField] Image _UI_character1;
    [BoxGroup("characters")]
    [SerializeField] Image _UI_character2;
    [BoxGroup("characters")]
    [SerializeField] Color _grayedOutCharacterColor;
    [BoxGroup("characters")]
    [SerializeField] Color _vibrantCharacterColor;

    [BoxGroup("background")]
    [SerializeField] Image _UI_background;


    [BoxGroup("mainTextbox")]
    [SerializeField] Image _UI_textbox;
    [BoxGroup("mainTextbox")]
    [SerializeField] TextMeshProUGUI _UI_textboxTMP;
    [BoxGroup("mainTextbox")]
    [SerializeField] TextMeshProUGUI _UI_nameTextboxTMP;

    [BoxGroup("narrationTextbox")]
    [SerializeField] Image _UI_narrationTextbox;
    [BoxGroup("narrationTextbox")]
    [SerializeField] TextMeshProUGUI _UI_narrationTextboxTMP;


    /// <summary>
    /// Toggle UI Objects
    /// </summary>
    [BoxGroup("characters")]
    [Button]
    public void Toggle_UI_Character1()
    {
        bool opposite = _UI_character1.IsActive();
        _UI_character1.gameObject.SetActive(!opposite);
    }
    [BoxGroup("characters")]
    [Button]
    public void Toggle_UI_Character2()
    {
        bool opposite = _UI_character2.IsActive();
        _UI_character2.gameObject.SetActive(!opposite);
    }

    [BoxGroup("mainTextbox")]
    [Button]
    public void Toggle_UI_Textbox()
    {
        bool opposite = _UI_textbox.IsActive();
        _UI_textbox.gameObject.SetActive(!opposite);
    }
    [BoxGroup("mainTextbox")]
    [Button]
    public void Toggle_UI_TextboxTMP()
    {
        bool opposite = _UI_textboxTMP.IsActive();
        _UI_textboxTMP.gameObject.SetActive(!opposite);
    }
    [BoxGroup("mainTextbox")]
    [Button]
    public void Toggle_UI_NameTextboxTMP()
    {
        bool opposite = _UI_nameTextboxTMP.IsActive();
        _UI_nameTextboxTMP.gameObject.SetActive(!opposite);
    }

    [BoxGroup("narrationTextbox")]
    [Button]
    public void Toggle_UI_NarrationTextbox()
    {
        bool opposite = _UI_narrationTextbox.IsActive();
        _UI_narrationTextbox.gameObject.SetActive(!opposite);
    }
    [BoxGroup("narrationTextbox")]
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
    public void Set_CharVisuals(Character c, WhichDisplayCharacter dC, CharacterEmotionType emotionType)
    {
        Image displayCharacter = _UI_character1;

        if (dC == WhichDisplayCharacter.c2)
        {
            displayCharacter = _UI_character2;
        }

        if (emotionType == CharacterEmotionType.Count)
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
    public void Set_Text(Character c, CharacterEmotionType emotionType)
    {
        _UI_nameTextboxTMP.text = c.LastName + " " + c.FirstName;
        _UI_nameTextboxTMP.color = c.NameColor;
    }

    
}
