using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// singletone, all the nodes
public class BuildManager : MonoBehaviour
{

    public static BuildManager Instance; 
    public bool CanBuild { get { return _turretToBuild != null; } }
    public bool PlayerHasMoney { get { return PlayerStats.Money >= GetTurretToBuild().Cost; } }

    void Awake()
    {
        Instance = this;
    } 

    private TurretBlueprint _turretToBuild; 

    void Start()
    {
        _turretToBuild = null;
    }

    public TurretBlueprint GetTurretToBuild()
    {
        return _turretToBuild;
    }

    public void SelectTurretToBuild(TurretBlueprint turret)
    {
        SetTurretToBuld(turret);
    }

    public void SetTurretToBuld(TurretBlueprint turret)
    {
        _turretToBuild = turret;
    }

    public GameObject BuildTurretOn(Node node)
    {

        if (!PlayerHasMoney) { 
            return null;
        }
        PlayerStats.Money -= _turretToBuild.Cost;
        return(GameObject)Instantiate(_turretToBuild.Prefab, node.GetBuildPosition(), node.transform.rotation);
    }

}
