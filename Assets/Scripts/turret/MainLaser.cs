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
        createTurret(4);
    }

    // Update is called once per frame
    void Update()
    {

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
