using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainLaser : MonoBehaviour
{
    public GameObject[] turrets;
    public GameObject actualTurret;
    // Start is called before the first frame update
    void Start()
    {
        createTurret(0);
    }

    // Update is called once per frame
    void Update()
    {

    }

    
    public void upgradeTurret(int num)
    {
        if (actualTurret) {
            Destroy(actualTurret);
            actualTurret = null;
        }
        if (actualTurret != null)
        {
            Debug.Log("too many turret");
            return;
        }

        GameObject turretToBuild = turrets[num];
        turretToBuild.GetComponent<PlayerControlledTurret>().parent = transform.parent.gameObject;
        actualTurret = (GameObject)Instantiate(turretToBuild, transform.position, transform.rotation, transform);
    }

    public void createTurret(int num)
    {
        if (actualTurret != null)
        {
            Debug.Log("too many turret");
            return;
        }

        GameObject turretToBuild = turrets[num];
        turretToBuild.GetComponent<PlayerControlledTurret>().parent = transform.parent.gameObject;
        actualTurret = (GameObject)Instantiate(turretToBuild, transform.position, transform.rotation, transform);
    }

    void destroyTurret()
    {
        Debug.Log("Destroy");
        if (actualTurret)
            Destroy(actualTurret);
    }

}
