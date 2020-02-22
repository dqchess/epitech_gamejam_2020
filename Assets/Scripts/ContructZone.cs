using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContructZone : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject turret;
    bool canBuild;
    void Start()
    {
        canBuild = false;
    }

    private void OnMouseEnter()
    {
        canBuild = true;
        Debug.Log("enter");

    }

    private void OnMouseExit()
    {
        canBuild = false;
        Debug.Log("Out");
    }
    
    private void OnMouseDown()
    {
        if (Input.GetButtonDown("Fire1"))
            createTurret();
    }

    public void createTurret()
    {
        if (turret != null)
        {
            Debug.Log("too many turret");
            return;
        }
        GameObject turretToBuild = BuildManager.instance.actualTurret;
        turretToBuild.GetComponent<AutoTurret>().parent = transform.parent.gameObject;
        turret =(GameObject)Instantiate(turretToBuild, transform.position, transform.rotation, transform);
    }

    void destroyTurret()
    {
        Debug.Log("Destroy");
        if (turret)
            Destroy(turret);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire2") && canBuild)
            destroyTurret();
    }
}
