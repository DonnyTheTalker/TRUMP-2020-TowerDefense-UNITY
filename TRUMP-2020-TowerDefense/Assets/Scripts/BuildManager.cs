using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// singletone, all the nodes share the same instance
public class BuildManager : MonoBehaviour
{

    public static BuildManager Instance; 
    public bool CanBuild { get { return _turretToBuild != null; } }
    public bool PlayerHasMoney { get { return PlayerStats.Money >= GetTurretToBuild().Cost; } }

    // particle system, emitting for turret building
    public GameObject BuildEffect; 

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

        GameObject effect = (GameObject)Instantiate(BuildEffect, node.GetBuildPosition(), Quaternion.identity);
        Destroy(effect, 2f);

        return(GameObject)Instantiate(_turretToBuild.Prefab, node.GetBuildPosition(), node.transform.rotation);
    }

}
