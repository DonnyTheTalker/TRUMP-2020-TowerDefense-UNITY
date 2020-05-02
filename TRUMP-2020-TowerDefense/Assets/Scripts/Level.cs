using UnityEngine;

[CreateAssetMenu(menuName = "Level")]

public class Level : ScriptableObject
{
    [SerializeField] private string _name;
    [SerializeField] private bool _isAchieved;

    public string Name => _name;
    public bool IsAchieved => _isAchieved;

    public void SetAchieved(bool value)
    {
        _isAchieved = value;
    }

}