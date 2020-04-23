using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// singletone, all the nodes
public class BuildManager : MonoBehaviour
{

    public static BuildManager Instance; 

    void Awake()
    {
        Instance = this;
    } 

    private GameObject _turretToBuild;
    public GameObject StandartTurretPrefab;

    void Start()
    {
        _turretToBuild = StandartTurretPrefab;
    }

    public GameObject GetTurretToBuild()
    {
        return _turretToBuild;
    }

}
