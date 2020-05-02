using UnityEngine;
using UnityEngine.UI;

public class LevelSelector : MonoBehaviour
{

    [SerializeField] private SceneFader _sceneFader;
    [SerializeField] private Stat _roundsRecord;
    [SerializeField] private Text _roundsRecordText;

    public Button[] LevelsButtons;
    public Level[] Levels;
    public GameObject[] LevelsLockDowns;

    public void Select(string levelName)
    { 
        _sceneFader.FadeTo(levelName); 
    }

    private void Start()
    {
        _roundsRecordText.text = _roundsRecord.Value.ToString() + " waves";

        for (int i = 0; i < Levels.Length; i++) {

            if (Levels[i].IsAchieved) {

                LevelsLockDowns[i].SetActive(false);
                LevelsButtons[i].interactable = true;

            } else {

                LevelsLockDowns[i].SetActive(true);
                LevelsButtons[i].interactable = false;


            }

        }
    }

}
