using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameWonUI : MonoBehaviour
{

    public string NextLevel, MainMenu;
    [SerializeField] private Level _nextLevel;
    public SceneFader Fader;
    public Button NextLevelButton;
    public Text WavesSurvived;

    private void Start()
    {
        WavesSurvived.text = PlayerStats.RoundsSurvived.ToString();
        _nextLevel.SetAchieved(true);

        if (NextLevel == "NULL") {
            NextLevelButton.interactable = false;
        } else {
            NextLevelButton.interactable = true;
        }
    }

    public void Menu()
    {
        Fader.FadeTo(MainMenu);
    }

    public void Next()
    {
        Fader.FadeTo(NextLevel);
    }

}
