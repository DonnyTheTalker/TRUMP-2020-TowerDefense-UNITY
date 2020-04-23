using UnityEngine;

public class Shop : MonoBehaviour
{

    private BuildManager _buildManager;

    void Start()
    {
        _buildManager = BuildManager.Instance;   
    }

    public void PurchaseTurret(GameObject turret)
    { 
        _buildManager.SetTurretToBuld(turret);
        Debug.Log("Purchased");

    }

}
