using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LivesUI : MonoBehaviour
{

    [SerializeField] private Text _livesText; 

    void Update()
    {
        _livesText.text = PlayerStats.nLives.ToString() + " LIVES LEFT";
    }
}
