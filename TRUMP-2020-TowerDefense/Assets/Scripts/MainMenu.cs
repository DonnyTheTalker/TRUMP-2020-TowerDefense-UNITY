using System.Collections;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{

    public string LevelToLoad = "LevelSelector";
    [SerializeField] private SceneFader _sceneFader;

    public void Play()
    {
        _sceneFader.FadeTo(LevelToLoad);
    }

    public void Quit()
    {
        Application.Quit();
    } 

}
