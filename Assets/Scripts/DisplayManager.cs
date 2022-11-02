using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Sirenix.OdinInspector;

//holds references for all the sprites and behaviours for turning them on/off

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


    [BoxGroup("mainTextbox")]
    [SerializeField] Image _UI_textbox;
    [BoxGroup("mainTextbox")]
    [SerializeField] TextMeshProUGUI _UI_textboxTMP;
    [BoxGroup("mainTextbox")]
    [SerializeField] TextMeshProUGUI _UI_nameTextboxTMP;

    [BoxGroup("narrationTextbox")]
    [SerializeField] Image _UI_narrationTextbox;
    [BoxGroup("narrationTextbox")]
    [SerializeField] TextMeshProUGUI  _UI_narrationTextboxTMP;
 

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
    /// </summary>
    public void Set_c1Visuals(Character c, CharacterEmotionType emotionType )
    {
        _UI_nameTextboxTMP.text = c.LastName + " " + c.FirstName;
        _UI_nameTextboxTMP.color = c.NameColor;
        _UI_character1.color = _vibrantCharacterColor;
        
        if (c.emotions.ContainsKey(emotionType))
        {
            _UI_character1.sprite = c.emotions[emotionType];
            return;
        }
        Debug.LogError("emotionType " + emotionType.ToString() + " does not exist.");
    }

    public void Set_c1GrayedOut(Character c, CharacterEmotionType emotionType)
    {
        _UI_character1.color = _grayedOutCharacterColor;

        if (c.emotions.ContainsKey(emotionType))
        {
            _UI_character1.sprite = c.emotions[emotionType];
            return;
        }
        Debug.LogError("emotionType " + emotionType.ToString() + " does not exist.");
    }

    public void Set_c2Visuals(Character c, CharacterEmotionType emotionType)
    {
        _UI_nameTextboxTMP.text = c.LastName + " " + c.FirstName;
        _UI_nameTextboxTMP.color = c.NameColor;
        _UI_character2.color = _vibrantCharacterColor;

        if (c.emotions.ContainsKey(emotionType))
        {
            _UI_character2.sprite = c.emotions[emotionType];
            return;
        }
        Debug.LogError("emotionType " + emotionType.ToString() + " does not exist.");
    }

    public void Set_c2GrayedOut(Character c, CharacterEmotionType emotionType)
    {
        _UI_character2.color = _grayedOutCharacterColor;

        if (c.emotions.ContainsKey(emotionType))
        {
            _UI_character2.sprite = c.emotions[emotionType];
            return;
        }
        Debug.LogError("emotionType " + emotionType.ToString() + " does not exist.");
    }


    /// <summary>
    /// Talking visuals -> called from "script"
    /// </summary>
    public void Set_c1Talking(Character c, CharacterEmotionType emotionType)
    {

    }

}
