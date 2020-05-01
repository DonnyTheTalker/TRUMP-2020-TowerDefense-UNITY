using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public Text RoundsText;
    public string MainMenuScene = "MainMenu";

    void OnEnable()
    {
        RoundsText.text = PlayerStats.RoundsSurvived.ToString();
    }

    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Menu()
    {
        SceneManager.LoadScene(MainMenuScene);
    }

}
