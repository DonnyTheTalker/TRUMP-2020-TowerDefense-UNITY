using System.Collections;
using System.Collections.Generic;
using UnityEngine; 

public class NodeUI : MonoBehaviour
{

    private Node _target;
    public GameObject nUI;

    public void SetTarget(Node target)
    {
        _target = target;

        transform.position = _target.GetBuildPosition();

    }

    public void Able()
    {
        nUI.SetActive(true);
    }

    public void Disable()
    {
        nUI.SetActive(false);
    }

}
