using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{  
    public static int Money;
    public int StartMoney = 400;

    public static int nLives;
    public static int MaxLives;
    public int StartLives = 5;
    private int _maxLives;

    public static int RoundsSurvived;

    private void Start()
    {
        Money = StartMoney;
        nLives = StartLives;
        RoundsSurvived = 0;
        MaxLives = StartLives;
    }
    
    public static void TakeDamage()
    {

        nLives = Mathf.Max(nLives - 1, 0); 

        TrumpFace.ChangeImage((float)nLives / (float)MaxLives);

    } 

}
