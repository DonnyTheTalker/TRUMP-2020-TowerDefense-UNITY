using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private bool _gameEnded;
    public GameObject GameOverUI;

    void Start()
    {

        _gameEnded = false;

    }

    void Update()
    {
    
        if (!_gameEnded) {

            if (Input.GetKeyDown("e"))
                EndGame();

            if (PlayerStats.nLives <= 0) {

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
