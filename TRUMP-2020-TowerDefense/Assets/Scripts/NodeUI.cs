using System.Collections;
using System.Collections.Generic;
using UnityEngine; 
using UnityEngine.UI;

public class NodeUI : MonoBehaviour
{

    private Node _target;
    public GameObject nUI;

    public Text UpgradeButtonText;
    public Button UpgradeButton;
    public Text SellButtonText;

    public GameObject UpgradeEffect;
    public GameObject SellEffect;

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

    public void SetProperties(Turret turret)
    {

        Debug.Log("Properties"); 

        if (turret.IsUpgraded) {

            Debug.Log("Already upgraded");

            UpgradeButtonText.text = "DONE";
            UpgradeButton.interactable = false;

        } else {

            Debug.Log("Start text");

            UpgradeButtonText.text = turret.UpgradeCost.ToString() + "$";
            UpgradeButton.interactable = true;

        }

        SellButtonText.text = turret.SellCost.ToString() + "$";
    } 
    public void UpgradeTurret()
    {
        Debug.Log("Upgrade Hub");
        _target.UpgradeTurret(UpgradeEffect); 

    }

    public void Sell()
    {
        Debug.Log("Ёбаный рот этого казино блядь");
        _target.SellNode(SellEffect);
    }

}
