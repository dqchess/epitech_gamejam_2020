using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContructZone : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject [] turret;
    bool canBuild;
    public Transform [] zones;
    public List<SkillBox> skillBox = new List<SkillBox>();
    void Start()
    {
        canBuild = false;
        turret = new GameObject [zones.Length];
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
            transform.GetChild(0).gameObject.SetActive(true);
    }

    public void createTurret(int num)
    {
        if (turret[num] != null)
        {
            Debug.Log("too many turret");
            return;
        }
        GameObject turretToBuild = BuildManager.instance.actualTurret;
        turretToBuild.GetComponent<AutoTurret>().parent = transform.parent.gameObject;
        turret[num] =(GameObject)Instantiate(turretToBuild, zones[num].position, transform.rotation, transform);
    }

    public void upgradeTurret(int num)
    {
        if (turret[num]) {
            Destroy(turret[num]);
            turret[num] = null;
        }
        if (turret[num] != null)
        {
            Debug.Log("too many turret");
            return;
        }
        GameObject turretToBuild = BuildManager.instance.actualTurret;
        turretToBuild.GetComponent<AutoTurret>().parent = transform.parent.gameObject;
        GameObject tmp = Instantiate(turretToBuild, zones[num].position, transform.rotation, transform);
        tmp.GetComponent<DamageableObj>().onDeath.AddListener(skillBox[num].ResetLevel);
        turret[num] = tmp;
    }

    void destroyTurret(int num)
    {
        Debug.Log("Destroy");
        if (turret[num]) {
            Destroy(turret[num]);
            turret[num] = null;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire2") && canBuild)
            destroyTurret(0);
    }
}
