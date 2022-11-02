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

    [BoxGroup("mainTextbox")]
    [SerializeField] Image _UI_textbox;
    [BoxGroup("mainTextbox")]
    [SerializeField] TextMeshProUGUI _UI_textboxTMP;

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

   


    
}
