using UnityEngine;

public class LevelSelector : MonoBehaviour
{

    [SerializeField] private SceneFader _sceneFader;

    public void Select(string levelName)
    {

        _sceneFader.FadeTo(levelName);
    
    }

}
