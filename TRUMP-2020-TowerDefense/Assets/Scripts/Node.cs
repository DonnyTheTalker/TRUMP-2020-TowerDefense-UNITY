using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

// node, where we can build, upgrade and destroy turrets
public class Node : MonoBehaviour
{
    // node entered color - same for every node
    // for the most time gonna be grey but everything
    // can be changed
    public Color HoverColor;
    public Color BlockColor = Color.red;

    private GameObject _turret;
    private Turret _turretScript;

    // we can calculate those at start so that
    // this will be small optimization
    private Renderer _renderer;
    private Color _startColor;

    // our node can change it's position and it won't cause
    // turret positioning troubles
    public Vector3 PositionOffset;

    private BuildManager _buildManager; 

    public Vector3 GetBuildPosition()
    {
        return transform.position + PositionOffset;
    }

    void Start()
    {
        _buildManager = BuildManager.Instance;
        _renderer = GetComponent<Renderer>();
        _startColor = _renderer.material.color;

    }

    void OnMouseEnter()
    {

        if (EventSystem.current.IsPointerOverGameObject())
            return;

        Debug.Log("MouseEnter");

        if (_buildManager.CanBuild) {

            if (_buildManager.PlayerHasMoney || _turret != null)
                _renderer.material.color = HoverColor;
            else
                _renderer.material.color = BlockColor;
        }
    }

    void OnMouseExit()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;
        Debug.Log("MouseExit");
        _renderer.material.color = _startColor;
    }

    void OnMouseDown()
    {
        Debug.Log("MouseDown");
        if (_turret != null ) {

            _buildManager.SelectNode(this); 
            
            if (_buildManager.GetNode() != null) {
                _buildManager.nodeUI.SetProperties(_turretScript);
            }
            _renderer.material.color = _startColor;

        } else if (_buildManager.CanBuild && _buildManager.PlayerHasMoney) {

            _turret = _buildManager.BuildTurretOn(this);
            _turretScript = _turret.GetComponent<Turret>();

        }
    } 
    public void UpgradeTurret(GameObject upgradeEffect)
    {

        if (PlayerStats.Money < _turretScript.UpgradeCost || _turretScript.IsUpgraded) {

            return;

        } else {


            PlayerStats.Money -= _turretScript.UpgradeCost;
            _turretScript.IsUpgraded = true;

            Vector3 newScale;

            newScale.x = 1.2f;
            newScale.y = 1.2f;
            newScale.z = 1.2f;

            _turret.transform.localScale = newScale;

            _turretScript.FireRate *= 1.5f;
            _turretScript.Range *= 1.5f;
            _turretScript.DamagePerSecond = (int)(_turretScript.DamagePerSecond * 1.5f);
            _turretScript.SlowPercentage *= 1.3f;

            GameObject effect = (GameObject)Instantiate(upgradeEffect, GetBuildPosition(), Quaternion.identity);
            Destroy(effect.gameObject, 2f);

            _buildManager.DeselectNode();

        }

    }

}
