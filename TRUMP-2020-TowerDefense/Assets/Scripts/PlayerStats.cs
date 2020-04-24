using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    public static GameObject EndImage;
    public GameObject endImage;

    public static int Money;
    public int StartMoney = 400;

    public static int nLives;
    public int StartLives = 5;

    private void Start()
    {
        Money = StartMoney;
        nLives = StartLives;
        EndImage = endImage;
    }
    
    public static void TakeDamage()
    {

        if (--nLives <= 0)
            Die();

    }

    public static void Die()
    {
        EndImage.SetActive(true);
    }

}
