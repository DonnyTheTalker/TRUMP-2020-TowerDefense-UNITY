using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public Text RoundsText;
    public string MainMenuScene = "MainMenu";
    [SerializeField] private SceneFader _sceneFader;

    void OnEnable()
    {
        RoundsText.text = PlayerStats.RoundsSurvived.ToString();
    }

    public void Retry()
    {
        _sceneFader.FadeTo(SceneManager.GetActiveScene().name);
    }

    public void Menu()
    {
        SceneManager.LoadScene(MainMenuScene);
    }

}
