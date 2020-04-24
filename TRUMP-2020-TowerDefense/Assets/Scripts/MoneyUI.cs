using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyUI : MonoBehaviour
{

    [SerializeField] private Text _moneyText;

    void Update()
    {
        _moneyText.text = "$" + PlayerStats.Money.ToString();
    }
}
