using UnityEngine; 

public class Node : MonoBehaviour
{

    public Color HoverColor;

    private GameObject _turret;

    private Renderer _renderer;
    private Color _startColor;

    public Vector3 PositionOffset;

    void Start()
    {

        _renderer = GetComponent<Renderer>();
        _startColor = _renderer.material.color;

    }

    void OnMouseEnter()
    {
        _renderer.material.color = HoverColor;
    }

    void OnMouseExit()
    {
        _renderer.material.color = _startColor;
    }

    void OnMouseDown()
    {
        if (_turret != null) {

            Debug.Log("Already built");

        } else {

            GameObject turretToBuild = BuildManager.Instance.GetTurretToBuild();
            _turret = (GameObject)Instantiate(turretToBuild, transform.position + PositionOffset, transform.rotation);


        }
    }
}
