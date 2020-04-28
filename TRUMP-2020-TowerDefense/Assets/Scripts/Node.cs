using UnityEngine;
using System.Collections;

// node, where we can build, upgrade and destroy turrets
public class Node : MonoBehaviour
{
    // node entered color - same for every node
    // for the most time gonna be grey but everything
    // can be changed
    public Color HoverColor;
    public Color BlockColor = Color.red;

    private GameObject _turret;

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
        if (_buildManager.CanBuild) {

            if (_buildManager.PlayerHasMoney || _turret != null)
                _renderer.material.color = HoverColor;
            else
                _renderer.material.color = BlockColor;
        }
    }

    void OnMouseExit()
    {
        _renderer.material.color = _startColor;
    }

    void OnMouseDown()
    {
        if (_turret != null ) {

            _buildManager.SelectNode(this); 

        } else if (_buildManager.CanBuild && _buildManager.PlayerHasMoney) {

            _turret = _buildManager.BuildTurretOn(this);

        }
    }  
}
