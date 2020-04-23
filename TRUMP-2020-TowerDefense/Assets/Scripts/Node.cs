using UnityEngine; 

// node, where we can build, upgrade and destroy turrets
public class Node : MonoBehaviour
{
    // original node color - same for every node
    // for the most time gonna be white but everything
    // can be changed
    public Color HoverColor;

    private GameObject _turret;

    // we can calculate those at start so that
    // this will be small optimization
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
