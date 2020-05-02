using UnityEngine;
using UnityEngine.UI;

public class LevelSelector : MonoBehaviour
{

    [SerializeField] private SceneFader _sceneFader;
    [SerializeField] private Stat _roundsRecord;
    [SerializeField] private Text _roundsRecordText;

    public void Select(string levelName)
    { 
        _sceneFader.FadeTo(levelName); 
    }

    private void Start()
    {
        _roundsRecordText.text = _roundsRecord.Value.ToString() + " waves";
    }

}
