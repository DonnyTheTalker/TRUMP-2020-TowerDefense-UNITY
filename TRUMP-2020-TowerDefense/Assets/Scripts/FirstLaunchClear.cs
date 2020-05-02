using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstLaunchClear : MonoBehaviour
{
    [SerializeField] private Stat FirstLaunch;
    [SerializeField] private Stat RoundsRecord;
    [SerializeField] private Level[] levels;

    private void Start()
    {
        
        if (FirstLaunch.Value == 1) {

            FirstLaunch.SetValue(0);
            RoundsRecord.SetValue(0);

            for (int i = 0; i < levels.Length; i++)
                levels[i].SetAchieved(false);

        }

    }

}

