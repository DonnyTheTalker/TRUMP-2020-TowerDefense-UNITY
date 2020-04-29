using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private bool _gameEnded;
    public GameObject GameOverUI;
    public GameObject nodeUI;

    void Start()
    {

        _gameEnded = false;

    }

    void Update()
    {
    
        if (!_gameEnded) {

            if (PlayerStats.nLives <= 0) {

                nodeUI.SetActive(false);
                EndGame();

            }

        }
        
    }

    void EndGame()
    {

        _gameEnded = true;
        GameOverUI.SetActive(true);

    }

}
