using UnityEngine;

public class Shop : MonoBehaviour
{

    private BuildManager _buildManager;
    public TurretBlueprint StandartTurret;
    public TurretBlueprint MissileLauncher;

    void Start()
    {
        _buildManager = BuildManager.Instance;   
    }

    public void SelectStandartTurret()
    {
        _buildManager.SelectTurretToBuild(StandartTurret);
    }

    public void SelectMissileLauncher()
    {
        _buildManager.SelectTurretToBuild(MissileLauncher);
    }

}
