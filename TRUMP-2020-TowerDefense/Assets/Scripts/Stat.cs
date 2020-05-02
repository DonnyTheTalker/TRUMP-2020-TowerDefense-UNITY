using UnityEngine;

[CreateAssetMenu(menuName = "Stat")]

public class Stat : ScriptableObject
{
    [SerializeField] private string _name;
    [SerializeField] private int _value;

    public string Name => _name;
    public int Value => _value;

    public void SetValue(int value)
    {
        _value = value;
    }

}