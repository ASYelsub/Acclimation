using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    [SerializeField] GameObject _startSceneButton;
    Script _script;

    void Awake()
    {
        _script = FindObjectOfType<Script>();
        _startSceneButton.SetActive(true);
    }

    public void StartSceneButtonPress()
    {
        _startSceneButton.SetActive(false);
        StartCoroutine(_script.StartScript());
    }
}
