﻿using UnityEngine;
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

            if (_buildManager.PlayerHasMoney)
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

            Debug.Log("Already built");

        } else if (_buildManager.CanBuild && _buildManager.PlayerHasMoney) {

            _turret = _buildManager.BuildTurretOn(this);


        }
    }  
}
