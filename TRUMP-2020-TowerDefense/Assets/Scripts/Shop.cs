using UnityEngine;

public class Shop : MonoBehaviour
{

    private BuildManager _buildManager;
    public TurretBlueprint StandartTurret;
    public TurretBlueprint MissileLauncher;
    public TurretBlueprint LaserBeamer;

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

    public void SelectLaserBeamer()
    {
        _buildManager.SelectTurretToBuild(LaserBeamer);
    }

}
