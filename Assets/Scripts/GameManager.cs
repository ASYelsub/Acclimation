using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Sirenix.OdinInspector;

public class GameManager : MonoBehaviour
{
    Script script;
    void Start()
    {
        script = FindObjectOfType<Script>();
        script.Init();
    }


}

public enum CharEmotion { Angry, Sad, Happy, Neutral, Blush, Surprise, Count };

[System.Serializable]
public class Character
{
    [SerializeField] string _firstName;
    [SerializeField] string _lastName;
    [SerializeField] Color _nameColor;
    [SerializeField] List<AudioClip> _typeSounds = new List<AudioClip>();
    [FoldoutGroup("Sprites")] [SerializeField] Sprite _angrySprite;
    [FoldoutGroup("Sprites")] [SerializeField] Sprite _sadSprite;
    [FoldoutGroup("Sprites")] [SerializeField] Sprite _happySprite;
    [FoldoutGroup("Sprites")] [SerializeField] Sprite _neutralSprite;
    [FoldoutGroup("Sprites")] [SerializeField] Sprite _blushSprite;
    [FoldoutGroup("Sprites")] [SerializeField] Sprite _surpriseSprite;


    [HideInInspector] public string FirstName { get => _firstName; set => _firstName = value; }
    [HideInInspector] public string LastName { get => _lastName; set => _lastName = value; }
    [HideInInspector] public CharEmotion CurrentEmotion { get => _currentEmotion; set => _currentEmotion = value; }
    [HideInInspector] public Color NameColor { get => _nameColor; set => _nameColor = value; }

    CharEmotion _currentEmotion = CharEmotion.Neutral;

    public Dictionary<CharEmotion, Sprite> emotions = new Dictionary<CharEmotion, Sprite>();

    public void Init()
    {
        emotions.Add(CharEmotion.Angry, _angrySprite);
        emotions.Add(CharEmotion.Sad, _sadSprite);
        emotions.Add(CharEmotion.Happy, _happySprite);
        emotions.Add(CharEmotion.Neutral, _neutralSprite);
        emotions.Add(CharEmotion.Blush, _blushSprite);
        emotions.Add(CharEmotion.Surprise, _surpriseSprite);
    }

}

